using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DiogoTurismo.Models;

namespace DiogoTurismo.Controllers
{
    public class PassagemsController : Controller
    {
        private readonly BancoDados _context;

        public PassagemsController(BancoDados context)
        {
            _context = context;
        }

        // GET: Passagems
        public async Task<IActionResult> Index()
        {
            var bancoDados = _context.Passagens.Include(p => p.Cadastro).Include(p => p.Destino);
            return View(await bancoDados.ToListAsync());
        }

        // GET: Passagems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passagem = await _context.Passagens
                .Include(p => p.Cadastro)
                .Include(p => p.Destino)
                .FirstOrDefaultAsync(m => m.Id_passagem == id);
            if (passagem == null)
            {
                return NotFound();
            }

            return View(passagem);
        }

        // GET: Passagems/Create
        public IActionResult Create()
        {
            ViewData["CadastroId_cadastro"] = new SelectList(_context.Cadastro, "Id_cadastro", "Nome");
            ViewData["DestinoId_destino"] = new SelectList(_context.Destino, "Id_destino", "Cidade_destino");
            return View();
        }

        // POST: Passagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_passagem,Numero_passaporte,Data_saida,Data_chegada,Horario_saida,Horario_chegada,CadastroId_cadastro,DestinoId_destino")] Passagem passagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CadastroId_cadastro"] = new SelectList(_context.Cadastro, "Id_cadastro", "Nome", passagem.CadastroId_cadastro);
            ViewData["DestinoId_destino"] = new SelectList(_context.Destino, "Id_destino", "Cidade_destino", passagem.DestinoId_destino);
            return View(passagem);
        }

        // GET: Passagems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passagem = await _context.Passagens.FindAsync(id);
            if (passagem == null)
            {
                return NotFound();
            }
            ViewData["CadastroId_cadastro"] = new SelectList(_context.Cadastro, "Id_cadastro", "Nome", passagem.CadastroId_cadastro);
            ViewData["DestinoId_destino"] = new SelectList(_context.Destino, "Id_destino", "Cidade_destino", passagem.DestinoId_destino);
            return View(passagem);
        }

        // POST: Passagems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_passagem,Numero_passaporte,Data_saida,Data_chegada,Horario_saida,Horario_chegada,CadastroId_cadastro,DestinoId_destino")] Passagem passagem)
        {
            if (id != passagem.Id_passagem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassagemExists(passagem.Id_passagem))
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
            ViewData["CadastroId_cadastro"] = new SelectList(_context.Cadastro, "Id_cadastro", "Nome", passagem.CadastroId_cadastro);
            ViewData["DestinoId_destino"] = new SelectList(_context.Destino, "Id_destino", "Cidade_destino", passagem.DestinoId_destino);
            return View(passagem);
        }

        // GET: Passagems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passagem = await _context.Passagens
                .Include(p => p.Cadastro)
                .Include(p => p.Destino)
                .FirstOrDefaultAsync(m => m.Id_passagem == id);
            if (passagem == null)
            {
                return NotFound();
            }

            return View(passagem);
        }

        // POST: Passagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passagem = await _context.Passagens.FindAsync(id);
            _context.Passagens.Remove(passagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassagemExists(int id)
        {
            return _context.Passagens.Any(e => e.Id_passagem == id);
        }
    }
}
