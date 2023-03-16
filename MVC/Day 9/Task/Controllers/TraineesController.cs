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
    public class TraineesController : Controller
    {
        private readonly IRepository<Trainee> _traineeRepository;
        private readonly IRepository<Track> _trackRepository;

        public TraineesController(IRepository<Trainee> traineeRepository, IRepository<Track> trackRepository)
        {
            _traineeRepository = traineeRepository;
            _trackRepository = trackRepository;
        }

        // GET: Trainees
        public IActionResult Index()
        {
            ViewData["TrackId"] = new SelectList(_trackRepository.GetAll(), "Id", "Name");
            return  View(_traineeRepository.GetAll());
        }

        // GET: Trainees/Details/5
        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var trainee = _traineeRepository.GetDetails(id);

            if (trainee is null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // GET: Trainees/Create
        public IActionResult Create()
        {
            ViewData["TrackId"] = new SelectList(_trackRepository.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Trainees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Gender,Email,Phone,Birthdate,TrackId")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                _traineeRepository.Insert(trainee);
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrackId"] = new SelectList(_trackRepository.GetAll(), "Id", "Name", trainee.TrackId);
            return View(trainee);
        }

        // GET: Trainees/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var trainee = _traineeRepository.GetDetails(id);
            if (trainee is null)
            {
                return NotFound();
            }
            ViewData["TrackId"] = new SelectList(_trackRepository.GetAll(), "Id", "Name", trainee.TrackId);
            return View(trainee);
        }

        // POST: Trainees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Gender,Email,Phone,Birthdate,TrackId")] Trainee trainee)
        {
            if (id != trainee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _traineeRepository.Update(id, trainee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraineeExists(trainee.Id))
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
            ViewData["TrackId"] = new SelectList(_trackRepository.GetAll(), "Id", "Name", trainee.TrackId);
            return View(trainee);
        }

        // GET: Trainees/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var trainee = _traineeRepository.GetDetails(id);
            if (trainee is null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // POST: Trainees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _traineeRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TraineeExists(int id)
        {
          return _traineeRepository.GetDetails(id) is not null;
        }
    }
}
