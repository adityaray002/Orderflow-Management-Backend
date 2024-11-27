using Microsoft.EntityFrameworkCore;
using OrderFlow_Management.Data;

namespace OrderFlow_Management.Services
{
    public class OrderServices
    {
        private readonly AppDbContext appDbContext;
        
        public OrderServices(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;   

         }
        public async Task<IResult> AddOrder(Order order)
        {
            appDbContext.Order.Add(order);
            await appDbContext.SaveChangesAsync();
            return Results.Ok(order);
        }

        public async Task<IResult> GetAllOrder()
        {
            List<Order> orders = await appDbContext.Order.ToListAsync();
            List<OrderResponse> AllOrders = new List<OrderResponse>();
            foreach(var o in orders)
            {
                OrderResponse response = new OrderResponse();
                var user = await appDbContext.Users.FirstOrDefaultAsync(u=>u.Id == o.UserInfoId);
                var electronic = await appDbContext.Electronics.FirstOrDefaultAsync(u=>u.Id == o.ElectronicId);
                var status = await appDbContext.Status.FirstOrDefaultAsync(u=>u.Id == o.StatusId);
                response.id = o.Id;
                response.username = user.Name;
                response.email = user.Email;
                response.address = user.Address;
                response.phoneno = user.PhoneNo;
                response.dateTime = o.OrderDate;
                response.statusName = status.Name;
                response.electronicItem = electronic.Name;
                response.messageInfo = o.MessageInfo;
                AllOrders.Add(response);
                
            }
           
            return Results.Ok(AllOrders);
        }

        public async Task<IResult> GetOrderById(int id)
        {
            var order = await appDbContext.Order.FindAsync(id);
            if (order != null)
            {
                return Results.Ok(order); 
            }
            return Results.NotFound($"Order with ID {id} not found."); 
        }


        public async Task<IResult> UpdateOrder(Order updatedOrder)
        {
            // Find the existing order in the database
            var existingOrder = await appDbContext.Order.FindAsync(updatedOrder.Id);
            if (existingOrder == null)
            {
                return Results.NotFound($"Order with ID {updatedOrder.Id} not found.");
            }

         
            
            existingOrder.ElectronicId = updatedOrder.ElectronicId;
            existingOrder.StatusId = updatedOrder.StatusId;
            existingOrder.MessageInfo = updatedOrder.MessageInfo;

            try
            {
               
                await appDbContext.SaveChangesAsync();
                return Results.Ok(existingOrder); 
            }
            catch (Exception ex)
            {
                
                return Results.Problem($"An error occurred while updating the order: {ex.Message}");
            }
        }



    }
}
