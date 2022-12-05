using Microsoft.AspNetCore.Mvc;
using MVC2.ViewModels.Home;
using MVC2.ViewModels.Sample1;
using System.Web;

namespace MVC2.Controllers
{
    public class Sample1Controller : Controller
    {

        // GET : /Sample1/View1
        public IActionResult View1(
            string? Name,
            int? BirthYear)
        {
            View1VM VM = new View1VM(
                Name, 
                BirthYear);

            return View(VM);
        }


        // GET : /Sample1/View2
        public IActionResult View2(int id)
        {
            string? SelectedPerson;
            string[] Persons = new string[] {
                "Julien", "Slim", "Daïka"};
            try
            {
                SelectedPerson = Persons[id - 1];
            }
            catch (Exception ex)
            {
                SelectedPerson = null;
            }

            View2VM VM = new View2VM(
                SelectedPerson);

            return View(VM);
        }

    }
}
