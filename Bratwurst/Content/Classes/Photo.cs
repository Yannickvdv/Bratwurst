using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bratwurst.Classes
{
    public class Photo
    {
        private int ID { get; }
        private string caption { get; set; }
        private string imageUrl { get; }
        private string text { get; }
        private string tags { get; }
        private string credit { get; }
        private List<Voter> voters { get; }

        public Photo()
        {

        }
       
    }
}