using MongoExample.CrossCutting.DependencyResolver;
using MongoExample.Data.Interfaces.Customers;
using MongoExample.Domain.Models.Customers;
using MongoExample.Domain.Services.Customers;
using Moq;
using NUnit.Framework;

namespace MongoExample.Domain.Tests.Services.Customers
{
    public class CustomerServiceTests : BaseTest
    {
        CustomerService customerService;
        Mock<IFactory> factoryMock;
        Mock<ICustomerRepository> customerRepositoryMock;

        [SetUp]
        public void Setup()
        {
            factoryMock = new Mock<IFactory>();
            customerRepositoryMock = new Mock<ICustomerRepository>();

            factoryMock.Setup(x => x.Resolve<ICustomerRepository>())
                .Returns(customerRepositoryMock.Object);

            customerService = new CustomerService(factoryMock.Object);
        }
        
        [Test]
        public void WillAddTheCustomer()
        {
            Customer customer = new Customer
            {
                Name = "Test"
            };
            
            customerService.Add(customer).Wait();

            customerRepositoryMock.Verify(
                x => x.StartConnection(),
                Times.Once);

            customerRepositoryMock.Verify(
                x => x.Add(customer),
                Times.Once);
        }

        [Test]
        public void WontAddBecauseCustomerIsNull()
        {
            Customer customer = null;

            customerService.Add(customer).Wait();

            customerRepositoryMock.Verify(
                x => x.StartConnection(),
                Times.Never);

            customerRepositoryMock.Verify(
                x => x.Add(customer),
                Times.Never);
        }

        [Test]
        public void WontAddBecauseCustomerNameIsNull()
        {
            Customer customer = new Customer
            {
                Name = null
            };

            customerService.Add(customer).Wait();

            customerRepositoryMock.Verify(
                x => x.StartConnection(),
                Times.Never);

            customerRepositoryMock.Verify(
                x => x.Add(customer),
                Times.Never);
        }

        [Test]
        public void WontAddBecauseCustomerNameIsEmpty()
        {
            Customer customer = new Customer {
                Name = ""
            };

            customerService.Add(customer).Wait();

            customerRepositoryMock.Verify(
                x => x.StartConnection(),
                Times.Never);

            customerRepositoryMock.Verify(
                x => x.Add(customer),
                Times.Never);
        }

        [Test]
        public void WontAddBecauseCustomerNameIsWhiteSpace()
        {
            Customer customer = new Customer
            {
                Name = " "
            };

            customerService.Add(customer).Wait();

            customerRepositoryMock.Verify(
                x => x.StartConnection(),
                Times.Never);

            customerRepositoryMock.Verify(
                x => x.Add(customer),
                Times.Never);
        }

        [Test]
        public void WillDeleteCustomer()
        {
            Customer customer = new Customer
            {
                Id = "123"
            };

            customerService.Delete(customer).Wait();

            customerRepositoryMock.Verify(
                x => x.StartConnection(),
                Times.Once);

            customerRepositoryMock.Verify(
                x => x.Delete(customer),
                Times.Once);
        }

        [Test]
        public void WontDeleteCustomerBecauseCustomerIsNull()
        {
            Customer customer = null;

            customerService.Delete(customer).Wait();

            customerRepositoryMock.Verify(
                x => x.StartConnection(),
                Times.Never);

            customerRepositoryMock.Verify(
                x => x.Delete(customer),
                Times.Never);
        }

        [Test]
        public void WontDeleteCustomerBecauseCustomerIdIsEmpty()
        {
            Customer customer = new Customer
            {
                Id = ""
            };

            customerService.Delete(customer).Wait();

            customerRepositoryMock.Verify(
                x => x.StartConnection(),
                Times.Never);

            customerRepositoryMock.Verify(
                x => x.Delete(customer),
                Times.Never);
        }

        [Test]
        public void WontDeleteCustomerBecauseCustomerIdIsWhiteSpace()
        {
            Customer customer = new Customer
            {
                Id = " "
            };

            customerService.Delete(customer).Wait();

            customerRepositoryMock.Verify(
                x => x.StartConnection(),
                Times.Never);

            customerRepositoryMock.Verify(
                x => x.Delete(customer),
                Times.Never);
        }

        [Test]
        public void WillGetAllCustomers()
        {
            customerService.GetAll().Wait();

            customerRepositoryMock.Verify(
                x => x.StartConnection(),
                Times.Once);

            customerRepositoryMock.Verify(
                x => x.GetAll(),
                Times.Once);
        }

        [Test]
        public void WillGetCustomerById()
        {
            string id = "123";

            customerService.GetBy(id).Wait();

            customerRepositoryMock.Verify(
                x => x.StartConnection(),
                Times.Once);

            customerRepositoryMock.Verify(
                x => x.GetBy(id),
                Times.Once);
        }

        [Test]
        public void WontGetUserByIdBecauseIdIsNull()
        {
            string id = null;

            customerService.GetBy(id).Wait();

            customerRepositoryMock.Verify(
                x => x.StartConnection(),
                Times.Never);

            customerRepositoryMock.Verify(
                x => x.GetBy(id),
                Times.Never);
        }

        [Test]
        public void WontGetUserByIdBecauseIdIsEmpty()
        {
            string id = "";

            customerService.GetBy(id).Wait();

            customerRepositoryMock.Verify(
                x => x.StartConnection(),
                Times.Never);

            customerRepositoryMock.Verify(
                x => x.GetBy(id),
                Times.Never);
        }

        [Test]
        public void WontGetUserByIdBecauseIdIsWhiteSpace()
        {
            string id = " ";

            customerService.GetBy(id).Wait();

            customerRepositoryMock.Verify(
                x => x.StartConnection(),
                Times.Never);

            customerRepositoryMock.Verify(
                x => x.GetBy(id),
                Times.Never);
        }

        [Test]
        public void WillUpdateCustomer()
        {
            Customer customer = new Customer()
            {
                Id = "123",
                Name = "Test"
            };

            customerService.Update(customer).Wait();

            customerRepositoryMock.Verify(
                x => x.StartConnection(),
                Times.Once);

            customerRepositoryMock.Verify(
                x => x.Update(customer),
                Times.Once);
        }

        [Test]
        public void WontUpdateCustomerBecauseCustomerIsNull()
        {
            Customer customer = null;

            customerService.Update(customer).Wait();

            customerRepositoryMock.Verify(
                x => x.StartConnection(),
                Times.Never);

            customerRepositoryMock.Verify(
                x => x.Update(customer),
                Times.Never);
        }

        [Test]
        public void WontUpdateCustomerBecauseIdIsNull()
        {
            Customer customer = new Customer()
            {
                Id = null,
                Name = "Test"
            };

            customerService.Update(customer).Wait();

            customerRepositoryMock.Verify(
                x => x.StartConnection(),
                Times.Never);

            customerRepositoryMock.Verify(
                x => x.Update(customer),
                Times.Never);
        }

        [Test]
        public void WontUpdateCustomerBecauseIdIsEmpty()
        {
            Customer customer = new Customer()
            {
                Id = "",
                Name = "Test"
            };

            customerService.Update(customer).Wait();

            customerRepositoryMock.Verify(
                x => x.StartConnection(),
                Times.Never);

            customerRepositoryMock.Verify(
                x => x.Update(customer),
                Times.Never);
        }

        [Test]
        public void WontUpdateCustomerBecauseIdIsWhiteSpace()
        {
            Customer customer = new Customer()
            {
                Id = " ",
                Name = "Test"
            };

            customerService.Update(customer).Wait();

            customerRepositoryMock.Verify(
                x => x.StartConnection(),
                Times.Never);

            customerRepositoryMock.Verify(
                x => x.Update(customer),
                Times.Never);
        }

        [Test]
        public void WontUpdateCustomerBecauseNameIsNull()
        {
            Customer customer = new Customer()
            {
                Id = "123",
                Name = null
            };

            customerService.Update(customer).Wait();

            customerRepositoryMock.Verify(
                x => x.StartConnection(),
                Times.Never);

            customerRepositoryMock.Verify(
                x => x.Update(customer),
                Times.Never);
        }

        [Test]
        public void WontUpdateCustomerBecauseNameIsEmpty()
        {
            Customer customer = new Customer()
            {
                Id = "123",
                Name = ""
            };

            customerService.Update(customer).Wait();

            customerRepositoryMock.Verify(
                x => x.StartConnection(),
                Times.Never);

            customerRepositoryMock.Verify(
                x => x.Update(customer),
                Times.Never);
        }

        [Test]
        public void WontUpdateCustomerBecauseNameIsWhiteSpace()
        {
            Customer customer = new Customer()
            {
                Id = "123",
                Name = " "
            };

            customerService.Update(customer).Wait();

            customerRepositoryMock.Verify(
                x => x.StartConnection(),
                Times.Never);

            customerRepositoryMock.Verify(
                x => x.Update(customer),
                Times.Never);
        }
    }
}
