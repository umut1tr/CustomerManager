using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerManager.Models
{
    public class CustomerData
    {

        [Required]
        public int Id { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public string CustomerAdress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerDescriptionField { get; set; }

        public string CustomerConsultant { get; set; }
        public string CustomerProjectLead { get; set; }

        [NotMapped]
        public List<String> CustomerContacts { get; set; }

        [NotMapped]
        public List<String> CustomerLicenses { get; set; }

        public CustomerActivity CustomerActivitySelection { get; set; }
    }

    public enum CustomerActivity
    {
        Aktiv,
        Inaktiv
    }
}
