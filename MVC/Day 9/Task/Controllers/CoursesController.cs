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
    public class CoursesController : Controller
    {

        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Track> _trackRepository;

        public CoursesController(IRepository<Course> courseRepo, IRepository<Track> trackRepo)
        {
            _courseRepository = courseRepo;
            _trackRepository = trackRepo;
        }

        // GET: Courses
        public IActionResult Index()
        {
            return View(_courseRepository.GetAll());
        }

        // GET: Courses/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _courseRepository.GetDetails(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewData["TrackId"] = new SelectList(_trackRepository.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Grade,TrackId")] Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepository.Insert(course);
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrackId"] = new SelectList(_trackRepository.GetAll(), "Id", "Name", course.TrackId);
            return View(course);
        }

        // GET: Courses/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _courseRepository.GetDetails(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["TrackId"] = new SelectList(_trackRepository.GetAll(), "Id", "Name", course.TrackId);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Grade,TrackId")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _courseRepository.Update(id, course);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
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
            ViewData["TrackId"] = new SelectList(_trackRepository.GetAll(), "Id", "Name", course.TrackId);
            return View(course);
        }

        // GET: Courses/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _courseRepository.GetDetails(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _courseRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _courseRepository.GetDetails(id) is not null;
        }
    }
}
