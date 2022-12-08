namespace MVC_EF2.Models;

public class Person
{

    public enum eSex
    {
        Féminin,
        Masculin,
        Autre
    }
    public enum eITLevel
    {
        Débutant,
        Intermédiaire,
        Avancé
    }
    public enum eLocation
    {
        Présentiel,
        Distanciel
    }

    // raed/write (get/set) properties
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public eSex Sex { get; set; }
    public int BirthYear { get; set; }
    public eITLevel ITLevel { get; set; }
    public eLocation Location { get; set; }
    public int IdGroup { get; set; }

    // read only (get) properties
    public int Age => DateTime.Now.Year - BirthYear;



    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }

}
