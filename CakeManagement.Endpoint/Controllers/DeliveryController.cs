using CakeManagement.Endpoint.Services;
using CakeShop.Data;
using CakeShop.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace CakeManagement.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        IAdminManagement logic;
        IStaffManagement staff;
        IOrderManagement order;
        IHubContext<SignalRHub> hub;

        public DeliveryController(IAdminManagement logic, IStaffManagement staff, IOrderManagement order, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.order = order;
            this.staff = staff;
            this.hub = hub;
        }


        [HttpGet]
        public IEnumerable<Delivery> ReadAll()
        {
            return this.order.GetDeliveries();
        }

        [HttpGet("{id}")]
        public Delivery Read(int id)
        {
            return this.order.GetDeliveryInfo(id);
        }

        [HttpPost]
        public void Create([FromBody] Delivery value)
        {
            this.order.AddDelivery(value.Person, value.Income, value.Mins, value.Schedule);
            this.hub.Clients.All.SendAsync("DeliveryValue", value);
        }

        [HttpPut]
        public void Put([FromBody] Delivery value)
        {
            this.staff.UpdateDeliveryPersonName(value.Id, value.Person);
            this.hub.Clients.All.SendAsync("DeliveryUpdates", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deliveryToDelete = this.order.GetDeliveryInfo(id);
            this.logic.RemoveDelivery(id);
            this.hub.Clients.All.SendAsync("DeliveryDeleted", deliveryToDelete);
        }
    }
}
