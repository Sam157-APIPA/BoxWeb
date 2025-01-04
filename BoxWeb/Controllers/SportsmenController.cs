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
    public class SportsmenController : Controller
    {
        private readonly dbstorage _storage;

        public SportsmenController(dbstorage storage)
        {
            _storage = storage;
        }

        // GET: Sportsmen
        public async Task<IActionResult> Index()
        {
            var sportsmen = await _storage.GetSportsmanAsync();
            return View(sportsmen);
        }

        // GET: Sportsmen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportsmen = await _storage.GetSportsmanByIdAsync(id.Value);
            if (sportsmen == null)
            {
                return NotFound();
            }

            return View(sportsmen);
        }

        // GET: Sportsmen/Create
        public async Task<IActionResult> CreateAsync()
        {
            var clubs = await _storage.GetClubAsync();
            ViewData["ClubID"] = new SelectList(clubs, "ClubID", "ClubID");
            return View();
        }

        // POST: Sportsmen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SportsmanID,Name,Surname,PhoneNumber,Adress,BirthsdayDate,ClubID,WeightCategory,Achivments,AgeGroup")] Sportsman sportsman)
        {
            if (ModelState.IsValid)
            {
                await _storage.AddSportsmanAsync(sportsman);
                return RedirectToAction(nameof(Index));
            }

            var clubs = await _storage.GetClubAsync();
            ViewData["ClubID"] = new SelectList(clubs, "ClubID", "ClubID");
            return View(sportsman);
        }

        // GET: Sportsmen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportsman = await _storage.GetSportsmanByIdAsync(id.Value);
            if (sportsman == null)
            {
                return NotFound();
            }


            var clubs = await _storage.GetClubAsync();
            ViewData["ClubID"] = new SelectList(clubs, "ClubID", "ClubID");
            return View(sportsman);
        }

        // POST: Sportsmen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SportsmanID,Name,Surname,PhoneNumber,Adress,BirthsdayDate,ClubID,WeightCategory,Achivments,AgeGroup")] Sportsman sportsman)
        {
            if (id != sportsman.SportsmanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _storage.UpdateSportsmanAsync(sportsman);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _storage.SportsmanExistsAsync(sportsman.SportsmanID))
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
            return View(sportsman);
        }

        // GET: Sportsmen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportsman = await _storage.GetSportsmanByIdAsync(id.Value);
            if (sportsman == null)
            {
                return NotFound();
            }

            await _storage.DeleteSportsmanAsync(id.Value);
            return RedirectToAction(nameof(Index));
        }
    }
}
