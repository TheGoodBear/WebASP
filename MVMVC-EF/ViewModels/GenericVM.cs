using Microsoft.EntityFrameworkCore;
using MVMVC_EF.Data;
using MVMVC_EF.Models;
using System.ComponentModel.DataAnnotations;
using MVMVC_EF.Utilities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MVMVC_EF.ViewModels
{
    public class GenericVM
    {
        public enum eView
        {
            [Display(Name = "Liste")]
            Index,
            [Display(Name = "Détail")]
            Detail,
            [Display(Name = "Création")]
            Create,
            [Display(Name = "Modification")]
            Edit,
            [Display(Name = "Suppression")]
            Delete
        }


        // views properties
        public string EntityName { get; set; } = "";
        public string EntityNamePlural { get; set; }

        public string IndexTitle { get; set; }
        public string DetailTitle { get; set; }
        public string CreateTitle { get; set; } 
        public string EditTitle { get; set; } 
        public string DeleteTitle { get; set; } 
        public string? PageTitle { get; set; }
        public string TabTitle { get; set; }
        public string CreateText { get; set; }
        public string EditText { get; set; } = $"Modifier";
        public string EditIcon { get; set; } = $"bi-pencil-square";
        public string DeleteText { get; set; } = $"Supprimer";
        public string DeleteIcon { get; set; } = $"bi-trash";
        public string DeleteConfirmText { get; set; }
        public string GoToListText { get; set; } = $"Retour à la liste";
        public string AddText { get; set; } = $"Ajouter";

        public List<Tuple<string, string>> ViewData { get; set; } = new List<Tuple<string, string>>();


        // models properties
        public DBContext? Context { get; set; }


        // constructor
        public GenericVM()
        { }
        public GenericVM(
            DBContext Context,
            eView View)
        {

            this.Context = Context;

            ViewData.Add(new Tuple<string, string>(
                "TabTitle", TabTitle));
            ViewData.Add(new Tuple<string, string>(
                "ProjectVisible", ""));

        }


        public void UpdateControllerData(string EntityName, eView View)
        {

            EntityNamePlural = $"{EntityName}s";
            IndexTitle = $"{eView.Index.GetDisplayName()} des [Nb] {EntityNamePlural}";
            DetailTitle = $"{eView.Detail.GetDisplayName()} du {EntityName} [Entity]";
            CreateTitle = $"{eView.Create.GetDisplayName()} d'un nouveau {EntityName}";
            EditTitle = $"{eView.Edit.GetDisplayName()} du {EntityName} [Entity]";
            DeleteTitle = $"{eView.Delete.GetDisplayName()} du {EntityName} [Entity]";

            CreateText = $"Ajouter un nouveau {EntityName}";
            DeleteConfirmText = $"Êtes-vous sûr de vouloir supprimer ce {EntityName} ?";

            switch (View)
            {
                case eView.Index:
                    PageTitle = IndexTitle;
                    TabTitle = $"{eView.Index.GetDisplayName()} {EntityName}";
                    break;
                case eView.Detail:
                    PageTitle = DetailTitle;
                    TabTitle = $"{eView.Detail.GetDisplayName()} {EntityName}";
                    break;
                case eView.Create:
                    PageTitle = CreateTitle;
                    TabTitle = $"{eView.Create.GetDisplayName()} {EntityName}";
                    break;
                case eView.Edit:
                    PageTitle = EditTitle;
                    TabTitle = $"{eView.Edit.GetDisplayName()} {EntityName}";
                    break;
                case eView.Delete:
                    PageTitle = DeleteTitle;
                    TabTitle = $"{eView.Delete.GetDisplayName()} {EntityName}";
                    break;
            }

        }

    }
}
