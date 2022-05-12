using CakeManagement.Endpoint.Services;
using CakeShop.Data;
using CakeShop.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CakeManagement.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CakeController : ControllerBase
    {
        IAdminManagement logic;
        IStaffManagement staff;
        IOrderManagement order;
        IHubContext<SignalRHub> hub;

        public CakeController(IAdminManagement admin, IOrderManagement order,
        IStaffManagement staff , IHubContext<SignalRHub> hub)
        {
            this.logic = admin;
            this.staff = staff;
            this.order = order;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Cake> ReadAll()
        {
            return this.order.GetAllCakes();
        }

        [HttpGet("id")]
        public Cake Read(int id)
        {
            return this.order.GetCakeInfo(id);
        }

        [HttpPost]
        public void Create([FromBody] Cake value)
        {
            this.order.AddCake(value.Name, value.Shape, value.Color, value.BakerId, (int)value.BasePrice);
            this.hub.Clients.All.SendAsync("CakeValue", value);
        }

        [HttpPut]
        public void Put([FromBody] Cake value)
        {
            this.order.UpdateCake(value.Id, value.Name, value.Shape, value.Color, value.BakerId, (int)value.BasePrice);
            this.hub.Clients.All.SendAsync("CakeUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var cakeToDelete = this.order.GetCakeInfo(id);
            this.logic.RemoveCake(id);
            this.hub.Clients.All.SendAsync("cakeDeleted", cakeToDelete);
        }
    }
}
