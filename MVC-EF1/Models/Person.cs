using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace MVC_EF1.Models;

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
    [Display(Name = "Nom")]
    [MaxLength(50)]
    public string LastName { get; set; }
    [Display(Name = "Prénom")]
    [MaxLength(50)]
    public string FirstName { get; set; }
    [Display(Name = "Adresse email")]
    [EmailAddress]
    [MaxLength(50)]
    public string Email { get; set; }
    public eSex Sex { get; set; }
    [Display(Name = "Année de naissance")]
    [Range(1930, 2020, ErrorMessage = "La valeur doit être comprise entre 1930 et 2020")]
    public int? BirthYear { get; set; }
    [Display(Name = "Niveau")]
    public eITLevel? ITLevel { get; set; }
    [Display(Name = "Localisation")]
    public eLocation Location { get; set; }
    [Display(Name = "Groupe")]
    public int? IdGroup { get; set; }

    // read only (get) properties
    [Display(Name = "Nom")]
    public string FullName => $"{FirstName} {LastName}";
    [Display(Name = "Âge")]
    public int? Age => DateTime.Now.Year - BirthYear;

    // relations properties
    [ForeignKey("IdGroup")]
    public virtual Group? Group { get; set; }


    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }

}
