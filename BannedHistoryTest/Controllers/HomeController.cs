using BannedHistoryTest.Models;
using BannedHistoryTest.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BannedHistoryTest.Controllers
{
    public class HomeController : Controller
    {
        public const int RecordsPerPage = 50;
        private BannedClientHistoryRepository bcRepo;
        public HomeController()
        {
            var context = new DbEntitiesContext();
            bcRepo = new BannedClientHistoryRepository(context);

        }
        public ActionResult Index()
        {
            return RedirectToAction("GetBans");
        }
        public ActionResult GetBans(int? pageNum)
        {
            pageNum = pageNum ?? 0;
            ViewBag.IsEndOfRecords = false;
            if (Request.IsAjaxRequest())
            {
                var bans = GetRecordsForPage(pageNum.Value);
                // ViewBag.IsEndOfRecords = (customers.Any()) && ((pageNum.Value * RecordsPerPage) >= customers.Last().ID);
                bool end = (bans.Any()) && (bans.Last().ID==bcRepo.GetLastBan().ID);
                ViewBag.IsEndOfRecords = end;
                return PartialView("_BannedClientRow", bans);
            }
            else
            {
                LoadAllCustomersToSession();
                ViewBag.Bans = GetRecordsForPage(pageNum.Value);
                return View("Index");
            }
        }

        public void LoadAllCustomersToSession()
        {
            //var customerRepo = new CustomerRepository();
           // var customers = bcRepo.FindAll().ToList();
            //int custIndex = 1;
            // Session["Customers"] = customers;
            ViewBag.TotalNumberCustomers = bcRepo.GetTotalBans();
        }

        public List<BannedClientHistoryViewModel> GetRecordsForPage(int pageNum)
        {
            //Dictionary<int, BannedClientHistory> customers = (Session["Customers"] as Dictionary<int, BannedClientHistory>);
            //List<BannedClientHistory> customers = Session["Customers"] as List<BannedClientHistory>;
            int from = (pageNum * RecordsPerPage);
            int to = from + RecordsPerPage;


            /*return customers
                .Where(x => x.Key > from && x.Key <= to)
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);*/
            List<BannedClientHistory> bcTemp = bcRepo.FindExact(from, to);
            return bcTemp.Select(w=>new BannedClientHistoryViewModel(w)).ToList();
        }
    }
}