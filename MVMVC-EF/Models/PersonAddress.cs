using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVMVC_EF.Models
{
    public class PersonAddress
    {

        // read/write (get/set) properties
        public int Id { get; set; }
        [DisplayName("Personne")] 
        public int IdPerson { get; set; }
        [DisplayName("Adresse")] 
        public int IdAddress { get; set; }


        // relation properties
        [ForeignKey("IdPerson")]
        [DisplayName("Personne")]
        public virtual Person? Person { get; set; }
        [ForeignKey("IdAddress")]
        [DisplayName("Adresse")]
        public virtual Address? Address { get; set; }



        public PersonAddress() 
        { }
        public PersonAddress(
            int IdPerson,
            int IdAddress) 
        {
            this.IdPerson = IdPerson;
            this.IdAddress = IdAddress;
        }

    }
}
