using Microsoft.EntityFrameworkCore;
using WebApiClient.Models;
using System.ComponentModel.DataAnnotations;
using WebApiClient.Utilities;

namespace WebApiClient.ViewModels
{
    public class ProjectVM : GenericVM<Project>
    {

        // views properties
        public string EntityName { get; set; } = "projet";


        // models properties
        private int? _IDEntity;
        public int? IDEntity 
        {
            get => _IDEntity;
            set 
            {
                _IDEntity = value;
                if (_IDEntity != null)
                {
                    CurrentEntity = Entities
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
            eView View) 
            : base(View)
        {

            UpdateControllerData(EntityName, View);

        }

    }
}
