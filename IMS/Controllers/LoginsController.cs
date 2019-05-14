using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
namespace IMS.Views
{
    public class LoginsController : Controller
    {
        private readonly IMSContext _context;

        public LoginsController(IMSContext context)
        {
            _context = context;
        }

        // GET: Logins
        public async Task<IActionResult> Index()
        {
            return View(await _context.Login.ToListAsync());
        }

        // GET: Logins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Login
                .FirstOrDefaultAsync(m => m.ID == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // GET: Logins/Create
        public IActionResult Login()
        {
           
            return View();
        }

        // POST: Logins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("ID,Username,Pass")] Staff staff)
        {
            Boolean Validate = true;
            var userToVerify = await _context.Staff.SingleOrDefaultAsync(s => s.Username == staff.Username && s.Pass == staff.Pass);
            if (userToVerify != null)
            {
                Validate = true;
            }
            else
            {
                Validate = false;
            }
            if (!Validate)
            {
                ModelState.AddModelError("Error", "Incorrect Username or Password");
                return View();
            }
            else if (ModelState.IsValid)
            {
                var staffDetail = await _context.Staff
               .FirstOrDefaultAsync(m => m.Username == staff.Username);

                HttpContext.Session.SetString("StaffID", staffDetail.ID.ToString());
                HttpContext.Session.SetString("StaffName", staffDetail.Sname);
                HttpContext.Session.SetString("StaffRole", staffDetail.Role);
                HttpContext.Session.SetString("StaffFloor", staffDetail.Floor);
                HttpContext.Session.SetString("StaffDepartment", staffDetail.Department);
                HttpContext.Session.SetString("StaffTable", staffDetail.TableNo);

                //TempData["ID"] = staffDetail.ID;
                //TempData["Name"] = staffDetail.Sname;
                //TempData["Role"] = staffDetail.Role;
                //return View(staffDetail);
                //return View("~/Views/Home/Index.cshtml", TempData);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Logins");
        }
        // GET: Logins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Login.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }
            return View(login);
        }

        // POST: Logins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Username,Pass")] Login login)
        {
            if (id != login.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(login);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginExists(login.ID))
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
            return View(login);
        }

        // GET: Logins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Login
                .FirstOrDefaultAsync(m => m.ID == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // POST: Logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var login = await _context.Login.FindAsync(id);
            _context.Login.Remove(login);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginExists(int id)
        {
            return _context.Login.Any(e => e.ID == id);
        }
    }
}
