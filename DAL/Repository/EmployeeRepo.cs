using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class EmployeeRepo
    {
        ZeroHungerDbContext db;
        public EmployeeRepo(ZeroHungerDbContext db)
        {
            this.db = db;
        }
        public List<Employee> Get()
        {
            return db.Employees.ToList();
        }
        public Employee Get(int id)
        {
            return db.Employees.Find(id);

        }
        public bool Create(Employee Employee)
        {
            db.Employees.Add(Employee);
            return db.SaveChanges() > 0;
        }
        public bool Update(Employee Employee)
        {
            var ex = Get(Employee.Id);
            ex.Name = Employee.Name;
            ex.Phone = Employee.Phone;
            ex.Email = Employee.Email;
            ex.Address = Employee.Address;
            ex.JoiningDate = Employee.JoiningDate;
            ex.IsActive = Employee.IsActive;

            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Employees.Remove(ex);
            return db.SaveChanges() > 0;
        }
    }
}
