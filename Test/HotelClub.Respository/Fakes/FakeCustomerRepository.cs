using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using HotelClub.Core;
using HotelClub.Interface;

namespace HotelClub.RepositoryUnitTest.Fakes
{
    public class FakeCustomerRepository : IRepository<Customer>
    {
        public FakeCustomerRepository()
        {
            var address = new Address
            {
                Id = 1,
                AddressLine1 = "My address info1",
                AddressLine2 = "My address info2",
                Country = new Country { Id = 1, Name = "Canada" },
                State = "Toronto",
                Zip = "00000000"
            };


            CustomerSample = new Customer
            {
                Id = 1,
                Name = "Rafael Fernandes",
                Email = "contact@rafaelfernandes.net",
                Address = new Collection<Address> { address }
            };          
        }

        public Customer CustomerSample;
        public bool WasAdded { get; set; }
        public bool WasUpdated { get; set; }
        public bool WasDeleted { get; set; }
        public bool WasSaved { get; set; }
       
        public Customer GetById(int id)
        {
            return CustomerSample;
        }

        public IEnumerable<Customer> GetAll()
        {
            return new List<Customer> { CustomerSample };
        }

        public IEnumerable<Customer> Query(Expression<Func<Customer, bool>> filter)
        {
            return new List<Customer> { CustomerSample };
        }

        public void Add(Customer entity)
        {
            WasAdded = true;
        }

        public void Update(Customer entity)
        {
            WasUpdated = true;
        }

        public void Remove(int id)
        {
            WasDeleted = true;
        }

        public void Remove(Customer entity)
        {
            WasDeleted = true;
        }

        public void Save()
        {
            WasSaved = true;
        }

        public void Detach(Customer entity)
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}