using CakeManagement.Endpoints.Services;
using CakeShop.Data;
using CakeShop.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace CakeManagement.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BakerController : ControllerBase
    {
        IAdminManagement logic;
        IStaffManagement staff;
        IHubContext<SignalRHub> hub;

        public BakerController(IAdminManagement logic, IStaffManagement staff, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.staff = staff;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Baker> ReadAll()
        {
            return this.staff.GetAllBaker();
        }

        [HttpGet("income/")]
        public IEnumerable<IncomeByBaker> IncomeByBakers()
        {
            return this.logic.TotalIncomeByBaker();
        }

        [HttpGet("average/")]
        public IEnumerable<AveragesResult> Averages()
        {
            return this.logic.GetBakerCakePriceAverage();
        }

        [HttpGet("{id}")]
        public Baker Read(int id)
        {
            return this.staff.GetBakerInfo(id);
        }

        [HttpPost]
        public void Create([FromBody] Baker value)
        {
            this.staff.AddBaker(value.Name, value.Position, value.Salary, value.Workhours);
            this.hub.Clients.All.SendAsync("BakerValue", value);
        }

        [HttpPut]
        public void Put([FromBody] Baker value)
        {
            this.logic.UpdateBakerSalary(value.Id, value.Salary);
            this.hub.Clients.All.SendAsync("BakerUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var bakerToDelete = this.staff.GetBakerInfo(id);
            this.logic.RemoveBaker(id);
            this.hub.Clients.All.SendAsync("BakerDeleted", bakerToDelete);
        }
    }
}
