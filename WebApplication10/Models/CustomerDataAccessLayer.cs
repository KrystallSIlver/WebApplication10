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
                return db.Customer
                    .Include(c=>c.Contacts)
                    .Include(c=>c.Departments)
                    .Include(c=>c.Users)                    
                    .ToList();
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
                    foreach (Department d in customer.Departments)
                    {
                        foreach (User u in customer.Users)
                        {
                            if (u.tempudid == d.tempdid)
                            {
                                d.Users.Add(u);                                                                                     
                            }                        
                        }
                    }
                
                
                db.Customer.Add(customer);
                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    foreach (Department d in customer.Departments)
                    {
                        d.UserId = null;
                    }
                    db.SaveChanges();
                }
                foreach (Department d in customer.Departments)
                {
                    foreach (User u in d.Users)
                    {
                        if (d.tempduid == u.tempuid)
                        {
                            User tUser = db.User.FirstOrDefault(p => p == u);
                            Console.WriteLine(tUser);
                            d.User = tUser;
                            d.UserId = tUser.UserId;
                            db.Entry(d).State = EntityState.Modified;
                            
                        }
                    }
                }
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar employee  

            //Сделать Update всей модели!
        public int UpdateCustomer(FullData fullData)
        {
            //Remove
            foreach (int i in fullData.contactstodelete)
            {
              //Contact c = db.Contact.FirstOrDefault(x => x.ContactId == i);
              db.Contact.Remove(db.Contact.FirstOrDefault(x => x.ContactId == i));
            }
            foreach (int y in fullData.depstodelete)
            {
                Department d = db.Department.Include(u=>u.Users).FirstOrDefault(x => x.DepartmentId == y);
                              
                    db.Department.Remove(d);
                
                
            }
            try
            {
                foreach (int b in fullData.userstodelete)
                {
                    //User u = db.User.FirstOrDefault(x => x.UserId == b);
                    db.User.Remove(db.User.FirstOrDefault(x => x.UserId == b));
                }
            }
            catch
            {

            }

          try
            {
                db.Entry(fullData.customer).State = EntityState.Modified;
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
                Customer customer = db.Customer
                    .Include(c => c.Contacts)
                    .Include(d=>d.Departments)
                    .Include(u=>u.Users)
                    .FirstOrDefault(c => c.CustomerId == id);
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
        public IEnumerable<User> GetUsers()
        {
            List<User> lstUsrs = new List<User>();
            lstUsrs = (from UserList in db.User select UserList).ToList();
            return lstUsrs;
        }
        public IEnumerable<Department> GetDepartments()
        {
            List<Department> lstDprts = new List<Department>();
            lstDprts = (from DepartmentList in db.Department select DepartmentList).ToList();
            return lstDprts;
        }
        #endregion
    }
}
