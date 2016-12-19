using FileHelpers;
using System;
using System.Web;

namespace IdeaTinder.Models
{
    public class Votes
    {
        public static Vote[] Get()
        {
            var engine = new FileHelperEngine(typeof(Vote));
            try
            {
                var o = engine.ReadFile(HttpRuntime.AppDomainAppPath + "/app_data/votes.csv") as Vote[];
                return o;
            }
            catch
            {
                return null;
            }
        }

        public static void Save(Vote vote)
        {
            var engine = new FileHelperEngine(typeof(Vote));
            try
            {
                vote.Id = Guid.NewGuid().ToString();
                engine.AppendToFile(HttpRuntime.AppDomainAppPath + "/app_data/votes.csv", vote);
            }
            catch
            {
            }
        }

        public static void DeleteAll()
        {
            System.IO.File.Delete(HttpRuntime.AppDomainAppPath + "/app_data/votes.csv");
            using (System.IO.File.Create(HttpRuntime.AppDomainAppPath + "/app_data/votes.csv")) ;
        }

        [DelimitedRecord(",")]
        public class Vote
        {
            [FieldQuoted]
            public string Id;
            [FieldQuoted]
            public string IdeaId;
            [FieldQuoted]
            public bool Like;
            [FieldQuoted]
            public DateTime Created;
            [FieldQuoted]
            public string CreatedBy;
            [FieldQuoted]
            public string CreatedByName;

            public Vote()
            {
                this.Created = DateTime.Now;
            }
        }
    }
}