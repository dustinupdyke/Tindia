using FileHelpers;
using System;
using System.Web;

namespace IdeaTinder.Models
{
    public class Ideas
    {
        public static Idea[] Get()
        {
            var engine = new FileHelperEngine(typeof(Idea));
            try
            {
                var o = engine.ReadFile(HttpRuntime.AppDomainAppPath + "/app_data/ideas.csv") as Idea[];
                return o;
            }
            catch
            {
                return null;
            }
        }

        public static void Save(Idea idea)
        {
            var engine = new FileHelperEngine(typeof(Idea));
            try
            {
                idea.Id = Guid.NewGuid().ToString();
                engine.AppendToFile(HttpRuntime.AppDomainAppPath + "/app_data/ideas.csv", idea);
            }
            catch
            {
            }
        }

        [DelimitedRecord(",")]
        public class Idea
        {
            [FieldQuoted]
            public string Id;
            [FieldQuoted]
            public string Name;
            [FieldQuoted]
            public DateTime Created;
            [FieldQuoted]
            public string CreatedBy;
            [FieldQuoted]
            public string CreatedByName;

            public Idea()
            {
                this.Created = DateTime.Now;
            }
        }
    }
}