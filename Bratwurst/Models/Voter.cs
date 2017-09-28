using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bratwurst.Models
{
    public class Voter
    {
        public string email { get; }
        public string firstName { get; }

        public Voter()
        {

        }

        public Voter(string Email, string Firstname)
        {
            this.email = Email;
            this.firstName = Firstname;
        }
    }
}