using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TraineesDbT.DataAccessRepos;
using TraineesDbT.Models;

namespace TraineesDbT.Controllers
{
    [Authorize]
    public class TracksController : Controller
    {
        private readonly IRepository<Track> _trackRepository;

        public TracksController(IRepository<Track> trackRepository)
        {
            _trackRepository = trackRepository;
        }


        // GET: Tracks
        public IActionResult Index()
        {
            return View(_trackRepository.GetAll());
        }

        // GET: Tracks/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = _trackRepository.GetDetails(id);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // GET: Tracks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tracks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description")] Track track)
        {
            if (ModelState.IsValid)
            {
                _trackRepository.Insert(track);
                return RedirectToAction(nameof(Index));
            }
            return View(track);
        }

        // GET: Tracks/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = _trackRepository.GetDetails(id);
            if (track == null)
            {
                return NotFound();
            }
            return View(track);
        }

        // POST: Tracks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description")] Track track)
        {
            if (id != track.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _trackRepository.Update(id, track);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrackExists(track.Id))
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
            return View(track);
        }

        // GET: Tracks/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = _trackRepository.GetDetails(id);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // POST: Tracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _trackRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TrackExists(int id)
        {
          return _trackRepository.GetDetails(id) is not null;
        }
    }
}
