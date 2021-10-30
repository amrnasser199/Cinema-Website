using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vidly.Models;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private movieDB _Context;
        private readonly IMapper _mapper;
       
        //public CustomersController()
        //{
        //    _Context = new movieDB();
        //}
        public CustomersController(IMapper mapper)
        {
            
            _mapper = mapper;
            _Context = new movieDB();

        }
        // GET/api/customer
        public IHttpActionResult GetCustomers(string query=null)
        {
            var CustomerQuery = _Context.customers.Include(m => m.membershipType);
            if (!string.IsNullOrWhiteSpace(query))
                CustomerQuery = CustomerQuery.Where(m => m.Name.Contains(query));
            
            var CustomerDto=CustomerQuery.ToList().Select(_mapper.Map<Customer,CustomerDto>);
            //return _Context.customers.ToList().Select(_mapper.Map<Customer, CustomerDto>);
            return Ok(CustomerDto);
        }
        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _Context.customers.SingleOrDefault(a => a.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Customer, CustomerDto>(customer));
        }
        // POST /api/customers
        [HttpPost]
        public IHttpActionResult createcustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }
            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);
            _Context.customers.Add(customer);
            _Context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }
        // put /api/customers/1
        [HttpPut]
        public IHttpActionResult Updatecustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerInDb = _Context.customers.SingleOrDefault(a => a.Id == id);
            if (customerInDb == null)
            {
                return NotFound();
            }
            _mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);
            //customerInDb.Name = customer.Name;
            //customerInDb.BirthDate = customer.BirthDate;
            //customerInDb.IsSubscribeToNewsLetter = customer.IsSubscribeToNewsLetter;
            //customerInDb.MembershipTypeId = customer.MembershipTypeId;
            _Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Deletecustomer(int id)
        {
            var customerInDb = _Context.customers.SingleOrDefault(a => a.Id == id);
            if (customerInDb == null)
            {
                return NotFound();
            }
            _Context.customers.Remove(customerInDb);
            _Context.SaveChanges();
            return Ok();
        }


    }
}
