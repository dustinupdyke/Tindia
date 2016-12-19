using System.Collections.Generic;
using IdeaTinder.Models;
using System.Web.Http;
using System;

namespace IdeaTinder.Controllers
{
    public class IdeasController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Ideas.Idea> Get()
        {
            var returnIdeas = new List<Ideas.Idea>();
            var ideas = Ideas.Get();
            var votes = Votes.Get();

            foreach(var idea in ideas)
            {
                var hasVoted = false;
                foreach (var vote in votes)
                {
                    if (vote.IdeaId == idea.Id && vote.CreatedBy == "M104203") //User.Identity.Name.Replace("MYL\\", ""))
                    {
                        hasVoted = true;
                        break;
                    }
                }
                if (!hasVoted)
                    returnIdeas.Add(idea);
            }

            returnIdeas.Sort((x, y) => DateTime.Compare(x.Created, y.Created));
            return returnIdeas;
        }

        // GET api/<controller>/5
        public Ideas.Idea Get(string id)
        {
            foreach(var idea in Ideas.Get())
            {
                if (idea.Id.Equals(id, System.StringComparison.InvariantCultureIgnoreCase))
                    return idea;
            }
            return null;
        }

        // POST api/<controller>
        public void Post([FromBody]Ideas.Idea request)
        {
            if (string.IsNullOrEmpty(request.Name))
                return;

            if (string.IsNullOrEmpty(request.CreatedBy))
                request.CreatedBy = "M104203";

            var foundUser = Utils.FindAccountByType("(samAccountName={0})", request.CreatedBy);
            if (foundUser != null)
                request.CreatedByName = foundUser.Properties["displayName"][0].ToString();

            Ideas.Save(request);
        }
    }
}