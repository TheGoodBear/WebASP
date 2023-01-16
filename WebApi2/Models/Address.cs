using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WebApi2.Models;

public class Address
{


    // read/write (get/set) properties
    public int Id { get; set; }

    [Display(Name = "Nom")]
    [MaxLength(50)]
    public string Name { get; set; }

    [Display(Name = "Rue")]
    [MaxLength(70)]
    public string Road { get; set; }
    [Display(Name = "Complément")]
    [MaxLength(70)]
    public string? Complement { get; set; }
    [Display(Name = "Code postal")]
    [MaxLength(5)]
    public string ZipCode { get; set; }
    [Display(Name = "Ville")]
    [MaxLength(30)]
    public string City { get; set; }


    // calculated properties
    [Display(Name = "Adresse complète")]
    public string? FullAddress => $"{Road} - {ZipCode} {City}";
    //public string? FullAddress
    //{
    //    get
    //    {
    //        return $"{Road} - {ZipCode} {City}";
    //    }
    //}


    // relation properties
    public virtual ICollection<PersonAddress>? PersonAddresses { get; set; }


    public Address() 
    { }

}
