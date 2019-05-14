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
    public class StaffsController : Controller
    {
        private readonly IMSContext _context;

        public StaffsController(IMSContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View("Login", "");
        }

        //Put staff into a list
        public IList<Staff> Staff { get; set; }
        //Get staff from the List
        public SelectList Types { get; set; }
        //Filter staff by search "paging"
        public string SearchString { get; set; }

        // GET: Staffs
        public async Task<IActionResult> Index(string searchString, string RType, string DType, string SType)
        {
            //  return View(await _context.Staff.ToListAsync());

            var staff = from m in _context.Staff
                        select m;
            //Get staff by Role
            IQueryable<string> TypeQuery = from m in _context.Staff
                                           orderby m.Role
                                           select m.Role;
            //Get staff by Department
            IQueryable<string> TypeQuery2 = from m in _context.Staff
                                           orderby m.Department
                                           select m.Department;
            //Get staff by Status
            IQueryable<string> TypeQuery3 = from m in _context.Staff
                                            orderby m.Status
                                            select m.Status;

            if (!string.IsNullOrEmpty(searchString))
            {
                staff = staff.Where(s => s.Sname.Contains(searchString) || s.IC.ToString().Contains(searchString) || s.MobileNo.ToString().Contains(searchString) || s.Username.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(RType))
            {
                staff = staff.Where(x => x.Role == RType);
            }

            if (!string.IsNullOrEmpty(DType))
            {
                staff = staff.Where(x => x.Department == DType);
            }

            if (!string.IsNullOrEmpty(SType))
            {
                staff = staff.Where(x => x.Status == SType);
            }

            IEnumerable<SelectListItem> rtype = new SelectList(await TypeQuery.Distinct().ToListAsync());
            ViewBag.RType = rtype;
            IEnumerable<SelectListItem> dtype = new SelectList(await TypeQuery2.Distinct().ToListAsync());
            ViewBag.DType = dtype;
            IEnumerable<SelectListItem> stype = new SelectList(await TypeQuery3.Distinct().ToListAsync());
            ViewBag.SType = stype;

            Staff = await staff.ToListAsync();

            //var staffDetail = await _context.Staff
            //   .FirstOrDefaultAsync(m => m.ID == id);


            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            //TempData["ID"] = staffDetail.ID;
            //TempData["Name"] = staffDetail.Sname;
            //TempData["Role"] = staffDetail.Role;
            return View(Staff);
        }



        // GET: Staffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .FirstOrDefaultAsync(m => m.ID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }
        
        // GET: Staffs/Create
        public async Task<IActionResult> Create()
        {

            var currentStaffID = await _context.Staff
                .OrderByDescending(m => m.ID)
               .FirstOrDefaultAsync();
           var csID = currentStaffID.ID + 1;

            HttpContext.Session.SetString("StaffCurrentID", csID.ToString());
            ViewBag.StaffCurrentID = HttpContext.Session.GetString("StaffCurrentID");
            
            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            return View();
        }

       

        // POST: Staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Sname,IC,Designation,Gender,DOB,Address,Postcode,City,State,Country,MobileNo,Email,Role,Floor,Department,TableNo,Status,Spoint,JoinedDate,Username,Pass")] Staff staff)
        {
            Boolean Validate = true;
            var userToVerify = await _context.Staff.SingleOrDefaultAsync(s => s.Username == staff.Username);
            if(userToVerify != null) {
                Validate = true;
            }
            else
            {
                Validate = false;
            }
            if (Validate)
            {
                ModelState.AddModelError("Error", "Username Already Exits");
                return View();
            }
            else if (ModelState.IsValid)
            {
                staff.JoinedDate = DateTime.Now.Date;
                DateTime.Now.Date.ToString("MM / dd / yyyy");
                _context.Add(staff);
                await _context.SaveChangesAsync();

                ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
                ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
                ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");

                //TempData["ID"] = staffDetail.ID;
                //TempData["Name"] = staffDetail.Sname;
                //TempData["Role"] = staffDetail.Role;

                return RedirectToAction("Index", "Staffs");
            }
            return View(staff);
        }

        // GET: Staffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            var staffDetail = await _context.Staff
               .FirstOrDefaultAsync(m => m.ID == id);
            TempData["Name"] = staffDetail.Sname;
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Sname,IC,Designation,Gender,DOB,Address,Postcode,City,State,Country,MobileNo,Email,Role,Floor,Department,TableNo,Status,Spoint,JoinedDate,Username,Pass")] Staff staff)
        {
            if (id != staff.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
                ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
                ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
                if (HttpContext.Session.GetString("StaffRole") == "Admin")
                {
                    return RedirectToAction("Index", "Staffs");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(staff);
        }

        // GET: Staffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .FirstOrDefaultAsync(m => m.ID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewBag.StaffID = HttpContext.Session.GetString("StaffID");
            ViewBag.StaffName = HttpContext.Session.GetString("StaffName");
            ViewBag.StaffRole = HttpContext.Session.GetString("StaffRole");

            Boolean Validate = true;
            var userActive = await _context.Staff.FindAsync(id);
            if (userActive.Status == "Active")
            {
                Validate = true;
            }
            else
            {
                Validate = false;
            }
            if (Validate)
            {
                var staff = await _context.Staff.FindAsync(id);
                ModelState.AddModelError("ErrorDelete", "Staff is Active, Unable to delete");
                return View(staff);
            }
            else
            {
                var staff = await _context.Staff.FindAsync(id);
                _context.Staff.Remove(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }

        private bool StaffExists(int id)
        {
            return _context.Staff.Any(e => e.ID == id);
        }
    }
}
