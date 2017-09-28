using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bratwurst.Models
{
    public class Photo
    {
        public int ID { get; }
        public string caption { get; set; }
        public string imageUrl { get; }
        public string text { get; }
        public string tags { get; }
        public string credit { get; }
        public List<Voter> voters { get; }
        public int amountOfVoters { get; }

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

        public Photo(string Caption, string ImageUrl, string Text, string Tags, string Credit)
        {
            this.caption = Caption;
            this.imageUrl = ImageUrl;
            this.text = Text;
            this.tags = Tags;
            this.credit = Credit;
        }
    }
}