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
    public class TournamentsController : Controller
    {
        private readonly dbstorage _storage;

        public TournamentsController(dbstorage storage)
        {
            _storage = storage;
        }

        // GET: Tournaments
        public async Task<IActionResult> Index()
        {
            var tournament = await _storage.GetTournamentAsync();
            return View(tournament);
        }

        // GET: Tournaments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournament = await _storage.GetTournamentByIdAsync(id.Value);
            if (tournament == null)
            {
                return NotFound();
            }

            return View(tournament);
        }

        // GET: Tournaments/Create
        public async Task<IActionResult> CreateAsync()
        {
            var refeeres = await _storage.GetRefeereAsync();
            ViewData["RefeereID"] = new SelectList(refeeres, "RefeereID", "RefeereID");
            return View();
        }

        // POST: Tournaments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TournamentID,RefeereID,Name,Adress,Year,StartDate,EndDate")] Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                    await _storage.AddTournamentAsync(tournament);
                    return RedirectToAction(nameof(Index));
            }

            var refeeres = await _storage.GetRefeereAsync();
            ViewData["RefeereID"] = new SelectList(refeeres, "RefeereID", "RefeereID");
            return View(tournament);
        }

        // GET: Tournaments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournament = await _storage.GetTournamentByIdAsync(id.Value);
            if (tournament == null)
            {
                return NotFound();
            }
            var refeeres = await _storage.GetRefeereAsync();
            ViewData["RefeereID"] = new SelectList(refeeres, "RefeereID", "RefeereID");
            return View(tournament);
        }

        // POST: Tournaments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TournamentID,RefeereID,Name,Adress,Year,StartDate,EndDate")] Tournament tournament)
        {

            if (id != tournament.TournamentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _storage.UpdateTournamentAsync(tournament);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _storage.SportsmanExistsAsync(tournament.TournamentID))
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
            var refeeres = await _storage.GetRefeereAsync();
            ViewData["RefeereID"] = new SelectList(refeeres, "RefeereID", "RefeereID");
            return View(tournament);
        }

        // GET: Tournaments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportsman = await _storage.GetTournamentByIdAsync(id.Value);
            if (sportsman == null)
            {
                return NotFound();
            }

            await _storage.DeleteTournamentAsync(id.Value);
            return RedirectToAction(nameof(Index));
        }
    }
}
