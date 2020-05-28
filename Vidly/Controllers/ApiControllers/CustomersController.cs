using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DtosModels;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.ApiControllers
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // /api/customers (GET)
        [HttpGet]
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery    
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDtos);
        }

        // /api/customers/1 (GET)
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers
                .Include(c=>c.MembershipType)
                .ToList()
                .SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // /api/customers (POST)
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // /api/customers (PUT)
        [HttpPut]
        public IHttpActionResult UpdateCustomer(CustomerDto customerDto, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers
                .ToList()
                .SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();

            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);
            _context.SaveChanges();
            return Ok();
        }

        // /api/customers (DELETE)
        [HttpDelete]
        public IHttpActionResult Delete(int id) {

            var customerInDb = _context.Customers
                .ToList()
                .SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
