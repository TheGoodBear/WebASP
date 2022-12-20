using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVMVC_EF.Data;
using MVMVC_EF.Models;
using MVMVC_EF.ViewModels;

namespace MVMVC_EF.Controllers;

public class GroupController : Controller
{
    private readonly DBContext _context;
    private GroupVM VM;

    public GroupController(DBContext context)
    {
        _context = context;
    }

    // GET: Group
    public async Task<IActionResult> Index()
    {
        VM = new GroupVM(
            _context,
            GroupVM.eView.Index);
        UpdateViewData();

        VM.Entities = _context
            .Group
            .Include(t => t.Project)
            .ToList();

        return View(VM);
    }

    // GET: Group/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        VM = new GroupVM(
           _context,
           GroupVM.eView.Detail);
        VM.IDEntity = id;
        UpdateViewData();

        VM.CurrentEntity = await _context.Group
            .Include(t => t.Project)
            .Include(t => t.Persons)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (id == null || VM.Entities == null || VM.CurrentEntity == null)
        {
            return NotFound();
        }

        return View(VM);
;
    }

    // GET: Group/Create
    public IActionResult Create()
    {
        //VM.ViewData.Add(new Tuple<string, string>(
        //    "IdProject", new SelectList(
        //    _context.Project, "Id", "Name")));

        VM = new GroupVM(
            _context,
            GroupVM.eView.Create);
        UpdateViewData();
        
        ViewData["IdProject"] = new SelectList(
            _context.Project, "Id", "Name");

        return View(VM);
    }

    // POST: Group/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Id,Number,Name,Technology,IdProject","CurrentEntity")] GroupVM CurrentVM)
    {
        if (ModelState.IsValid)
        {
            _context.Add(CurrentVM.CurrentEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        VM = new GroupVM(
            _context,
            GroupVM.eView.Create);
        //UpdateViewData();

        ViewData["IdProject"] = new SelectList(
            _context.Project, "Id", "Name");

        return View(VM);
    }

    // GET: Group/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Group == null)
        {
            return NotFound();
        }

        VM = new GroupVM(
           _context,
           GroupVM.eView.Edit);
        VM.IDEntity = id;
        UpdateViewData();

        ViewData["IdProject"] = new SelectList(
            _context.Project, "Id", "Name", VM.CurrentEntity.IdProject);

        if (VM.CurrentEntity == null)
        {
            return NotFound();
        }
        return View(VM);
    }

    // POST: Group/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id, 
        [Bind("Id,Number,Name,Technology,IdProject", "CurrentEntity")] GroupVM CurrentVM)
    {
        if (id != CurrentVM.CurrentEntity.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(CurrentVM.CurrentEntity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));

        }
        VM = new GroupVM(
           _context,
           GroupVM.eView.Edit);
        VM.IDEntity = id;
        //UpdateViewData();

        ViewData["IdProject"] = new SelectList(
            _context.Project, "Id", "Name", VM.CurrentEntity.IdProject);

        return View(VM);
    }

    // GET: Group/Delete/5
    public async Task<IActionResult> Delete(
        int? id)
    {
        VM = new GroupVM(
           _context,
           GroupVM.eView.Delete);
        VM.IDEntity = id;
        UpdateViewData();

        VM.CurrentEntity = await _context.Group
            .Include(t => t.Project)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (id == null || VM.CurrentEntity == null)
        {
            return NotFound();
        }

        return View(VM);
    }

    // POST: Group/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(
        int id)
    {
        VM = new GroupVM(
           _context,
           GroupVM.eView.Delete);
        VM.IDEntity = id;
        UpdateViewData();

        if (VM.CurrentEntity != null)
        {
            _context.Group.Remove(VM.CurrentEntity);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));

    }

    private void UpdateViewData()
    {
        foreach (Tuple<string, string> VD in VM.ViewData)
            ViewData[VD.Item1] = VD.Item2;
    }
}
