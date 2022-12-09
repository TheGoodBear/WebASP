using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_EF2.Models;

public class Group
{
    public enum eTechnology
    {
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
    [Display(Name = "Projet associé")]
    public int IdProject { get; set; }

    // read only (get) properties


    // relations properties
    [ForeignKey("IdProject")]
    public virtual Project? Project { get; set; }


    public override string ToString()
    {
        return $"({Number}) {Name}";
    }

}
