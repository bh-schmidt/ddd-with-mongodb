using Microsoft.AspNetCore.Mvc;
using MongoExample.CrossCutting.DependencyResolver;
using MongoExample.Domain.Interfaces.Customers;
using MongoExample.Domain.Models.Customers;
using System.Threading.Tasks;

namespace MongoExample.Api.Controllers.Customers
{
    [Route("api/Customer")]
    public class CustomerController : BaseController
    {

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var rep = Factory.Resolve<ICustomerService>();
            var customers = await rep.GetAll();
            return Ok(customers);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {
            var rep = Factory.Resolve<ICustomerService>();
            var customer = await rep.GetBy(id);
            return Ok(customer);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult >Add([FromBody] Customer customer)
        {
            var service = Factory.Resolve<ICustomerService>();
            await service.Add(customer);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult >Delete([FromBody] Customer customer)
        {
            var service = Factory.Resolve<ICustomerService>();
            await service.Delete(customer);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult >Update([FromBody] Customer customer)
        {
            var service = Factory.Resolve<ICustomerService>();
            await service.Update(customer);
            return Ok();
        }
    }
}
