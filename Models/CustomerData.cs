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

        public ICollection<CustomerContact> CustomerContacts { get; set; }
        public ICollection<CustomerLicense> CustomerLicenses { get; set; }       

        public CustomerStatus Status { get; set; }
    }

    public class CustomerContact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    public class CustomerLicense
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public enum CustomerStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}