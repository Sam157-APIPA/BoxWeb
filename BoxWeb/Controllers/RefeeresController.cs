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
    public class RefeeresController : Controller
    {
        private readonly dbstorage _storage;

        public RefeeresController(dbstorage storage)
        {
            _storage = storage;
        }

        // GET: Refeeres
        public async Task<IActionResult> Index()
        {
            var refeeres = await _storage.GetRefeereAsync();
            return View(refeeres);
        }

        // GET: Refeeres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refeere = await _storage.GetRefeereByIdAsync(id.Value);
            if (refeere == null)
            {
                return NotFound();
            }


            return View(refeere);
        }

        // GET: Refeeres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Refeeres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RefeereID,Name,Surname,PhoneNumber,Adress,BirthsdayDate")] Refeere refeere)
        {
            if (ModelState.IsValid)
            {
                await _storage.AddRefeereAsync(refeere);
                return RedirectToAction(nameof(Index));
            }
            return View(refeere);
        }

        // GET: Refeeres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refeere = await _storage.GetRefeereByIdAsync(id.Value);
            if (refeere == null)
            {
                return NotFound();
            }
            return View(refeere);
        }

        // POST: Refeeres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RefeereID,Name,Surname,PhoneNumber,Adress,BirthsdayDate")] Refeere refeere)
        {
            if (id != refeere.RefeereID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _storage.UpdateRefeereAsync(refeere);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _storage.RefeereExistsAsync(refeere.RefeereID))
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
            return View(refeere);
        }

        // GET: Refeeres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refeere = await _storage.GetRefeereByIdAsync(id.Value);
            if (refeere == null)
            {
                return NotFound();
            }

            await _storage.DeleteRefeereAsync(id.Value);
            return RedirectToAction(nameof(Index));
        }
    }
}
