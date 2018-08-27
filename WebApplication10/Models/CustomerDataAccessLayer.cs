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
               /*  int i = 1;
                  customer.CustomerId = db.Customer.Max(x => x.CustomerId)+1;
                  foreach (var c in customer.Contacts)
                  {

                      c.CustomerId = customer.CustomerId;
                      try
                      {
                          c.ContactId = db.Contact.Max(x => x.ContactId) + i;
                          i++;
                      }
                      catch
                      {
                          c.ContactId = 0;
                      }
                  }*/
                
              /*foreach (Department d in customer.Departments)
                {
                     int i = 1;

                    if (d.DepartmentId == 0)
                    {
                     try{
                         d.DepartmentId = db.Department.Max(x=>x.DepartmentId)+i;
                         }
                     catch {
                         d.DepartmentId = 0;
                     }
                    d.UserId = 0;
                       db.Department.Add(d);
                        db.SaveChanges();
                    }
                    i++;
                }*/

              /*  foreach (User u in customer.Users)
                {
                     int i = 1;
                     if (u.UserId == 0)
                    {
                      if (u.DepartmentId == 0)
                      {
                          foreach (Department d in customer.Departments)
                          {
                              if (d.tempid == u.tempid)
                              {
                                  u.DepartmentId = d.DepartmentId;
                                  break;
                              }
                          }
                      }
                       try
                       {
                           u.UserId = db.User.Max(x=>x.UserId)+i;
                       }
                       catch
                       {
                           u.UserId = 0;
                       }

                    db.User.Add(u);
                    db.SaveChanges();
                    }
                    i++;
                }*/
                
                    foreach (Department d in customer.Departments)
                    {
                        foreach (User u in customer.Users)
                        {
                            if (u.tempudid == d.tempdid)
                            {
                            //    u.DepartmentId = d.DepartmentId;
                            // db.Entry(u).State = EntityState.Modified;
                                d.Users.Add(u);                                                                                     
                            }                        
                        }
                    }
                
                
                db.Customer.Add(customer);

                /*   foreach (Department d in customer.Departments)
                   {
                       foreach (User u in d.Users)
                       {
                           if (d.tempduid == u.tempuid)
                           {
                               d.Manager = u;
                           }
                       }
                   }
                   /*   foreach (Department d in customer.Departments)
                      {

                          foreach (User u in customer.Users)
                          {
                              if (u.tempuid == d.tempduid)
                              {
                                  d.UserId = u.UserId;
                              }

                          }

                      }
                  /*    foreach (User u in customer.Users)
                      {
                          foreach (Department d in customer.Departments)
                          {
                              if (u.tempudid == d.tempdid)
                              {
                                  u.DepartmentId = d.DepartmentId;
                              }
                          }
                      }*/
                /*  foreach (Department d in customer.Departments)
                  {
                      foreach (User u in d.Users)
                      {
                          if (d.tempduid == u.tempuid)
                          {
                              d.UserId = u.UserId;
                              //db.Entry(d).State = EntityState.Modified;

                          }
                      }

                  }*/
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
        public int UpdateCustomer(Customer customer)
        {
           /* foreach (Contact c in customer.Contacts)
            {                
                    c.CustomerId = customer.CustomerId; 
            }*/
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

           /* try
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }*/
        }
        //Get the details of a particular employee  
        public Customer GetCustomerData(int id)
        {
            try
            {
                Customer customer = db.Customer.Include(c => c.Contacts)
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
        public int AddContact(Customer customer) {
            try
            {

                return 1;
            }
            catch
            {
                throw;
            }
        }
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
