using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreWebApp.core.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        public List<Address> Addresses { get; set; } = new List<Address>();
        public int Age { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<Person> Parents { get; set; } = new List<Person>();
        public List<Person> Children { get; set; } = new List<Person>();
    }
}