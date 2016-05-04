﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Votr.DAL;

namespace Votr.Controllers
{
    public class PollController : Controller
    {
        private VotrRepository Repo = new VotrRepository();
        // GET: Poll
        public ActionResult Index()
        {
            ViewBag.Polls = Repo.GetPolls();
            return View();
        }

        // GET: Poll/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Poll/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Poll/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Poll/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Poll/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Poll/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Poll/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
