using KindergartenManager.Data;
using KindergartenManager.Models.Kindergarten;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KindergartenManager.Controllers
{
    public class ChildrenController : Controller
    {
        private readonly KindergartenContext _context;

        public ChildrenController(KindergartenContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var children = await _context.Children.Select(c => new ChildDetailsViewModel
            {
                Id = c.Id,
                ChildName = c.ChildName,
                BirthDate = c.BirthDate,
                GroupName = c.GroupName,
                TeacherName = c.TeacherName,
                ParentContactInfo = c.ParentContactInfo,
                CreatedAt = c.CreatedAt,
                ModifiedAt = c.ModifiedAt
            }).ToListAsync();

            var model = new ChildrenIndexViewModel
            {
                Children = children
            };

            return View(model);
        }

        public IActionResult Create()
        {
            return View(new ChildCreateUpdateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ChildCreateUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var child = new Child
                {
                    Id = model.Id ?? Guid.NewGuid(),
                    ChildName = model.ChildName,
                    BirthDate = model.BirthDate,
                    GroupName = model.GroupName,
                    TeacherName = model.TeacherName,
                    ParentContactInfo = model.ParentContactInfo,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now
                };

                _context.Children.Add(child);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var child = await _context.Children.FindAsync(id);
            if (child == null) return NotFound();

            var model = new ChildCreateUpdateViewModel
            {
                Id = child.Id,
                ChildName = child.ChildName,
                BirthDate = child.BirthDate,
                GroupName = child.GroupName,
                TeacherName = child.TeacherName,
                ParentContactInfo = child.ParentContactInfo,
                CreatedAt = child.CreatedAt,
                ModifiedAt = child.ModifiedAt
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ChildCreateUpdateViewModel model)
        {
            if (id != model.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var child = await _context.Children.FindAsync(id);
                if (child == null) return NotFound();

                child.ChildName = model.ChildName;
                child.BirthDate = model.BirthDate;
                child.GroupName = model.GroupName;
                child.TeacherName = model.TeacherName;
                child.ParentContactInfo = model.ParentContactInfo;
                child.ModifiedAt = DateTime.Now;

                _context.Update(child);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var child = await _context.Children.FindAsync(id);
            if (child == null) return NotFound();

            var model = new ChildDeleteViewModel
            {
                Id = child.Id,
                ChildName = child.ChildName,
                BirthDate = child.BirthDate
            };

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var child = await _context.Children.FindAsync(id);
            if (child != null)
            {
                _context.Children.Remove(child);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var child = await _context.Children.FindAsync(id);
            if (child == null) return NotFound();

            var model = new ChildDetailsViewModel
            {
                Id = child.Id,
                ChildName = child.ChildName,
                BirthDate = child.BirthDate,
                GroupName = child.GroupName,
                TeacherName = child.TeacherName,
                ParentContactInfo = child.ParentContactInfo,
                CreatedAt = child.CreatedAt,
                ModifiedAt = child.ModifiedAt
            };

            return View(model);
        }
    }
}
