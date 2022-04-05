using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Esmane_juhiluba.Data;
using Esmane_juhiluba.Models;

namespace Esmane_juhiluba.Controllers
{
    public class EksamsController : Controller
    {
        private readonly Esmane_juhilubaContext _context;

        public EksamsController(Esmane_juhilubaContext context)
        {
            _context = context;
        }

        public IActionResult Registeeri()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registeeri([Bind("Id,Eesnimi,Perenimi")] Eksam eksam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eksam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eksam);
        }

        public async Task<IActionResult> Teooria()
        {
            var model = _context.Eksam.Where(e => e.Teooria == -1);
            return View(await model.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Teooriatulemus([Bind("Id,Teooria")] Eksam tulemus)
        {
            var eksam = await _context.Eksam.FindAsync(tulemus.Id);
            if (eksam == null)
            {
                return NotFound();
            }
            eksam.Teooria = tulemus.Teooria;
            try
            {
                _context.Update(eksam);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EksamExists(eksam.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return RedirectToAction(nameof(Teooria));
        }

        public async Task<IActionResult> SõiduPäevik()
        {
            var model = _context.Eksam.Where(e => e.Sõidupäevik == -1);
            return View(await model.ToListAsync());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SõidupäevikuTulemus([Bind("Id, Sõidupäevik")] Eksam tulemus)
        {
            var eksam = await _context.Eksam.FindAsync(tulemus.Id);
            if (eksam == null)
            {
                return NotFound();
            }
            eksam.Sõidupäevik = tulemus.Sõidupäevik;
            try
            {
                _context.Update(eksam);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EksamExists(eksam.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return RedirectToAction(nameof(SõiduPäevik));
        }

        public async Task<IActionResult> Sõidu()
        {
            var model = _context.Eksam.Where(e =>e.Teooria >=9 && e.Sõidupäevik >= 24 && e.Sõidu == -1);
            return View(await model.ToListAsync());
        }

        public async Task<IActionResult> PassFail(int Id, string Osa, int Tulemus)
        {
            var eksam = await _context.Eksam.FindAsync(Id);
            if (eksam == null)
            {
                return NotFound();
            }
            switch (Osa)
            {
                case nameof(eksam.Sõidu):
                    {
                        eksam.Sõidu = Tulemus;
                        break;
                    }
                default:
                    {
                        return NotFound();
                    }
            }
            try
            {
                _context.Update(eksam);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EksamExists(eksam.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(Osa);
        }

        public async Task<IActionResult> Luba()
        {
            var model = _context.Eksam.Select(e =>
            new LubaModel()
            {
                Id = e.Id,
                Eesnimi = e.Eesnimi,
                Perenimi = e.Perenimi,
                Teooria = e.Teooria,
                Sõidupäevik = e.Sõidupäevik,
                Sõidu = e.Sõidu == -1 ? "." : e.Sõidu == 1 ? "Õnnestus" : "Põrus",
                Luba = e.Luba == 1 ? "Väljastatud" : e.Sõidu == 1 ? "Väljasta" : "."
            });

            return View(await model.ToListAsync());
        }

        public async Task<IActionResult> VäljastaLuba(int Id)
        {
            var eksam = await _context.Eksam.FindAsync(Id);
            if (eksam == null)
            {
                return NotFound();
            }
            eksam.Luba = 1;
            try
            {
                _context.Update(eksam);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EksamExists(eksam.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Luba");
        }

        // GET: Eksams
        public async Task<IActionResult> Index()
        {
            return View(await _context.Eksam.ToListAsync());
        }
        // GET: Eksams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eksam = await _context.Eksam
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eksam == null)
            {
                return NotFound();
            }

            return View(eksam);
        }

        // GET: Eksams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Eksams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Eesnimi,Perenimi,Teooria,Sõidupäevik,Sõidu,Luba")] Eksam eksam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eksam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eksam);
        }

        // GET: Eksams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eksam = await _context.Eksam.FindAsync(id);
            if (eksam == null)
            {
                return NotFound();
            }
            return View(eksam);
        }

        // POST: Eksams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Eesnimi,Perenimi,Sõidupäevik,Teooria,Sõidu,Luba")] Eksam eksam)
        {
            if (id != eksam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eksam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EksamExists(eksam.Id))
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
            return View(eksam);
        }

        // GET: Eksams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eksam = await _context.Eksam
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eksam == null)
            {
                return NotFound();
            }

            return View(eksam);
        }

        // POST: Eksams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eksam = await _context.Eksam.FindAsync(id);
            _context.Eksam.Remove(eksam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EksamExists(int id)
        {
            return _context.Eksam.Any(e => e.Id == id);
        }
    }
}
