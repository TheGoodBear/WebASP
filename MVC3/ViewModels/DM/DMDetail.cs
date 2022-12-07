using MVC3.Models;

namespace MVC3.ViewModels.DM
{
    public class DMDetailVM
    {

        // view properties
        public string Title { get; set; }
        public string? ErrorMessage { get; set; }


        // model data properties
        public Person CurrentPerson { get; set; }


        // constructor
        public DMDetailVM(
            Person? CurrentPerson = null, 
            string? ErrorMessage = null)
        {
            if (CurrentPerson != null)
            {
                this.CurrentPerson = CurrentPerson;
                Title = $"Détail de l'étudiant {CurrentPerson.Id}";
            }
            this.ErrorMessage = ErrorMessage;
        }

    }

}
