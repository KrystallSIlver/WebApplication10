using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication10.Models
{
    public class ContactDataAccesLayer
    {
        testTaskdbContext db = new testTaskdbContext();
        #region Contact
        public IEnumerable<Contact> GetAllContacts()
        {
            try
            {
                return db.Contact.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new employee record   
        public int AddEmployee(Contact contact)
        {
            try
            {
                db.Contact.Add(contact);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar employee  
        public int UpdateEmployee(Contact contact)
        {
            try
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular employee  
        public Contact GetEmployeeData(int id)
        {
            try
            {
                Contact contact = db.Contact.Find(id);
                return contact;
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record of a particular employee  
        public int DeleteEmployee(int id)
        {
            try
            {
                Contact contact = db.Contact.Find(id);
                db.Contact.Remove(contact);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
