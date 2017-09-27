using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bratwurst.Classes
{
    public class Voter
    {
        private string email { get; }
        private string password { get; }
        private string firstName { get; }

        public Voter()
        {

        }

        public Voter(string Email, string Password, string Firstname)
        {
            this.email = Email;
            this.password = Password;
            this.firstName = Firstname;
        }
    }
}