using Microsoft.EntityFrameworkCore;
using MVMVC_EF.Data;
using MVMVC_EF.Models;
using System.ComponentModel.DataAnnotations;
using MVMVC_EF.Utilities;

namespace MVMVC_EF.ViewModels
{
    public class ProjectVM
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
        public static string EntityName = "projet";
        public static string EntityNamePlural = $"{EntityName}s";

        public static string IndexTitle = $"{eView.Index.GetDisplayName()} des [Nb] {EntityNamePlural}";
        public static string DetailTitle = $"{eView.Detail.GetDisplayName()} du {EntityName} [Entity]";
        public static string CreateTitle = $"{eView.Create.GetDisplayName()} d'un nouveau {EntityName}";
        public static string EditTitle = $"{eView.Edit.GetDisplayName()} du {EntityName} [Entity]";
        public static string DeleteTitle = $"{eView.Delete.GetDisplayName()} du {EntityName} [Entity]";
        public string? PageTitle { get; set; }
        public static string TabTitle;
        public string CreateText { get; set; } = $"Ajouter un nouveau {EntityName}";
        public string EditText { get; set; } = $"Modifier";
        public string EditIcon { get; set; } = $"bi-pencil-square";
        public string DeleteText { get; set; } = $"Supprimer";
        public string DeleteIcon { get; set; } = $"bi-trash";
        public string DeleteConfirmText { get; set; } = $"Êtes-vous sûr de vouloir supprimer ce {EntityName} ?";
        public string GoToListText { get; set; } = $"Retour à la liste";
        public string AddText { get; set; } = $"Ajouter";

        public List<Tuple<string, string>> ViewData { get; set; } = new List<Tuple<string, string>>();
 

        // models properties
        public DBContext? Context { get; set; }
        public DbSet<Project>? Entities { get; set; }
        private int? _IDEntity;
        public int? IDEntity 
        {
            get => _IDEntity;
            set 
            {
                _IDEntity = value;
                if (_IDEntity != null)
                {
                    CurrentEntity = Context
                        .Project
                        .FirstOrDefault(p => p.Id == _IDEntity);
                    PageTitle = PageTitle
                        .Replace("[Entity]", CurrentEntity.ToString());
                }
            }
        }
        public Project? CurrentEntity { get; set; }


        // constructor
        public ProjectVM()
        { }
        public ProjectVM(
            DBContext Context,
            eView View)
        {

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

            this.Context = Context;
            Entities = Context.Project;

            ViewData.Add(new Tuple<string, string> (
                "TabTitle", TabTitle));
            ViewData.Add(new Tuple<string, string>(
                "ProjectVisible", ""));

            PageTitle = PageTitle
                .Replace("[Nb]", Entities.Count().ToString());

        }

    }
}
