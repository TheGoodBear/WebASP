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

public class ProjectController : Controller
{
    private readonly DBContext _context;
    private ProjectVM VM;

    public ProjectController(DBContext context)
    {
        _context = context;
    }

    // GET: Project/Index
    public async Task<IActionResult> Index()
    {
        VM = new ProjectVM(
            _context, 
            ProjectVM.eView.Index);
        UpdateViewData();
            
        return View(VM);
    }

    // GET: Project/Details/5
    public async Task<IActionResult> Details(
        int? id)
    {
        VM = new ProjectVM(
           _context,
           ProjectVM.eView.Detail);
        VM.IDEntity = id;
        UpdateViewData();

        if (id == null || VM.Entities == null || VM.CurrentEntity == null)
        {
            return NotFound();
        }

        return View(VM);
    }

    // GET: Project/Create
    public IActionResult Create()
    {
        VM = new ProjectVM(
            _context, 
            ProjectVM.eView.Create);
        UpdateViewData();

        return View(VM);
    }

    // POST: Project/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Id,Name,Description", "CurrentEntity")] ProjectVM CurrentVM)
    {
        if (ModelState.IsValid)
        {
            _context.Add(CurrentVM.CurrentEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        VM = new ProjectVM(
            _context,
            ProjectVM.eView.Create);
        VM.CurrentEntity = CurrentVM.CurrentEntity;
        //UpdateViewData();

        return View(VM);
    }

    // GET: Project/Edit/5
    public async Task<IActionResult> Edit(
        int? id)
    {
        if (id == null || _context.Project == null)
        {
            return NotFound();
        }

        VM = new ProjectVM(
           _context,
           ProjectVM.eView.Edit);
        VM.IDEntity = id;
        UpdateViewData();

        if (VM.CurrentEntity == null)
        {
            return NotFound();
        }

        return View(VM);
    }

    // POST: Project/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id, 
        [Bind("Id,Name,Description","CurrentEntity")] ProjectVM CurrentVM)
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

        VM = new ProjectVM(
           _context,
           ProjectVM.eView.Edit);
        VM.IDEntity = id;
        //UpdateViewData();

        return View(VM);
    }

    // GET: Project/Delete/5
    public async Task<IActionResult> Delete(
        int? id)
    {
        VM = new ProjectVM(
           _context,
           ProjectVM.eView.Delete);
        VM.IDEntity = id;
        UpdateViewData();

        if (id == null || VM.CurrentEntity == null)
        {
            return NotFound();
        }

        return View(VM);
    }

    // POST: Project/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(
        int id)
    {
        VM = new ProjectVM(
           _context,
           ProjectVM.eView.Delete);
        VM.IDEntity = id;
        UpdateViewData();

        if (VM.CurrentEntity != null)
        {
            _context.Project.Remove(VM.CurrentEntity);
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
