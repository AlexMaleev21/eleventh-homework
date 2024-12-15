using Dz_11.Data;
using Dz_11.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dz_11.Controllers
{
    public class NoteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NoteController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: NoteController
        public IActionResult Index()
        {
            IEnumerable<Note> notes = _context.Notes;
            return View(notes);
        }

        // GET: NoteController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NoteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                note.CreatedAt = DateTime.Now;
                _context.Notes.Add(note);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(note);
        }

        // GET: NoteController/Edit/5
        public IActionResult Edit(int id)
        {
            var note = _context.Notes.Find(id);

            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // POST: NoteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Note note)
        {
            if (ModelState.IsValid)
            {
                _context.Notes.Update(note);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(note);
        }

        // GET: NoteController/Delete/5
        public IActionResult Delete(int id)
        {
            var note = _context.Notes.Find(id);
            if(note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // POST: NoteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            var note = _context.Notes.Find(id);
            if(note == null)
            {
                return NotFound();
            }
            _context.Notes.Remove(note);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
