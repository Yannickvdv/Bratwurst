﻿using Bratwurst.Content;
using Bratwurst.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Bratwurst.Controllers
{
    public class HomeController : Controller
    {
        SQLDataLayer sql = new SQLDataLayer();

        // GET: Home
        public ActionResult Index()
        {
            var model = new List<Photo>();

            Random random = new Random();
            List<Photo> photos = sql.getPictures();
            List<Photo> randomPhotoList = new List<Photo>();

            int randomIndex = 0;
            while (photos.Count > 0)
            {
                randomIndex = random.Next(0, photos.Count); //Choose a random object in the list
                randomPhotoList.Add(photos[randomIndex]); //add it to the new, random list
                photos.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            foreach (Photo p in randomPhotoList)
            {
                model.Add(p);
            }

            return View(model);
        }

        public ActionResult Login()
        {
            ViewBag.WrongInput = false;
            if (Request.HttpMethod == "POST")
            {
                if (Request.Params["email"] != "" && Request.Params["password"] != "")
                {
                    Voter voter = sql.getAccount(Request.Params["email"], Request.Params["password"]);
                    if(voter != null)
                    {
                        Session["loggedemail"] = voter.email;
                        Session["loggedname"] = voter.firstName;
                        return Redirect("Index");
                    }
                    else
                    {
                        ViewBag.WrongInput = true;
                    }
                }
                else
                {
                    ViewBag.WrongInput = true;
                }
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return Redirect("Index");
        }

        public ActionResult Register()
        {
            ViewBag.WrongInput = false;
            if (Request.HttpMethod == "POST")
            {
                if (Request.Params["email"] != "" && Request.Params["password"] != "" && Request.Params["firstname"] != "" && Request.Params["password"] == Request.Params["confPassword"])
                {
                    sql.uploadAccount(Request.Params["email"], Request.Params["password"], Request.Params["firstname"]);
                    return Redirect("Index");
                }
                else
                {
                    ViewBag.WrongInput = true;
                }
            }
            return View();
        }

        public ActionResult Upload()
        {
            ViewBag.WrongInput = false;
            if (Request.HttpMethod == "POST")
            {
                if (Request.Params["caption"] != "" && Request.Params["url"] != "" && Request.Params["story"] != "")
                {
                    Photo p = new Photo(Request.Params["caption"], Request.Params["url"], Request.Params["story"], Request.Params["tags"], Request.Params["credit"]);
                    sql.uploadImage(p);
                    return Redirect("Index");
                }
                else
                {
                    ViewBag.WrongInput = true;
                }
            }
            return View();
        }

        public ActionResult likePicture(int photoID, string userEmail)
        {
            sql.likePicture(photoID, userEmail);
            return RedirectToAction("Index", "Home");
        }
    }
}