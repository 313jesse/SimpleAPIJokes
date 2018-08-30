using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestfulAPI.Controllers
{
    public class JokeController : ApiController
    {
        [HttpGet]     //<-- this is an attribute   can be a post if its something you'd like to add to the database. 
       public string dadJokes()
        {
            string[] dadJokes = { "Did you hear about the restaurant on the moon? Great food, no atmosphere.", "How many apples grow on a tree? All of them.", "What do you call a fat psychic? A four-chin teller.", "What's brown and sticky? A stick." };

        //randomly select joke
        Random r = new Random();
        int selected = r.Next(0, dadJokes.Length);


        //return the joke
        return dadJokes[selected];

           

        }
        
    }
}