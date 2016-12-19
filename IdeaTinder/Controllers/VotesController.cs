using IdeaTinder.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace IdeaTinder.Controllers
{
    public class VotesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Votes.Vote> Get()
        {
            return Votes.Get();
        }

        // GET api/<controller>/5
        public Votes.Vote Get(string id)
        {
            foreach (var o in Votes.Get())
            {
                if (o.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase))
                    return o;
            }
            return null;
        }

        // POST api/<controller>
        public void Post([FromBody]Votes.Vote request)
        {
            var foundUser = Utils.FindAccountByType("(samAccountName={0})", request.CreatedBy);
            if(foundUser != null)
                request.CreatedByName = foundUser.Properties["displayName"][0].ToString();

            Votes.Save(request);
        }
        
        [HttpDelete]
        public void DeleteAll()
        {
            Votes.DeleteAll();
        }
    }
}