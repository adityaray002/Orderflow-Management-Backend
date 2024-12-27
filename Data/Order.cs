using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFlow_Management.Data
{
    public class Order
    {
        public int Id { get; set; }

        public string? MessageInfo { get; set; }

        public DateTime OrderDate { get; set; }
        
        public int StatusId { get; set; }
       
        public int ProductId{ get; set; }
       
       
        public int UserInfoId { get; set; }

     

    }
}
