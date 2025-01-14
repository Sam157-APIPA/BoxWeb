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
    public class ClubsController : Controller
    {
        private readonly dbstorage _storage;

        public ClubsController(dbstorage storage)
        {
            _storage = storage;
        }

        // GET: Clubs
        public async Task<IActionResult> Index()
        {
            var clubs = await _storage.GetClubAsync();
            return View(clubs);
        }

        // GET: Clubs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _storage.GetClubByIdAsync(id.Value);
            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }

        // GET: Clubs/Create
        public IActionResult Create()
        {
            var imageFiles = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images"))
                                      .Select(Path.GetFileName)
                                      .ToList();
            ViewData["Images"] = imageFiles;
            return View();
        }

        // POST: Clubs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClubID,ClubName,ImagePath")] Club club, IFormFile? picture)
        {
            if (ModelState.IsValid)
            {
                //if (picture == null)
                //{
                //    Console.WriteLine("No file\n");
                //}
                //else
                //{
                //     Console.WriteLine($"file get{picture.FileName}\n");
                //}
                if (picture != null )
                {
                    var filekName = _storage.SaveFile(picture);
                    club.ImagePath = filekName;
                }
                await _storage.AddClubAsync(club);
                return RedirectToAction(nameof(Index));
            }

            var imageFiles = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images"))
                                     .Select(Path.GetFileName)
                                     .ToList();
            ViewData["Images"] = imageFiles;

            return View(club);
        }

        // GET: Clubs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _storage.GetClubByIdAsync(id.Value);
            if (club == null)
            {
                return NotFound();
            }

            var imageFiles = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images"))
                                      .Select(Path.GetFileName)
                                      .ToList();
            ViewData["Images"] = imageFiles;

            return View(club);
        }

        // POST: Clubs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClubID,ClubName, ImagePath")] Club club, IFormFile? picture)
        {
            if (id != club.ClubID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (picture != null)
                {
                    var filekName = _storage.SaveFile(picture);
                    club.ImagePath = filekName;
                }
                try
                {
                    await _storage.UpdateClubAsync(club);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _storage.ClubExistsAsync(club.ClubID))
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

            var imageFiles = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images"))
                                      .Select(Path.GetFileName)
                                      .ToList();
            ViewData["Images"] = imageFiles;
            
            return View(club);
        }

        // GET: Clubs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _storage.GetClubByIdAsync(id.Value);
            if (club == null)
            {
                return NotFound();
            }

            await _storage.DeleteClubAsync(id.Value);
            return RedirectToAction(nameof(Index));
        }
    }
}
