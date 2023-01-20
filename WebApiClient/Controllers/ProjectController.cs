using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApiClient.Models;
using WebApiClient.Utilities;
using WebApiClient.ViewModels;

namespace WebApiClient.Controllers;

public class ProjectController : Controller
{

    private ProjectVM VM;


    // GET: Project/Index
    public async Task<IActionResult> Index()
    {
        VM = new ProjectVM(
            ProjectVM.eView.Index);
        VM.Entities = await APICRUD<Project>.ReadAllData();
        UpdateViewData();

        return View(VM);
    }


    // GET: Project/Details/5
    public async Task<IActionResult> Details(
        int? id)
    {
        VM = new ProjectVM(
           ProjectVM.eView.Detail);
        VM.Entities = await APICRUD<Project>.ReadAllData();
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
            await APICRUD<Project>.CreateData(CurrentVM.CurrentEntity);
            return RedirectToAction(nameof(Index));
        }

        VM = new ProjectVM(
            ProjectVM.eView.Create);
        VM.CurrentEntity = CurrentVM.CurrentEntity;
        //UpdateViewData();

        return View(VM);
    }


    // GET: Project/Edit/5
    public async Task<IActionResult> Edit(
        int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        VM = new ProjectVM(
           ProjectVM.eView.Edit);
        VM.Entities = await APICRUD<Project>.ReadAllData();
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
        [Bind("Id,Name,Description", "CurrentEntity")] ProjectVM CurrentVM)
    {

        if (id != CurrentVM.CurrentEntity.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await APICRUD<Project>.EditData(
                    CurrentVM.CurrentEntity, 
                    CurrentVM.CurrentEntity.Id);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        VM = new ProjectVM(
           ProjectVM.eView.Edit);
        VM.Entities = await APICRUD<Project>.ReadAllData();
        VM.IDEntity = id;
        //UpdateViewData();

        return View(VM);
    }


    // GET: Project/Delete/5
    public async Task<IActionResult> Delete(
        int? id)
    {
        VM = new ProjectVM(
           ProjectVM.eView.Delete);
        VM.Entities = await APICRUD<Project>.ReadAllData();
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
           ProjectVM.eView.Delete);
        VM.Entities = await APICRUD<Project>.ReadAllData();
        VM.IDEntity = id;
        UpdateViewData();

        if (VM.CurrentEntity != null)
        {
            await APICRUD<Project>.DeleteData(
                VM.CurrentEntity.Id);
        }

        return RedirectToAction(nameof(Index));
    }


    private void UpdateViewData()
    {
        foreach (Tuple<string, string> VD in VM.ViewData)
            ViewData[VD.Item1] = VD.Item2;
    }

}
