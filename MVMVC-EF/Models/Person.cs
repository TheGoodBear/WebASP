using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace MVMVC_EF.Models;

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

    // read/write (get/set) properties
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
    [Display(Name = "Sexe")]
    public eSex Sex { get; set; }
    [Display(Name = "Téléphone")]
    [MaxLength(10)]
    public string? Phone { get; set; }
    [Display(Name = "Photo")]
    [MaxLength(100)]
    public string? ProfileImage { get; set; }

    [Display(Name = "Date de naissance")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", NullDisplayText = "Inconnue")]
    public DateTime? BirthDate { get; set; }
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
    public int? Age =>
        BirthDate != null
        ? DateTime.Now.Year - Convert.ToDateTime(BirthDate).Year
        : null;

    // relations properties
    [ForeignKey("IdGroup")]
    [Display(Name = "Groupe")]
    public virtual Group? Group { get; set; }

    public virtual List<PersonAddress>? PersonAddresses { get; set; }



    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }

}
