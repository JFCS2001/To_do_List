using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using To_do_List.Models;

namespace To_do_List.Controllers
{
    public class Controllers : Controller
    {
        private readonly Context _context;

        public Controllers(Context context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View(_context.Tasks);
        }

        // GET: Tasks
        public async Task<IActionResult> Tasks()
        {
            var tasks = await _context.Tasks.Include(t => t.Status_Task).ToListAsync();
            return View(tasks);
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var task = await _context.Tasks
                .Include(t => t.Status_Task)
                .FirstOrDefaultAsync(m => m.Id_Task == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        //Get: Tasks/Create
        public IActionResult Create()
        {
            ViewData["Id_Status_Task"] = new SelectList(_context.Status_Tasks, "Id_Status_Task", "Name_Status_Task");
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Task,Name_Task,Description_Task,Time,Id_Status_Task")] Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Status_Task"] = new SelectList(_context.Status_Tasks, "Id_Status_Task", "Name_Status_Task", task.Id_Status_Task);
            return View(task);
        }

        // GET: Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            ViewData["Id_Status_Task"] = new SelectList(_context.Status_Tasks, "Id_Status_Task", "Name_Status_Task", task.Id_Status_Task);
            return View(task);
        }

        // DELETE: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
