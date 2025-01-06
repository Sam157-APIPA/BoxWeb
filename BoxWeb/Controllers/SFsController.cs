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
    public class SFsController : Controller
    {
        private readonly dbstorage _storage;

        public SFsController(dbstorage storage)
        {
            _storage = storage;
        }

        // GET: SFs
        public async Task<IActionResult> Index()
        {
            var sf = await _storage.GetSFAsync();
            return View(sf);
        }

        // GET: SFs/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sf = await _storage.GetSFByIdAsync(id.Value);
            if (sf == null)
            {
                return NotFound();
            }

            return View(sf);
        }

        // GET: SFs/Create
        public async Task<IActionResult> CreateAsync()
        {
            var fight = await _storage.GetFightAsync();
            ViewData["FightID"] = new SelectList(fight, "FightID", "FightID");
            var sportsman = await _storage.GetSportsmanAsync();
            ViewData["SportsmanID"] = new SelectList(sportsman, "SportsmanID", "SportsmanID");
            return View();
        }

        // POST: SFs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FightID,SportsmanID")] SF sF)
        {
            if (ModelState.IsValid)
           {
                await _storage.AddSFAsync(sF);
                return RedirectToAction(nameof(Index));
           }
            var fight = await _storage.GetFightAsync();
            ViewData["FightID"] = new SelectList(fight, "FightID", "FightID");
            var sportsman = await _storage.GetSportsmanAsync();
            ViewData["SportsmanID"] = new SelectList(sportsman, "SportsmanID", "SportsmanID");
            return View(sF);
        }

        // GET: SFs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sF = await _storage.GetSFByIdAsync(id.Value);
            if (sF == null)
            {
                return NotFound();
            }
            var fight = await _storage.GetFightAsync();
            ViewData["FightID"] = new SelectList(fight, "FightID", "FightID");
            var sportsman = await _storage.GetSportsmanAsync();
            ViewData["SportsmanID"] = new SelectList(sportsman, "SportsmanID", "SportsmanID");
            return View(sF);
        }

        // POST: SFs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FightID,SportsmanID")] SF sF)
        {
            if (id != sF.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _storage.UpdateSFAsync(sF);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _storage.SFExistsAsync(sF.ID))
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
            var fight = await _storage.GetFightAsync();
            ViewData["FightID"] = new SelectList(fight, "FightID", "FightID");
            var sportsman = await _storage.GetSportsmanAsync();
            ViewData["SportsmanID"] = new SelectList(sportsman, "SportsmanID", "SportsmanID");
            return View(sF);
        }

        // GET: SFs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sf = await _storage.GetSFByIdAsync(id.Value);
            if (sf == null)
            {
                return NotFound();
            }

            await _storage.DeleteSFAsync(id.Value);
            return RedirectToAction(nameof(Index));
        }
    }
}
