using Bratwurst.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bratwurst.Models
{
    public class PictureList
    {
        public List<Photo> plist;

        public PictureList()
        {
            plist = new List<Photo>();
        }
    }
}