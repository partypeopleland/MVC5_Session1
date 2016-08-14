﻿using MVC5_Session1.Models;
using MVC5_Session1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5_Session1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AcctBookSvc _acctSvc;

        public HomeController()
        {
            var unitOfWork = new EFUnitOfWork();
            _acctSvc = new AcctBookSvc(unitOfWork);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult AcctBook()
        {
            return View();
        }
        /// <summary>
        /// 方案一：氣滿紅血招式放大絕
        /// </summary>
        /// <param name="frm">表單傳送資料</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AcctBook(FormCollection frm)
        {
            AccountBook target = _acctSvc.ConvToObjByFrm(frm);
            if (target != null)
            {
                _acctSvc.Add(target);
                _acctSvc.Save();
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [ChildActionOnly]
        public ActionResult MoneyList()
        {
            //TODO:未來可能要接收搜尋引擎參數進行查詢動作
            var model = _acctSvc.getRealData();
            return View(model);
        }
    }
}