using Microsoft.AspNetCore.Mvc;
using MongoExample.CrossCutting.DependencyResolver;
using MongoExample.Domain.Interfaces.Repository.Customers;
using MongoExample.Domain.Interfaces.Services.Customers;
using MongoExample.Domain.Models;
using System.Collections.Generic;

namespace MongoExample.Api.Controllers
{
    [Route("api/Customer")]
    public class CustomerController : ControllerBase
    {

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<Customer>> GetAll()
        {
            var rep = Factory.Resolve<ICustomerRepository>();
            return rep.GetAll();
        }

        [HttpGet]
        [Route("GetById")]
        public ActionResult<Customer> GetById([FromQuery] string id)
        {
            var rep = Factory.Resolve<ICustomerRepository>();
            return rep.GetById(id);
        }

        [HttpPost]
        [Route("Add")]
        public void Add([FromBody] Customer customer)
        {
            var service = Factory.Resolve<ICustomerService>();
            service.Add(customer);
        }

        [HttpDelete]
        [Route("Delete")]
        public void Delete([FromBody] Customer customer)
        {
            var service = Factory.Resolve<ICustomerService>();
            service.Delete(customer);
        }

        [HttpPut]
        [Route("Update")]
        public void Update([FromBody] Customer customer)
        {
            var service = Factory.Resolve<ICustomerService>();
            service.Update(customer);
        }
    }
}
