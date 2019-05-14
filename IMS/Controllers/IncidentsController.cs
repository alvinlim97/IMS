using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IMS.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace IMS.Views
{
    public class IncidentsController : Controller
    {
        private readonly IMSContext _context;

        public IncidentsController(IMSContext context)
        {
            _context = context;
        }
        //Put staff into a list
        public IList<Incident> Incident { get; set; }
        //Get staff from the List
        public SelectList Types { get; set; }
        //Filter staff by search "paging"
        public string SearchString { get; set; }
        // GET: Incidents
        public async Task<IActionResult> Index(string searchString, string CType, string SType)
        {
            var incident = from m in _context.Incident
                        select m;
            IQueryable<string> TypeQuery = from m in _context.Incident
                                           orderby m.Category
                                           select m.Category;
            IQueryable<string> TypeQuery2 = from m in _context.Incident
                                            orderby m.Status
                                            select m.Status;

            if (!string.IsNullOrEmpty(searchString))
            {
                incident = incident.Where(s => s.Iname.Contains(searchString) || s.Category.Contains(searchString) || s.Description.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(CType))
            {
                incident = incident.Where(x => x.Category == CType);
            }

            if (!string.IsNullOrEmpty(SType))
            {
                incident = incident.Where(x => x.Status == SType);
            }

            IEnumerable<SelectListItem> ctype = new SelectList(await TypeQuery.Distinct().ToListAsync());
            ViewBag.CType = ctype;
            IEnumerable<SelectListItem> stype = new SelectList(await TypeQuery2.Distinct().ToListAsync());
            ViewBag.SType = stype;

            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            ViewBag.Testbobo = HttpContext.Session.GetString("Testbobo");
            return View(await incident.OrderByDescending(s => s.Count).ToListAsync());
        }

        public IActionResult AddIncidentManual()
        {
            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            
            ViewBag.ManualName = HttpContext.Session.GetString("ManualName");
            ViewBag.ManualCategory = HttpContext.Session.GetString("ManualCategory");
            ViewBag.ManualDescription = HttpContext.Session.GetString("ManualDescription");
            ViewBag.ManualID = HttpContext.Session.GetString("ManualID");
            ViewBag.Testbobo = HttpContext.Session.GetString("Testbobo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddIncidentManual([Bind("ID,Iname,Category,Description,Solution,Images,Videos,Date,Status,Count")] Incident incident, List<IFormFile> Images, List<IFormFile> Videos)
        {
            var currentIncidentID = await _context.Incident
              .OrderByDescending(m => m.ID)
             .FirstOrDefaultAsync();
            var ciID = currentIncidentID.ID + 1;
            var IID = HttpContext.Session.GetString("ManualID");
            foreach (var item in Images)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        incident.Images = stream.ToArray();
                    }
                }
            }

            foreach (var item in Videos)
            {
                if (item.Length > 0)
                {
                    using (var stream1 = new MemoryStream())
                    {
                        await item.CopyToAsync(stream1);
                        incident.Videos = stream1.ToArray();
                    }
                }
            }

            if (ModelState.IsValid)
            {
                
                    incident.ID = ciID;
                    DateTime.Now.Date.ToString("MM / dd / yyyy");
                    _context.Add(incident);
                    await _context.SaveChangesAsync();


                    var incidentss = await _context.IncidentTask
                                  .FirstOrDefaultAsync((m => m.ID.ToString() == HttpContext.Session.GetString("ManualID")));

                    if (incidentss != null)
                    {
                        incidentss.IID = ciID;
                        incidentss.Eway = "Auto";
                        _context.Update(incidentss);
                        await _context.SaveChangesAsync();
                    }
                
                return RedirectToAction(nameof(Index));
            }

            return View(incident);
        }
        // GET: Incidents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            if (id == null)
            {
                return NotFound();
            }
            var incident = await _context.Incident
                .FirstOrDefaultAsync(m => m.ID == id);
            
            HttpContext.Session.SetString("IncidentIDTemp", incident.ID.ToString());
            ViewBag.IncidentIDTemp = HttpContext.Session.GetString("IncidentIDTemp");
         
            if (incident.Images != null)
            {
                ViewData["image"] = Convert.ToBase64String(incident.Images);
            }
            if (incident.Videos != null)
            {
                ViewData["video"] = Convert.ToBase64String(incident.Videos);
            }
            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
        }

        // GET: Incidents/Create
        public IActionResult Create()
        {
            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            //var incident = await _context.Incident
            //  .FirstOrDefaultAsync(m => m.ID == id);
            //HttpContext.Session.SetString("IncidentID", incident.ID.ToString());
            //HttpContext.Session.SetString("IncidentName", incident.Iname);
            //HttpContext.Session.SetString("IncidentCategory", incident.Category);
            //HttpContext.Session.SetString("IncidentDescription", incident.Description);

            //ViewBag.IncidentID = HttpContext.Session.GetString("IncidentID");
            //ViewBag.IncidentName = HttpContext.Session.GetString("IncidentName");
            //ViewBag.IncidentCategory = HttpContext.Session.GetString("IncidentCategory");
            //ViewBag.IncidentDescription = HttpContext.Session.GetString("IncidentDescription");

            return View();
        }

        // POST: Incidents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Iname,Category,Description,Solution,Images,Videos,Date,Status,Count")] Incident incident, List<IFormFile> Images, List<IFormFile> Videos)
        {

            foreach (var item in Images)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        incident.Images = stream.ToArray();
                    }
                }
            }

            foreach (var item in Videos)
            {
                if (item.Length > 0)
                {
                    using (var stream1 = new MemoryStream())
                    {
                        await item.CopyToAsync(stream1);
                        incident.Videos = stream1.ToArray();
                    }
                }
            }
            if (ModelState.IsValid)
            {
                DateTime.Now.Date.ToString("MM / dd / yyyy");
                _context.Add(incident);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(incident);
        }

        // GET: Incidents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incident.FindAsync(id);
            if (incident == null)
            {
                return NotFound();
            }
            if(incident.Images != null){
                ViewData["image"] = Convert.ToBase64String(incident.Images);
            }
            else 
            {
                HttpContext.Session.SetString("EmptyImage", "EmptyImage");
                ViewBag.EmptyImage = HttpContext.Session.GetString("EmptyImage");
            }
           
            if (incident.Videos != null)
            {
                ViewData["video"] = Convert.ToBase64String(incident.Videos);
            }
            else
            {
                HttpContext.Session.SetString("EmptyVideo", "EmptyVideo");
                ViewBag.EmptyImage = HttpContext.Session.GetString("EmptyVideo");
            }
            return View(incident);
        }

        // POST: Incidents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Iname,Category,Description,Solution,Images,Videos,Date,Status,Count")] Incident incident, List<IFormFile> Images, List<IFormFile> Videos)
        {
            if (id != incident.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var item in Images)
                    {
                        if (item.Length > 0)
                        {
                            using (var stream = new MemoryStream())
                            {
                                await item.CopyToAsync(stream);
                                incident.Images = stream.ToArray();
                            }
                        }
                    }

                    foreach (var item in Videos)
                    {
                        if (item.Length > 0)
                        {
                            using (var stream1 = new MemoryStream())
                            {
                                await item.CopyToAsync(stream1);
                                incident.Videos = stream1.ToArray();
                            }
                        }
                    }
                    _context.Update(incident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidentExists(incident.ID))
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
            return View(incident);
        }

        // GET: Incidents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incident
                .FirstOrDefaultAsync(m => m.ID == id);
            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
        }

        // POST: Incidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incident = await _context.Incident.FindAsync(id);
            _context.Incident.Remove(incident);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncidentExists(int id)
        {
            return _context.Incident.Any(e => e.ID == id);
        }
    }
}
