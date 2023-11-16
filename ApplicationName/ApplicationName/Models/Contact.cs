using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace ApplicationName.Models
{
    public class Contact
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

    }
}
