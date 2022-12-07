using Microsoft.AspNetCore.Mvc;
using MVC3.Models;
using MVC3.ViewModels.DM;

namespace MVC3.Controllers;

public class DMController : Controller
{
    private static List<Person> Persons { get; set; }

    public IActionResult DMList()
    {
        DMListVM VM = new DMListVM();
        Persons = VM.Persons;

        return View(VM);
    }

    public IActionResult DMDetail(
        int Id)
    {
        Person CurrentPerson = Persons
            .First(e => e.Id == Id);

        DMDetailVM VM = new DMDetailVM(
            CurrentPerson);

        return View(VM);
    }

}
