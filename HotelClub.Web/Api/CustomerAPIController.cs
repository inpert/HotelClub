using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelClub.Core;
using HotelClub.Interface;
using HotelClub.Web.Data;
using StructureMap;
using StructureMap.Query;

namespace HotelClub.Web.Api
{
    //[Authorize]
    public class CustomerController : ApiController
    {
        private IRepository<Customer> _customers;
        private IApplicationUnit _applicationUnit;

        public CustomerController(IRepository<Customer> customers, IApplicationUnit applicationUnit)
        {
            _customers = customers;
            _applicationUnit = applicationUnit;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Customer> Get()
        {
            return _applicationUnit.Customers.GetAll();
        }

        [HttpGet]
        //[System.Web.Http.Authorize(Roles = "admin, manager, user")]
        [AllowAnonymous]
        public Customer Get(int id)
        {
            var customer = _applicationUnit.Customers.GetById(id);
            if (customer == null)
            {
                throw new HttpRequestException(Request.CreateResponse(HttpStatusCode.NotFound).ToString());
            }

            return customer;
        }

        [HttpPost]
        //[System.Web.Http.Authorize(Roles = "admin, manager")]
        public HttpResponseMessage Post(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _applicationUnit.Customers.Add(customer);
                    _applicationUnit.Customers.Save();

                    HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.Created, customer);
                    result.Headers.Location = new Uri(Url.Link("DefaultApi", new {id = customer.Id}));

                    return result;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        //[System.Web.Http.Authorize(Roles = "admin, manager")]
        public HttpResponseMessage Put(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != customer.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Customer existingCustomer = _applicationUnit.Customers.GetById(customer.Id);
            _applicationUnit.Customers.Detach(existingCustomer);

            // Keep original Created On
            customer.CreatedOn = existingCustomer.CreatedOn;

            // Update Modified On
            customer.ModifiedOn = DateTime.UtcNow;

            _applicationUnit.Customers.Update(customer);

            try
            {
                _applicationUnit.Customers.Save();

                // Return an explicit value to avoid the fail callback
                // begin incorrectly invoked.
                return Request.CreateResponse(HttpStatusCode.OK, "{sucess:'true', verb:'PUT'}");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE api/customerapi/5
        [HttpDelete]
        //[System.Web.Http.Authorize(Roles = "admin, manager")]
        public HttpResponseMessage Delete(int id)
        {
            var customer = _applicationUnit.Customers.GetById(id);
            if (customer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            _applicationUnit.Customers.Remove(customer);

            try
            {
                _applicationUnit.Customers.Save();
                return Request.CreateResponse(HttpStatusCode.OK, customer);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
