using MVC3.Models;

namespace MVC3.ViewModels.DM
{
    public class DMDetailVM
    {

        // view properties
        public string Title { get; set; }


        // model data properties
        public Person CurrentPerson { get; set; }


        // constructor
        public DMDetailVM(
            Person CurrentPerson)
        {
            this.CurrentPerson = CurrentPerson;
            Title = $"Détail de l'étudiant {CurrentPerson.Id}";
        }

    }

}
