using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFlow_Management.Data
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
   
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }

    
     

    }
}
