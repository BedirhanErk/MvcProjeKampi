﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Headings(int id)
        {
            var values = hm.GetList();
            return View(values);
        }
        public PartialViewResult PartialContent(int id = 0)
        {
            var values = cm.GetListByHeadingId(id);
            var head = hm.GetById(id).HeadingName;
            ViewBag.h = head;
            return PartialView(values);
        }
    }
}