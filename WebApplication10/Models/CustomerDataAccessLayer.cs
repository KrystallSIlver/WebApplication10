using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication10.Models
{
    public class CustomerDataAccessLayer
    {
        testTaskdbContext db = new testTaskdbContext();
        #region Customer
        public IEnumerable<Customer> GetAllCustomers()
        {
            try
            {
                return db.Customer.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new employee record   
        public int AddCustomer(Customer customer)
        {
            try
            {
                db.Customer.Add(customer);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar employee  
        public int UpdateCustomer(Customer customer)
        {
            try
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular employee  
        public Customer GetCustomerData(int id)
        {
            try
            {
                Customer customer = db.Customer.Find(id);
                return customer;
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record of a particular employee  
        public int DeleteCustomer(int id)
        {
            try
            {
                Customer customer = db.Customer.Find(id);
                db.Customer.Remove(customer);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
        #endregion
        #region Lists
        //To Get the list of Cities 
        public List<Contact> GetContacts()
        {
            List<Contact> lstCnts = new List<Contact>();
            lstCnts = (from ContactList in db.Contact select ContactList).ToList();
            return lstCnts;
        }
        public List<User> GetUsers()
        {
            List<User> lstUsrs = new List<User>();
            lstUsrs = (from UserList in db.User select UserList).ToList();
            return lstUsrs;
        }
        public List<Department> GetDepartments()
        {
            List<Department> lstDprts = new List<Department>();
            lstDprts = (from DepartmentList in db.Department select DepartmentList).ToList();
            return lstDprts;
        }
        #endregion
    }
}
