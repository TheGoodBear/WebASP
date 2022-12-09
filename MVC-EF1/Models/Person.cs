using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_EF1.Models
{
    public class Person
    {

        // enumerations
        public enum eSex
        {
            Féminin = 1,
            Masculin = 2,
            Autre = 0
        }
        public enum eITLevel
        {
            Débutant = 1,
            Intermédiaire = 2,
            Avancé = 3
        }
        public enum eLocation
        {
            Présentiel = 0,
            Distanciel = 1
        }

        // raed/write (get/set) properties
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public eSex Sex { get; set; }
        public int? BirthYear { get; set; }
        public eITLevel ITLevel { get; set; }
        public eLocation Location { get; set; }
        public int IdGroup { get; set; }


        // read only (get) properties
        public int? Age => DateTime.Now.Year - BirthYear;


        //relations
        [ForeignKey("IdGroup")]
        public virtual Group Group { get; set; }


        // constructors
        //public Person () 
        //{ 
        //}
        //public Person(
        //    string LastName,
        //    string FirstName,
        //    eSex Sex,
        //    int BirthYear,
        //    eITLevel ITLevel,
        //    eLocation Location,
        //    int IdGroup)
        //{
        //    this.LastName = LastName;
        //    this.FirstName = FirstName;
        //    this.Sex = Sex;
        //    this.BirthYear = BirthYear;
        //    this.ITLevel = ITLevel;
        //    this.Location = Location;
        //    this.IdGroup = IdGroup;
        //}
        //public Person(
        //    string[] Data)
        //{
        //    this.LastName = Data[0];
        //    this.FirstName = Data[1];
        //    this.Sex = (eSex)Convert.ToInt32(Data[2]);
        //    this.BirthYear = Convert.ToInt32(Data[3]);
        //    this.ITLevel = (eITLevel)Convert.ToInt32(Data[4]);
        //    this.Location = (eLocation)Convert.ToInt32(Data[5]);
        //    this.IdGroup = Convert.ToInt32(Data[6]);
        //}


        // methods
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

    }
}
