using MessagePack;
using System.ComponentModel.DataAnnotations;


namespace ApplicationName.Models.Account
{

        public class User
        {

      
            public int Id { get; set; }
        [Required]
            public string UserName { get; set; }
            public string Email { get; set; }
            public long? Mobile { get; set; }
            public string Password { get; set; }
            public bool IsActive { get; set; }
            public bool IsRemember { get; set; }
    }
}
