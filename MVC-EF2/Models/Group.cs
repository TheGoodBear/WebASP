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
    public int Number { get; set; }
    public string Name { get; set; }
    public eTechnology Technology { get; set; }
    public int IdProject { get; set; }

    // read only (get) properties


    // relations properties
    [ForeignKey("IdProject")]
    public virtual Project Project { get; set; }


    public override string ToString()
    {
        return $"({Number}) {Name}";
    }

}
