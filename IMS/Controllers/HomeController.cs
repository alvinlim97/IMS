using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMSContext _context;
        public HomeController(IMSContext context)
        {
            _context = context;
        }

        //Put staff into a list
        public IList<Incident> Incident { get; set; }
        //Get staff from the List
        public SelectList Types { get; set; }
        //Filter staff by search "paging"
        public string SearchString { get; set; }

        public async Task<IActionResult> Index(string searchString, string CType)
        {
            var sessionID = ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            if (sessionID != null)
            {

                ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
                ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
                ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
                //ViewData["CategorySort"] = String.IsNullOrEmpty(sortOrder) ? "CategorySort" : "";
                
                var SID = HttpContext.Session.GetString("StaffID");
                var SP = await _context.Staff
               .FirstOrDefaultAsync(m => m.ID.ToString() == HttpContext.Session.GetString("StaffID"));
                HttpContext.Session.SetString("SP", SP.Spoint.ToString());
                ViewBag.SP = HttpContext.Session.GetString("SP");
                var JD = await _context.Staff
              .FirstOrDefaultAsync(m => m.ID.ToString() == HttpContext.Session.GetString("StaffID"));
                HttpContext.Session.SetString("JD", JD.JoinedDate.Date.ToString("MM/dd/yyyy"));
                ViewBag.JD = HttpContext.Session.GetString("JD");
                var TTD = from m in _context.IncidentTask
                          where m.Status == "Pending"
                          select m;
                var TOH = from m in _context.IncidentTask
                          where m.EID.ToString() == SID && m.Status == "Processing"
                          select m; 
                var TC = from m in _context.IncidentTask
                         where m.EID.ToString() == SID && m.Status == "Solved" && m.SDate.Date.ToString("MM/dd/yyyy") == DateTime.Now.Date.ToString("MM/dd/yyyy")
                select m;
                var RA = from m in _context.IncidentTask
                         where  m.EDate.ToString("MM/dd/yyyy") == DateTime.Now.Date.ToString("MM/dd/yyyy") || m.SDate.ToString("MM/dd/yyyy") == DateTime.Now.Date.ToString("MM/dd/yyyy")
                         select m;

                var TaskPending = TTD.Count();
                var TaskOnHand = TOH.Count();
                var TaskCompleted = TC.Count();

                HttpContext.Session.SetString("TaskPending", TTD.Count().ToString());
                ViewBag.TaskPending = HttpContext.Session.GetString("TaskPending");
                HttpContext.Session.SetString("TaskOnHand", TOH.Count().ToString());
                ViewBag.TaskOnHand = HttpContext.Session.GetString("TaskOnHand");
                HttpContext.Session.SetString("TaskCompleted", TC.Count().ToString());
                ViewBag.TaskCompleted = HttpContext.Session.GetString("TaskCompleted");
                HttpContext.Session.SetString("RecentActivity", RA.Count().ToString());
                ViewBag.RecentActivity = HttpContext.Session.GetString("RecentActivity");

                HttpContext.Session.SetString("Today", DateTime.Now.DayOfWeek.ToString());
                ViewBag.Today = HttpContext.Session.GetString("Today");

                var incident = from m in _context.Incident
                               where m.Status == "Active"
                               select m;
                //Get staff by Role
                IQueryable<string> TypeQuery = from m in _context.Incident
                                               orderby m.Category
                                               select m.Category;

                if (!string.IsNullOrEmpty(searchString))
                {
                    incident = incident.Where(s => s.Iname.Contains(searchString) || s.Category.Contains(searchString) || s.Description.Contains(searchString));
                }

                if (!string.IsNullOrEmpty(CType))
                {
                    incident = incident.Where(x => x.Category == CType);
                }

                //switch (sortOrder)
                //{
                //    case "CategorySort":
                //        incident = incident.OrderBy(s => s.Category);
                //        break;  
                //}

                IEnumerable<SelectListItem> ctype = new SelectList(await TypeQuery.Distinct().ToListAsync());
                ViewBag.CType = ctype;

                return View(await incident.OrderByDescending(s => s.Count).ToListAsync());
            }
            else
            {
                return RedirectToAction("Login", "Logins");
            }



            //var staffDetail = await _context.Staff
            //   .FirstOrDefaultAsync(m => m.ID == id);
            //TempData["ID"] = staffDetail.ID;
            //TempData["Name"] = staffDetail.Sname;
            //TempData["Role"] = staffDetail.Role;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
