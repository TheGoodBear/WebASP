using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi2.Models;

public class Group
{
    public enum eTechnology
    {
        [Display(Name = "Aucun")]
        None,
        ASPNetMVC,
        MAUI,
        UWP
    }

    // read/write (get/set) properties
    public int Id { get; set; }
    [Display(Name = "Numéro de groupe")]
    [Range(1, 30, ErrorMessage = "La valeur doit être comprise entre 1 et 30")]
    public int Number { get; set; }
    [Display(Name = "Nom")]
    [MaxLength(50)]
    public string? Name { get; set; }
    [Display(Name = "Technologie")]
    public eTechnology Technology { get; set; }
    [Display(Name = "Projet")]
    public int IdProject { get; set; }

    // read only (get) properties


    // relations properties
    [ForeignKey("IdProject")]
    [Display(Name = "Projet associé")]
    public virtual Project? Project { get; set; }
    public virtual List<Person>? Persons { get; set; }


public override string ToString()
    {
        return $"({Number}) {Name}";
    }

}
