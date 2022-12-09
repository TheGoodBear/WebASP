using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_EF1.Models
{
    public class Group
    {
     
        // enumerations
        public enum eTechnology
        {
            None = 0,
            ASPNetMVC = 1,
            MAUI = 2,
            UWP = 3
        }

        // read/write (get/set) properties
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public eTechnology Technology { get; set; }
        public int IdProject { get; set; }

        // read only (get) properties


        //relations
        [ForeignKey("IdProject")]
        public virtual Project Project { get; set; }
        public virtual ICollection<Person>? Persons { get; set; }


        // constructors
        //public Group()
        //{ }
        //public Group(
        //    int Number,
        //    string Name,
        //    eTechnology Technology,
        //    int IdProject)
        //{
        //    this.Number = Number;
        //    this.Name = Name;
        //    this.Technology = Technology;
        //    this.IdProject = IdProject;
        //}
        //public Group(
        //    string[] Data)
        //{
        //    this.Number = Convert.ToInt32(Data[0]);
        //    this.Name = Data[1];
        //    this.Technology = (eTechnology)Convert.ToInt32(Data[2]);
        //    this.IdProject = Convert.ToInt32(Data[3]);
        //}

        // methods
        public override string ToString()
        {
            return $"({Number}) {Name}";
        }

    }
}
