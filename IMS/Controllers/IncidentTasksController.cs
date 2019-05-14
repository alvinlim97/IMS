using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IMS.Models;
using Microsoft.AspNetCore.Http;

namespace IMS.Views
{
    public class IncidentTasksController : Controller
    {

        public int GlobalIncidentID = 0;
        private readonly IMSContext _context;

        public IncidentTasksController(IMSContext context)
        {
            _context = context;
        }
        public IList<IncidentTask> IncidentTask { get; set; }
        //Get staff from the List
        public SelectList Types { get; set; }
        //Filter staff by search "paging"
        public string SearchString { get; set; }
        // GET: IncidentTasks
        public async Task<IActionResult> Index(string searchString, string DType, string EType,string SType, string CType)
        {

            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            var incidentTasks = from m in _context.IncidentTask
                                where m.Status == "Pending" || m.Status == "Processing"
                           select m;
            var incidentTasksDate = from m in _context.IncidentTask
                                select m;
            IQueryable<string> TypeQuery4 = from m in _context.IncidentTask
                                            orderby m.Eway
                                            select m.Eway;
            IQueryable<string> TypeQuery3 = from m in _context.IncidentTask
                                            orderby m.Category
                                            select m.Category;
            IQueryable<string> TypeQuery2 = from m in _context.IncidentTask
                                            orderby m.Ename
                                            select m.Ename;
            IQueryable<string> TypeQuery = from m in _context.IncidentTask
                                           orderby m.Status
                                            select m.Status;
            if (!string.IsNullOrEmpty(searchString))
            {
                incidentTasks = incidentTasks.Where(s => s.Ename.Contains(searchString) || s.Category.Contains(searchString) || s.ID.ToString().Contains(searchString));
            }

            if (!string.IsNullOrEmpty(EType))
            {
                incidentTasks = incidentTasks.Where(x => x.Ename == EType);
            }

            if (!string.IsNullOrEmpty(CType))
            {
                incidentTasks = incidentTasks.Where(x => x.Category == CType);
            }

            if (!string.IsNullOrEmpty(SType))
            {
                incidentTasks = incidentTasks.Where(x => x.Status == SType);
            }
            if (!string.IsNullOrEmpty(DType))
            {
                incidentTasks = incidentTasks.Where(x => x.Eway == DType);
            }
            IEnumerable<SelectListItem> etype = new SelectList(await TypeQuery2.Distinct().ToListAsync());
            ViewBag.EType = etype;
            IEnumerable<SelectListItem> ctype = new SelectList(await TypeQuery3.Distinct().ToListAsync());
            ViewBag.CType = ctype;
            IEnumerable<SelectListItem> stype = new SelectList(await TypeQuery.Distinct().ToListAsync());
            ViewBag.SType = stype;
            IEnumerable<SelectListItem> dtype = new SelectList(await TypeQuery4.Distinct().ToListAsync());
            ViewBag.DType = dtype;
            
            return View(await incidentTasks.OrderBy(s => s.EDate).ToListAsync());
        }

        public async Task<IActionResult> TaskCompleted(string searchString, string DType, string CType)
        {

            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            var incidentTasks = from m in _context.IncidentTask
                                where m.Status == "Solved" && m.EID.ToString() == HttpContext.Session.GetString("StaffID")
                                select m;
            var incidentTasksDate = from m in _context.IncidentTask
                                    select m;
            IQueryable<string> TypeQuery4 = from m in _context.IncidentTask
                                            orderby m.Eway
                                            select m.Eway;
            IQueryable<string> TypeQuery3 = from m in _context.IncidentTask
                                            orderby m.Category
                                            select m.Category;
            if (!string.IsNullOrEmpty(searchString))
            {
                incidentTasks = incidentTasks.Where(s => s.ID.ToString().Contains(searchString));
            }

            if (!string.IsNullOrEmpty(CType))
            {
                incidentTasks = incidentTasks.Where(x => x.Category == CType);
            }
            if (!string.IsNullOrEmpty(DType))
            {
                incidentTasks = incidentTasks.Where(x => x.Eway == DType);
            }
            IEnumerable<SelectListItem> ctype = new SelectList(await TypeQuery3.Distinct().ToListAsync());
            ViewBag.CType = ctype;
            IEnumerable<SelectListItem> dtype = new SelectList(await TypeQuery4.Distinct().ToListAsync());
            ViewBag.DType = dtype;

            return View(await incidentTasks.OrderByDescending(s => s.SDate).ToListAsync());
        }

        public async Task<IActionResult> OnHand(string searchString, string EType, string SType, string CType)
        {

            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            var incidentTasks = from m in _context.IncidentTask
                              where m.EID.ToString() == HttpContext.Session.GetString("StaffID") && m.Status == "Processing"
                              select m;

            IQueryable<string> TypeQuery3 = from m in _context.IncidentTask
                                            orderby m.Category
                                            select m.Category;
            IQueryable<string> TypeQuery = from m in _context.IncidentTask
                                           orderby m.Status
                                           select m.Status;

            if (!string.IsNullOrEmpty(searchString))
            {
                incidentTasks = incidentTasks.Where(s => s.Ename.Contains(searchString) || s.Category.Contains(searchString));
            }
            

            if (!string.IsNullOrEmpty(CType))
            {
                incidentTasks = incidentTasks.Where(x => x.Category == CType);
            }

            if (!string.IsNullOrEmpty(SType))
            {
                incidentTasks = incidentTasks.Where(x => x.Status == SType);
            }
            
            IEnumerable<SelectListItem> ctype = new SelectList(await TypeQuery3.Distinct().ToListAsync());
            ViewBag.CType = ctype;
            IEnumerable<SelectListItem> stype = new SelectList(await TypeQuery.Distinct().ToListAsync());
            ViewBag.SType = stype;
            return View(await incidentTasks.OrderBy(s => s.EDate).ToListAsync());
        }

        public async Task<IActionResult> Escalation(string searchString, string EType, string SType, string CType)
        {

            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            var incidentTasks = from m in _context.IncidentTask
                                where m.SID.ToString() == HttpContext.Session.GetString("StaffID")
                                select m;

            IQueryable<string> TypeQuery3 = from m in _context.IncidentTask
                                            orderby m.Category
                                            select m.Category;
            IQueryable<string> TypeQuery = from m in _context.IncidentTask
                                           orderby m.Status
                                           select m.Status;

            if (!string.IsNullOrEmpty(searchString))
            {
                incidentTasks = incidentTasks.Where(s => s.Ename.Contains(searchString) || s.Category.Contains(searchString));
            }


            if (!string.IsNullOrEmpty(CType))
            {
                incidentTasks = incidentTasks.Where(x => x.Category == CType);
            }

            if (!string.IsNullOrEmpty(SType))
            {
                incidentTasks = incidentTasks.Where(x => x.Status == SType);
            }

            IEnumerable<SelectListItem> ctype = new SelectList(await TypeQuery3.Distinct().ToListAsync());
            ViewBag.CType = ctype;
            IEnumerable<SelectListItem> stype = new SelectList(await TypeQuery.Distinct().ToListAsync());
            ViewBag.SType = stype;
            return View(await incidentTasks.OrderBy(s => s.EDate).ToListAsync());
        }

        public async Task<IActionResult> ReportMonthly(int? id, string searchString, string SType, string CType)
        {

            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            var year = ViewBag.Year = HttpContext.Session.GetString("Year");
            HttpContext.Session.SetString("month", id.ToString());
            ViewBag.month = HttpContext.Session.GetString("month");
            var incidentTasks = from m in _context.IncidentTask
                                where m.EDate.Year.ToString()== HttpContext.Session.GetString("Year")
                                select m;
            if (incidentTasks == null)
            {
                return RedirectToAction("ReportDetail", "IncidentTasks");
            }
           
            var monthly = from m in incidentTasks
                          where m.EDate.Month.ToString() == id.ToString()
                       select m;
            IQueryable<string> TypeQuery3 = from m in monthly
                                            orderby m.Category
                                            select m.Category;
            IQueryable<string> TypeQuery = from m in monthly
                                           orderby m.Status
                                           select m.Status;

            if (!string.IsNullOrEmpty(searchString))
            {
                monthly = monthly.Where(s => s.Ename.Contains(searchString) || s.Category.Contains(searchString));
            }


            if (!string.IsNullOrEmpty(CType))
            {
                monthly = monthly.Where(x => x.Category == CType);
            }

            if (!string.IsNullOrEmpty(SType))
            {
                monthly = monthly.Where(x => x.Status == SType);
            }

            IEnumerable<SelectListItem> ctype = new SelectList(await TypeQuery3.Distinct().ToListAsync());
            ViewBag.CType = ctype;
            IEnumerable<SelectListItem> stype = new SelectList(await TypeQuery.Distinct().ToListAsync());
            ViewBag.SType = stype;
            return View(await monthly.OrderBy(s => s.EDate).ToListAsync());
        }


        public async Task<IActionResult> ReportYearly(int? id)
        {

            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            ViewBag.Year = HttpContext.Session.GetString("Year");
            ViewBag.CheckCount = HttpContext.Session.GetString("CheckCount");
            ViewBag.IDD = HttpContext.Session.GetString("IDD");
            var incidentTasks = from m in _context.IncidentTask
                                where m.EDate.Year.ToString() == HttpContext.Session.GetString("Year")
                                select m;

            var incident = from m in _context.IncidentTask
                           join x in _context.Incident
                          on m.IID equals x.ID
                           where m.EDate.Year.ToString() == HttpContext.Session.GetString("Year")
                           select m;
            

            if (incidentTasks == null)
            {
                return RedirectToAction("ReportDetail", "IncidentTasks");
            }

            return View(await incident.OrderBy(s => s.IID).ToListAsync());
        }

        public async Task<IActionResult> CheckFeedback(int? id)
        {

            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            ViewBag.Year = HttpContext.Session.GetString("Year");
            ViewBag.CheckCount = HttpContext.Session.GetString("CheckCount");
            ViewBag.IDD = HttpContext.Session.GetString("IDD");
            var incidentTasks = from m in _context.IncidentTask
                                where m.EDate.Year.ToString() == HttpContext.Session.GetString("Year") && m.IID == id
                                select m;
            
            return View(await incidentTasks.OrderBy(s => s.IID).ToListAsync());
        }

        public IActionResult Reports()
        {
            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            var T1 = from m in _context.IncidentTask
                         where m.EDate.Date.ToString("MM/dd/yyyy") == DateTime.Now.Date.ToString("MM/dd/yyyy")
                         select m;
            var T2 = from m in _context.IncidentTask
                     where m.EDate.Date.ToString("MM/dd/yyyy") == DateTime.Now.AddDays(-1).Date.ToString("MM/dd/yyyy")
                     select m;
            var T3 = from m in _context.IncidentTask
                     where m.EDate.Date.ToString("MM/dd/yyyy") == DateTime.Now.AddDays(-2).Date.ToString("MM/dd/yyyy")
                     select m;
            var T4 = from m in _context.IncidentTask
                     where m.EDate.Date.ToString("MM/dd/yyyy") == DateTime.Now.AddDays(-3).Date.ToString("MM/dd/yyyy")
                     select m;
            var T5 = from m in _context.IncidentTask
                     where m.EDate.Date.ToString("MM/dd/yyyy") == DateTime.Now.AddDays(-4).Date.ToString("MM/dd/yyyy")
                     select m;
            var T6 = from m in _context.IncidentTask
                     where m.EDate.Date.ToString("MM/dd/yyyy") == DateTime.Now.AddDays(-5).Date.ToString("MM/dd/yyyy")
                     select m;
            var T7 = from m in _context.IncidentTask
                     where m.EDate.Date.ToString("MM/dd/yyyy") == DateTime.Now.AddDays(-6).Date.ToString("MM/dd/yyyy")
                     select m;

            var TD1 = from m in _context.IncidentTask
                     where  m.Status == "Solved" && m.SDate.Date.ToString("MM/dd/yyyy") == DateTime.Now.Date.ToString("MM/dd/yyyy")
                     select m;
            var TD2 = from m in _context.IncidentTask
                      where m.Status == "Solved" && m.SDate.Date.ToString("MM/dd/yyyy") == DateTime.Now.AddDays(-1).Date.ToString("MM/dd/yyyy")
                      select m;
            var TD3 = from m in _context.IncidentTask
                      where m.Status == "Solved" && m.SDate.Date.ToString("MM/dd/yyyy") == DateTime.Now.AddDays(-2).Date.ToString("MM/dd/yyyy")
                      select m;
            var TD4 = from m in _context.IncidentTask
                      where m.Status == "Solved" && m.SDate.Date.ToString("MM/dd/yyyy") == DateTime.Now.AddDays(-3).Date.ToString("MM/dd/yyyy")
                      select m;
            var TD5 = from m in _context.IncidentTask
                      where m.Status == "Solved" && m.SDate.Date.ToString("MM/dd/yyyy") == DateTime.Now.AddDays(-4).Date.ToString("MM/dd/yyyy")
                      select m;
            var TD6 = from m in _context.IncidentTask
                      where m.Status == "Solved" && m.SDate.Date.ToString("MM/dd/yyyy") == DateTime.Now.AddDays(-5).Date.ToString("MM/dd/yyyy")
                      select m;
            var TD7 = from m in _context.IncidentTask
                      where m.Status == "Solved" && m.SDate.Date.ToString("MM/dd/yyyy") == DateTime.Now.AddDays(-6).Date.ToString("MM/dd/yyyy")
                      select m;

            HttpContext.Session.SetString("Task1", T1.Count().ToString());
            ViewBag.Task1 = HttpContext.Session.GetString("Task1");
            HttpContext.Session.SetString("Task2", T2.Count().ToString());
            ViewBag.Task2 = HttpContext.Session.GetString("Task2");
            HttpContext.Session.SetString("Task3", T3.Count().ToString());
            ViewBag.Task3 = HttpContext.Session.GetString("Task3");
            HttpContext.Session.SetString("Task4", T4.Count().ToString());
            ViewBag.Task4 = HttpContext.Session.GetString("Task4");
            HttpContext.Session.SetString("Task5", T5.Count().ToString());
            ViewBag.Task5 = HttpContext.Session.GetString("Task5");
            HttpContext.Session.SetString("Task6", T6.Count().ToString());
            ViewBag.Task6 = HttpContext.Session.GetString("Task6");
            HttpContext.Session.SetString("Task7", T7.Count().ToString());
            ViewBag.Task7 = HttpContext.Session.GetString("Task7");

            HttpContext.Session.SetString("TaskD1", TD1.Count().ToString());
            ViewBag.TaskD1 = HttpContext.Session.GetString("TaskD1");
            HttpContext.Session.SetString("TaskD2", TD2.Count().ToString());
            ViewBag.TaskD2 = HttpContext.Session.GetString("TaskD2");
            HttpContext.Session.SetString("TaskD3", TD3.Count().ToString());
            ViewBag.TaskD3 = HttpContext.Session.GetString("TaskD3");
            HttpContext.Session.SetString("TaskD4", TD4.Count().ToString());
            ViewBag.TaskD4 = HttpContext.Session.GetString("TaskD4");
            HttpContext.Session.SetString("TaskD5", TD5.Count().ToString());
            ViewBag.TaskD5 = HttpContext.Session.GetString("TaskD5");
            HttpContext.Session.SetString("TaskD6", TD6.Count().ToString());
            ViewBag.TaskD6 = HttpContext.Session.GetString("TaskD6");
            HttpContext.Session.SetString("TaskD7", TD7.Count().ToString());
            ViewBag.TaskD7 = HttpContext.Session.GetString("TaskD7");

            HttpContext.Session.SetString("Date1", DateTime.Now.Date.ToString("MM/dd/yyyy"));
            ViewBag.Date1 = HttpContext.Session.GetString("Date1");
            HttpContext.Session.SetString("Date2", DateTime.Now.AddDays(-1).Date.ToString("MM/dd/yyyy"));
            ViewBag.Date2 = HttpContext.Session.GetString("Date2");
            HttpContext.Session.SetString("Date3", DateTime.Now.AddDays(-2).Date.ToString("MM/dd/yyyy"));
            ViewBag.Date3 = HttpContext.Session.GetString("Date3");
            HttpContext.Session.SetString("Date4", DateTime.Now.AddDays(-3).Date.ToString("MM/dd/yyyy"));
            ViewBag.Date4 = HttpContext.Session.GetString("Date4");
            HttpContext.Session.SetString("Date5", DateTime.Now.AddDays(-4).Date.ToString("MM/dd/yyyy"));
            ViewBag.Date5 = HttpContext.Session.GetString("Date5");
            HttpContext.Session.SetString("Date6", DateTime.Now.AddDays(-5).Date.ToString("MM/dd/yyyy"));
            ViewBag.Date6 = HttpContext.Session.GetString("Date6");
            HttpContext.Session.SetString("Date7", DateTime.Now.AddDays(-6).Date.ToString("MM/dd/yyyy"));
            ViewBag.Date7 = HttpContext.Session.GetString("Date7");

            HttpContext.Session.SetString("Day1", DateTime.Now.DayOfWeek.ToString());
            ViewBag.Day1 = HttpContext.Session.GetString("Day1");
            HttpContext.Session.SetString("Day2", DateTime.Now.AddDays(-1).DayOfWeek.ToString());
            ViewBag.Day2 = HttpContext.Session.GetString("Day2");
            HttpContext.Session.SetString("Day3", DateTime.Now.AddDays(-2).DayOfWeek.ToString());
            ViewBag.Day3 = HttpContext.Session.GetString("Day3");
            HttpContext.Session.SetString("Day4", DateTime.Now.AddDays(-3).DayOfWeek.ToString());
            ViewBag.Day4 = HttpContext.Session.GetString("Day4");
            HttpContext.Session.SetString("Day5", DateTime.Now.AddDays(-4).DayOfWeek.ToString());
            ViewBag.Day5 = HttpContext.Session.GetString("Day5");
            HttpContext.Session.SetString("Day6", DateTime.Now.AddDays(-5).DayOfWeek.ToString());
            ViewBag.Day6 = HttpContext.Session.GetString("Day6");
            HttpContext.Session.SetString("Day7", DateTime.Now.AddDays(-6).DayOfWeek.ToString());
            ViewBag.Day7 = HttpContext.Session.GetString("Day7");

            return View();
        }

        public IActionResult ReportDetail(string searchString)
        {
            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            var incidentTasks = from m in _context.IncidentTask
                                select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                incidentTasks = incidentTasks.Where(s => s.EDate.Year.ToString().Equals(searchString));
                var incidentSolved = from m in _context.IncidentTask
                                     where m.EDate.Year.ToString().Equals(searchString) && m.Status == "Solved"
                                     select m;
                var totalIncident = incidentTasks.Count();
                HttpContext.Session.SetString("totalIncident", totalIncident.ToString());
                ViewBag.totalIncident = HttpContext.Session.GetString("totalIncident");
                HttpContext.Session.SetString("incidentSolved", incidentSolved.Count().ToString());
                ViewBag.incidentSolved = HttpContext.Session.GetString("incidentSolved");
                HttpContext.Session.SetString("Year", searchString);
                ViewBag.Year = HttpContext.Session.GetString("Year");
                var rJan = from m in incidentTasks
                           where m.EDate.Month.ToString() == "1"
                           select m;
                var rFeb = from m in incidentTasks
                           where m.EDate.Month.ToString() == "2"
                           select m;
                var rMar = from m in incidentTasks
                           where m.EDate.Month.ToString() == "3"
                           select m;
                var rApr = from m in incidentTasks
                           where  m.EDate.Month.ToString() == "4"
                           select m;
                var rMay = from m in incidentTasks
                           where m.EDate.Month.ToString() == "5"
                           select m;
                var rJun = from m in incidentTasks
                           where  m.EDate.Month.ToString() == "6"
                           select m;
                var rJul = from m in incidentTasks
                           where m.EDate.Month.ToString() == "7"
                           select m;
                var rAug = from m in incidentTasks
                           where  m.EDate.Month.ToString() == "8"
                           select m;
                var rSep = from m in incidentTasks
                           where m.EDate.Month.ToString() == "9"
                           select m;
                var rOct = from m in incidentTasks
                           where m.EDate.Month.ToString() == "10"
                           select m;
                var rNov = from m in incidentTasks
                           where  m.EDate.Month.ToString() == "11"
                           select m;
                var rDec = from m in incidentTasks
                           where m.EDate.Month.ToString() == "12"
                           select m;

                var rsJan = from m in incidentTasks
                           where m.EDate.Month.ToString() == "1" && m.Status == "Solved"
                           select m;
                var rsFeb = from m in incidentTasks
                            where m.EDate.Month.ToString() == "2" && m.Status == "Solved"
                            select m;
                var rsMar = from m in incidentTasks
                            where m.EDate.Month.ToString() == "3" && m.Status == "Solved"
                            select m;
                var rsApr = from m in incidentTasks
                            where m.EDate.Month.ToString() == "4" && m.Status == "Solved"
                            select m;
                var rsMay = from m in incidentTasks
                           where m.EDate.Month.ToString() == "5" && m.Status == "Solved"
                            select m;
                var rsJun = from m in incidentTasks
                            where m.EDate.Month.ToString() == "6" && m.Status == "Solved"
                            select m;
                var rsJul = from m in incidentTasks
                            where m.EDate.Month.ToString() == "7" && m.Status == "Solved"
                            select m;
                var rsAug = from m in incidentTasks
                            where m.EDate.Month.ToString() == "8" && m.Status == "Solved"
                            select m;
                var rsSep = from m in incidentTasks
                            where m.EDate.Month.ToString() == "9" && m.Status == "Solved"
                            select m;
                var rsOct = from m in incidentTasks
                            where m.EDate.Month.ToString() == "10" && m.Status == "Solved"
                            select m;
                var rsNov = from m in incidentTasks
                            where m.EDate.Month.ToString() == "11" && m.Status == "Solved"
                            select m;
                var rsDec = from m in incidentTasks
                            where m.EDate.Month.ToString() == "12" && m.Status == "Solved"
                            select m;

                if (rJan != null)
                {
                    HttpContext.Session.SetString("rJan", rJan.Count().ToString());
                    ViewBag.rJan = HttpContext.Session.GetString("rJan");
                }
                else
                {
                    HttpContext.Session.SetString("rJan", "0");
                    ViewBag.rJan = HttpContext.Session.GetString("rJan");
                }
                if (rFeb != null)
                {
                    HttpContext.Session.SetString("rFeb", rFeb.Count().ToString());
                    ViewBag.rFeb = HttpContext.Session.GetString("rFeb");
                }
                else
                {
                    HttpContext.Session.SetString("rFeb", "0");
                    ViewBag.rFeb = HttpContext.Session.GetString("rFeb");
                }
                if (rMar != null)
                {
                    HttpContext.Session.SetString("rMar", rMar.Count().ToString());
                    ViewBag.rMar = HttpContext.Session.GetString("rMar");
                }
                else
                {
                    HttpContext.Session.SetString("rMar", "0");
                    ViewBag.rMar = HttpContext.Session.GetString("rMar");
                }
                if (rApr != null)
                {
                    HttpContext.Session.SetString("rApr", rApr.Count().ToString());
                    ViewBag.rApr = HttpContext.Session.GetString("rApr");
                }
                else
                {
                    HttpContext.Session.SetString("rApr", "0");
                    ViewBag.rApr = HttpContext.Session.GetString("rApr");
                }
                if (rMay != null)
                {
                    HttpContext.Session.SetString("rMay", rMay.Count().ToString());
                    ViewBag.rMay = HttpContext.Session.GetString("rMay");
                }
                else
                {
                    HttpContext.Session.SetString("rMay", "0");
                    ViewBag.rMay = HttpContext.Session.GetString("rMay");
                }
                if (rJun != null)
                {
                    HttpContext.Session.SetString("rJun", rJun.Count().ToString());
                    ViewBag.rJun = HttpContext.Session.GetString("rJun");
                }
                else
                {
                    HttpContext.Session.SetString("rJun", "0");
                    ViewBag.rJun = HttpContext.Session.GetString("rJun");
                }
                if (rJul != null)
                {
                    HttpContext.Session.SetString("rJul", rJul.Count().ToString());
                    ViewBag.rJul = HttpContext.Session.GetString("rJul");
                }
                else
                {
                    HttpContext.Session.SetString("rJul", "0");
                    ViewBag.rJul = HttpContext.Session.GetString("rJul");
                }
                if (rAug != null)
                {
                    HttpContext.Session.SetString("rAug", rAug.Count().ToString());
                    ViewBag.rAug = HttpContext.Session.GetString("rAug");
                }
                else
                {
                    HttpContext.Session.SetString("rAug", "0");
                    ViewBag.rAug = HttpContext.Session.GetString("rAug");
                }
                if (rSep != null)
                {
                    HttpContext.Session.SetString("rSep", rSep.Count().ToString());
                    ViewBag.rSep = HttpContext.Session.GetString("rSep");
                }
                else
                {
                    HttpContext.Session.SetString("rSep", "0");
                    ViewBag.rSep = HttpContext.Session.GetString("rSep");
                }
                if (rOct != null)
                {
                    HttpContext.Session.SetString("rOct", rOct.Count().ToString());
                    ViewBag.rOct = HttpContext.Session.GetString("rOct");
                }
                else
                {
                    HttpContext.Session.SetString("rOct", "0");
                    ViewBag.rOct = HttpContext.Session.GetString("rOct");
                }
                if (rNov != null)
                {
                    HttpContext.Session.SetString("rNov", rNov.Count().ToString());
                    ViewBag.rNov = HttpContext.Session.GetString("rNov");
                }
                else
                {
                    HttpContext.Session.SetString("rNov", "0");
                    ViewBag.rNov = HttpContext.Session.GetString("rNov");
                }
                if (rDec != null)
                {
                    HttpContext.Session.SetString("rDec", rDec.Count().ToString());
                    ViewBag.rDec = HttpContext.Session.GetString("rDec");
                }
                else
                {
                    HttpContext.Session.SetString("rDec", "0");
                    ViewBag.rDec = HttpContext.Session.GetString("rDec");
                }
                //solved
                if (rsJan != null)
                {
                    HttpContext.Session.SetString("rsJan", rsJan.Count().ToString());
                    ViewBag.rsJan = HttpContext.Session.GetString("rsJan");
                }
                else
                {
                    HttpContext.Session.SetString("rsJan", "0");
                    ViewBag.rsJan = HttpContext.Session.GetString("rsJan");
                }
                if (rsFeb != null)
                {
                    HttpContext.Session.SetString("rsFeb", rsFeb.Count().ToString());
                    ViewBag.rsFeb = HttpContext.Session.GetString("rsFeb");
                }
                else
                {
                    HttpContext.Session.SetString("rsFeb", "0");
                    ViewBag.rsFeb = HttpContext.Session.GetString("rsFeb");
                }
                if (rsMar != null)
                {
                    HttpContext.Session.SetString("rsMar", rsMar.Count().ToString());
                    ViewBag.rsMar = HttpContext.Session.GetString("rsMar");
                }
                else
                {
                    HttpContext.Session.SetString("rsMar", "0");
                    ViewBag.rsMar = HttpContext.Session.GetString("rsMar");
                }
                if (rsApr != null)
                {
                    HttpContext.Session.SetString("rsApr", rsApr.Count().ToString());
                    ViewBag.rsApr = HttpContext.Session.GetString("rsApr");
                }
                else
                {
                    HttpContext.Session.SetString("rsApr", "0");
                    ViewBag.rsApr = HttpContext.Session.GetString("rsApr");
                }
                if (rsMay != null)
                {
                    HttpContext.Session.SetString("rsMay", rsMay.Count().ToString());
                    ViewBag.rsMay = HttpContext.Session.GetString("rsMay");
                }
                else
                {
                    HttpContext.Session.SetString("rsMay", "0");
                    ViewBag.rsMay = HttpContext.Session.GetString("rsMay");
                }
                if (rsJun != null)
                {
                    HttpContext.Session.SetString("rsJun", rsJun.Count().ToString());
                    ViewBag.rsJun = HttpContext.Session.GetString("rsJun");
                }
                else
                {
                    HttpContext.Session.SetString("rsJun", "0");
                    ViewBag.rsJun = HttpContext.Session.GetString("rsJun");
                }
                if (rsJul != null)
                {
                    HttpContext.Session.SetString("rsJul", rsJul.Count().ToString());
                    ViewBag.rsJul = HttpContext.Session.GetString("rsJul");
                }
                else
                {
                    HttpContext.Session.SetString("rsJul", "0");
                    ViewBag.rsJul = HttpContext.Session.GetString("rsJul");
                }
                if (rsAug != null)
                {
                    HttpContext.Session.SetString("rsAug", rsAug.Count().ToString());
                    ViewBag.rsAug = HttpContext.Session.GetString("rsAug");
                }
                else
                {
                    HttpContext.Session.SetString("rsAug", "0");
                    ViewBag.rsAug = HttpContext.Session.GetString("rsAug");
                }
                if (rsSep != null)
                {
                    HttpContext.Session.SetString("rsSep", rsSep.Count().ToString());
                    ViewBag.rsSep = HttpContext.Session.GetString("rsSep");
                }
                else
                {
                    HttpContext.Session.SetString("rsSep", "0");
                    ViewBag.rsSep = HttpContext.Session.GetString("rsSep");
                }
                if (rsOct != null)
                {
                    HttpContext.Session.SetString("rsOct", rsOct.Count().ToString());
                    ViewBag.rsOct = HttpContext.Session.GetString("rsOct");
                }
                else
                {
                    HttpContext.Session.SetString("rsOct", "0");
                    ViewBag.rsOct = HttpContext.Session.GetString("rsOct");
                }
                if (rsNov != null)
                {
                    HttpContext.Session.SetString("rsNov", rsNov.Count().ToString());
                    ViewBag.rsNov = HttpContext.Session.GetString("rsNov");
                }
                else
                {
                    HttpContext.Session.SetString("rsNov", "0");
                    ViewBag.rsNov = HttpContext.Session.GetString("rsNov");
                }
                if (rsDec != null)
                {
                    HttpContext.Session.SetString("rsDec", rsDec.Count().ToString());
                    ViewBag.rsDec = HttpContext.Session.GetString("rsDec");
                }
                else
                {
                    HttpContext.Session.SetString("rsDec", "0");
                    ViewBag.rsDec = HttpContext.Session.GetString("rsDec");
                }

            }
            return View();
        }

        // GET: IncidentTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            if (id == null)
            {
                return NotFound();
            }

            var incidentTask = await _context.IncidentTask
                .FirstOrDefaultAsync(m => m.ID == id);
            if (incidentTask == null)
            {
                return NotFound();
            }
            if (incidentTask.Status == "Solved")
            {
                HttpContext.Session.SetString("Solved", incidentTask.Status);
                ViewBag.Solved = HttpContext.Session.GetString("Solved");
            }

            var incidentTasks = await _context.IncidentTask
                .FirstOrDefaultAsync(m => m.ID == id);
            HttpContext.Session.SetString("AddEway", incidentTasks.Eway.ToString());
            ViewBag.AddEway = HttpContext.Session.GetString("AddEway");
            var incident = await _context.Incident
              .FirstOrDefaultAsync((m => m.ID == incidentTask.IID));
            if(incident != null)
            {
                if (incident.Solution != null)
                {
                    HttpContext.Session.SetString("Solution", incident.Solution);
                    ViewBag.Solution = HttpContext.Session.GetString("Solution");
                }
                if (incident.Images != null)
                {
                    ViewData["image"] = Convert.ToBase64String(incident.Images);
                }
                if (incident.Videos != null)
                {
                    ViewData["video"] = Convert.ToBase64String(incident.Videos);
                }
            }

            //Add Manual Incident Set String
            HttpContext.Session.SetString("ManualName", incidentTasks.Iname.ToString());
            ViewBag.ManualName = HttpContext.Session.GetString("ManualName");
            HttpContext.Session.SetString("ManualCategory", incidentTasks.Category.ToString());
            ViewBag.ManualCategory = HttpContext.Session.GetString("ManualCategory");
            HttpContext.Session.SetString("ManualDescription", incidentTasks.Description.ToString());
            ViewBag.ManualDescription = HttpContext.Session.GetString("ManualDescription");
            HttpContext.Session.SetString("ManualID", incidentTasks.ID.ToString());
            ViewBag.ManualID = HttpContext.Session.GetString("ManualID");


            return View(incidentTask);
        }

        public async Task<IActionResult> Escalate(int id)
        {
                GlobalIncidentID = id;
            var incident = await _context.Incident
               .FirstOrDefaultAsync(m => m.ID == id);
            HttpContext.Session.SetString("IncidentID", id.ToString());
            HttpContext.Session.SetString("IncidentName", incident.Iname);
            HttpContext.Session.SetString("IncidentCategory", incident.Category);
            HttpContext.Session.SetString("IncidentDescription", incident.Description);
            return RedirectToAction("Create", "IncidentTasks");
        }

        public IActionResult SelfEscalate()
        {
            ViewBag.EscalatedDT = DateTime.Now;
            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            ViewBag.StaffFloor = HttpContext.Session.GetString("StaffFloor");
            ViewBag.StaffDepartment = HttpContext.Session.GetString("StaffDepartment");
            ViewBag.StaffTable = HttpContext.Session.GetString("StaffTable");
            HttpContext.Session.SetString("SEway", "Manual");
            ViewBag.SEway = HttpContext.Session.GetString("SEway");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SelfEscalate([Bind("ID,ESname,SID,Floor,Department,TableNo,IID,Iname,Category,Description,EDate,Status,SDate,EID,Ename,Eway,Satisfication,FeedBack")] IncidentTask incidentTask)
        {
            incidentTask.EDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(incidentTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(incidentTask);
        }
        // GET: IncidentTasks/Create
        public IActionResult Create()
        {
            ViewBag.EscalatedDT = DateTime.Now;
            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            ViewBag.StaffFloor = HttpContext.Session.GetString("StaffFloor");
            ViewBag.StaffDepartment = HttpContext.Session.GetString("StaffDepartment");
            ViewBag.StaffTable = HttpContext.Session.GetString("StaffTable");
            ViewBag.IncidentID = HttpContext.Session.GetString("IncidentID");
            ViewBag.IncidentName = HttpContext.Session.GetString("IncidentName");
            ViewBag.IncidentCategory = HttpContext.Session.GetString("IncidentCategory");
            ViewBag.IncidentDescription = HttpContext.Session.GetString("IncidentDescription");
            HttpContext.Session.SetString("AEway", "Auto");
            ViewBag.AEway = HttpContext.Session.GetString("AEway");
            return View();


        }

        // POST: IncidentTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ESname,SID,Floor,Department,TableNo,IID,Iname,Category,Description,EDate,Status,SDate,EID,Ename,Eway,Satisfication,FeedBack")] IncidentTask incidentTask)
        {
            incidentTask.EDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(incidentTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(incidentTask);
        }

        // GET: IncidentTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            if (id == null)
            {
                return NotFound();
            }

            var incidentTask = await _context.IncidentTask.FindAsync(id);
            if (incidentTask == null)
            {
                return NotFound();
            }
            return View(incidentTask);
        }

        // POST: IncidentTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ESname,SID,Floor,Department,TableNo,IID,Iname,Category,Description,EDate,Status,SDate,EID,Ename,Eway,Satisfication,FeedBack")] IncidentTask incidentTask)
        {
            if (id != incidentTask.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incidentTask);
                    await _context.SaveChangesAsync();

                    if (incidentTask.Status == "Solved")
                    {
                        incidentTask.SDate = DateTime.Now;
                        var incident = await _context.Incident
                                      .FirstOrDefaultAsync((m => m.ID == incidentTask.IID));
                        if(incident != null)
                        {
                            incident.Count = incident.Count + 1;
                            _context.Update(incident);
                            await _context.SaveChangesAsync();
                        }


                        var staff = await _context.Staff
                                      .FirstOrDefaultAsync((m => m.ID == incidentTask.SID));
                        if (staff != null)
                        {
                            staff.Spoint = staff.Spoint + 100;
                            _context.Update(staff);
                            await _context.SaveChangesAsync();
                        }

                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidentTaskExists(incidentTask.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(incidentTask);
        }


        public async Task<IActionResult> Assign(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            IQueryable<string> TypeQuery = from m in _context.Staff
                                           where m.Role == "Expert" && m.Status == "Active"
                                           orderby m.Sname
                                           select m.Sname;
            IEnumerable<SelectListItem> etype = new SelectList(await TypeQuery.Distinct().ToListAsync());
            ViewBag.EType = etype;
            var incidentTask = await _context.IncidentTask.FindAsync(id);
            if (incidentTask == null)
            {
                return NotFound();
            }
            return View(incidentTask);
        }

        // POST: IncidentTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Assign(int id, [Bind("ID,ESname,SID,Floor,Department,TableNo,IID,Iname,Category,Description,EDate,Status,SDate,EID,Ename,Eway,Satisfication,FeedBack")] IncidentTask incidentTask)
        {
            if (id != incidentTask.ID)
            {
                return NotFound();
            }
           
            if (ModelState.IsValid)
            {
                try
                {
                    var expert = await _context.Staff
                                      .FirstOrDefaultAsync((m => m.Sname == incidentTask.Ename));

                    incidentTask.EID = expert.ID;

                    _context.Update(incidentTask);
                    await _context.SaveChangesAsync();

                    if (incidentTask.Status == "Solved")
                    {
                        incidentTask.SDate = DateTime.Now;
                        var incident = await _context.Incident
                                      .FirstOrDefaultAsync((m => m.ID == incidentTask.IID));
                        if (incident != null)
                        {
                            incident.Count = incident.Count + 1;
                            _context.Update(incident);
                            await _context.SaveChangesAsync();
                        }

                        var staff = await _context.Staff
                                      .FirstOrDefaultAsync((m => m.ID.ToString() == incidentTask.SID.ToString()));
                        if (staff != null)
                        {
                            staff.Spoint = staff.Spoint + 100;
                            _context.Update(staff);
                            await _context.SaveChangesAsync();
                        }

                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidentTaskExists(incidentTask.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(incidentTask);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Satisfy(int id, [Bind("ID,ESname,SID,Floor,Department,TableNo,IID,Iname,Category,Description,EDate,Status,SDate,EID,Ename,Eway,Satisfication,FeedBack")] IncidentTask incidentTask)
        {
            if (id != incidentTask.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incidentTask);
                    await _context.SaveChangesAsync();

                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidentTaskExists(incidentTask.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(incidentTask);
        }
        // GET: IncidentTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            if (id == null)
            {
                return NotFound();
            }

            var incidentTask = await _context.IncidentTask
                .FirstOrDefaultAsync(m => m.ID == id);
            if (incidentTask == null)
            {
                return NotFound();
            }

            return View(incidentTask);
        }

        // POST: IncidentTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incidentTask = await _context.IncidentTask.FindAsync(id);
            _context.IncidentTask.Remove(incidentTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncidentTaskExists(int id)
        {
            return _context.IncidentTask.Any(e => e.ID == id);
        }
    }
}
