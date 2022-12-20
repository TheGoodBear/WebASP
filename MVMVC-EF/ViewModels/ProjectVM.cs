using Microsoft.EntityFrameworkCore;
using MVMVC_EF.Data;
using MVMVC_EF.Models;
using System.ComponentModel.DataAnnotations;
using MVMVC_EF.Utilities;

namespace MVMVC_EF.ViewModels
{
    public class ProjectVM : GenericVM
    {

        // views properties
        public string EntityName { get; set; } = "projet";


        // models properties
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
        public ProjectVM() : base()
        { }
        public ProjectVM(
            DBContext Context,
            eView View) 
            : base(Context, View)
        {

            Entities = Context.Project;

            UpdateControllerData(EntityName, View);

            PageTitle = PageTitle
                .Replace("[Nb]", Entities.Count().ToString());

        }

    }
}
