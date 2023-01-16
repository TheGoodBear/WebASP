using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApiClient.Models;

namespace WebApiClient.Controllers;

public class ProjectsController : Controller
{


    // GET: Projects
    public async Task<IActionResult> Index()
    {

        IEnumerable<Project> projects = null;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:5090/api/");
            //HTTP GET
            var responseTask = client.GetAsync("project");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Project>>();
                readTask.Wait();

                projects = readTask.Result;
            }
            else //web api sent error response 
            {
                //log response status here..

                projects = Enumerable.Empty<Project>();

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
        }
        return View(projects);
    }


}
