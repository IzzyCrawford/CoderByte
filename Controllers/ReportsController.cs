using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CoderByte.Models;

namespace CoderByte.Controllers
{
    public class ReportsController : Controller
    {
        private CoderByteDb db = new CoderByteDb();

        public ActionResult Index()
        {
            var clients = db.Clients;

            return View(clients.ToList());
        }

        // GET: Reports
        public JsonResult GetJsonResult()
        {
            DataTable dt = new DataTable();
            
            var reports =  from cp in db.Client_Products
                              join c in db.Clients on cp.ClientID equals c.Id
                              join r in db.Regions on c.RegionID equals r.Id
                              join p in db.Products on cp.ProductID equals p.Id
                              select new { cp.Id, c.Name, r.Location, p.MonthlyBasePrice, cp.Discount };

            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(reports);

            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}