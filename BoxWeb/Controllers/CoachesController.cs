using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConsoleApp1;
using BoxWeb.Data;

namespace BoxWeb.Controllers
{
    public class CoachesController : Controller
    {
        private readonly dbstorage _storage;

        public CoachesController(dbstorage storage)
        {
            _storage = storage;
        }

        // GET: Coaches
        public async Task<IActionResult> Index()
        {
            var coaches = await _storage.GetCoachAsync();
            return View(coaches);
        }

        // GET: Coaches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _storage.GetCoachByIdAsync(id.Value);
            if (coach == null)
            {
                return NotFound();
            }

            return View(coach);
        }

        // GET: Coaches/Create
        public async Task<IActionResult> CreateAsync()
        {
            var clubs = await _storage.GetClubAsync();
            ViewData["ClubID"] = new SelectList(clubs, "ClubID", "ClubID");
            return View();
        }

        // POST: Coaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoachID,Name,Surname,PhoneNumber,Adress,BirthsdayDate,ClubID")] Coach coach)
        {
            if (ModelState.IsValid)
            {
                await _storage.AddCoachAsync(coach);
                return RedirectToAction(nameof(Index));
            }

            var clubs = await _storage.GetClubAsync();
            ViewData["ClubID"] = new SelectList(clubs, "ClubID", "ClubID");
            return View(coach);
        }

        // GET: Coaches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _storage.GetCoachByIdAsync(id.Value);
            if (coach == null)
            {
                return NotFound();
            }


            var clubs = await _storage.GetClubAsync();
            ViewData["ClubID"] = new SelectList(clubs, "ClubID", "ClubID");
            return View(coach);
        }

        // POST: Coaches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CoachID,Name,Surname,PhoneNumber,Adress,BirthsdayDate,ClubID")] Coach coach)
        {
            if (id != coach.CoachID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _storage.UpdateCoachAsync(coach);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _storage.ClubExistsAsync(coach.CoachID))
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
            var clubs = await _storage.GetClubAsync();
            ViewData["ClubID"] = new SelectList(clubs, "ClubID", "ClubID");
            return View(coach);
        }

        // GET: Coaches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _storage.GetCoachByIdAsync(id.Value);
            if (coach == null)
            {
                return NotFound();
            }

            await _storage.DeleteCoachAsync(id.Value);
            return RedirectToAction(nameof(Index));
        }
    }
}
