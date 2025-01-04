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
    public class FightsController : Controller
    {
        private readonly dbstorage _storage;

        public FightsController(dbstorage storage)
        {
            _storage = storage;
        }

        // GET: Fights
        public async Task<IActionResult> Index()
        {
            var fight = await _storage.GetFightAsync();
            return View(fight);
        }

        // GET: Fights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fight = await _storage.GetFightByIdAsync(id.Value);
            if (fight == null)
            {
                return NotFound();
            }

            return View(fight);
        }

        // GET: Fights/Create
        public async Task<IActionResult> CreateAsync()
        {
            var tournament = await _storage.GetTournamentAsync();
            ViewData["TournamentID"] = new SelectList(tournament, "TournamentID", "TournamentID");
            return View();
        }

        // POST: Fights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FightID,TournamentID,DateOfFight,BattleResult")] Fight fight)
        {
            if (ModelState.IsValid)
            {
                await _storage.AddFightAsync(fight);
                return RedirectToAction(nameof(Index));
            }
            var tournament = await _storage.GetTournamentAsync();
            ViewData["TournamentID"] = new SelectList(tournament, "TournamentID", "TournamentID");
            return View(fight);
        }

        // GET: Fights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fight = await _storage.GetFightByIdAsync(id.Value);
            if (fight == null)
            {
                return NotFound();
            }
            var tournament = await _storage.GetTournamentAsync();
            ViewData["TournamentID"] = new SelectList(tournament, "TournamentID", "TournamentID");
            return View(fight);
        }

        // POST: Fights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FightID,TournamentID,DateOfFight,BattleResult")] Fight fight)
        {
            if (id != fight.FightID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _storage.UpdateFightAsync(fight);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _storage.FightExistsAsync(fight.FightID))
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
            var tournament = await _storage.GetTournamentAsync();
            ViewData["TournamentID"] = new SelectList(tournament, "TournamentID", "TournamentID");
            return View(fight);
        }

        // GET: Fights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportsman = await _storage.GetFightByIdAsync(id.Value);
            if (sportsman == null)
            {
                return NotFound();
            }

            await _storage.DeleteFightAsync(id.Value);
            return RedirectToAction(nameof(Index));
        }
    }
}
