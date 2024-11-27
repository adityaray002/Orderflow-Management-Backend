namespace OrderFlow_Management.Data
{
    public class OrderResponse
    {
       public int id {  get; set; }
        public string username { get; set; }
        public string email { get; set; }

        public DateTime dateTime { get; set; }

       public string address {  get; set; }

        public string phoneno {  get; set; }

        public string electronicItem { get; set; }

        public string statusName { get; set; }

        public string messageInfo { get; set; }

    }
}
