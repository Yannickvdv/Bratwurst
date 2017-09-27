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
        private int amountOfVoters { get; }

        public Photo()
        {

        }

        public Photo(int ID, string Caption, string ImageUrl, string Text, string Tags, string Credit, List<Voter> Voters)
        {
            this.ID = ID;
            this.caption = Caption;
            this.imageUrl = ImageUrl;
            this.text = Text;
            this.tags = Tags;
            this.credit = Credit;
            this.voters = Voters;
        }

        public Photo(int ID, string Caption, string ImageUrl, string Text, string Tags, string Credit, int AmountOfVoters)
        {
            this.ID = ID;
            this.caption = Caption;
            this.imageUrl = ImageUrl;
            this.text = Text;
            this.tags = Tags;
            this.credit = Credit;
            this.amountOfVoters = AmountOfVoters;
        }

    }
}