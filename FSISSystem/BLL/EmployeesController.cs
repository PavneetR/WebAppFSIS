using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FSISSystem.DAL;
using FSISSystem.ENTITIES;

namespace FSISSystem.BLL
{
    public class EmployeesController
    {
        public Employee FindByPKID(int EmployeeID)
        {
            using (var context = new StarTed())
            {
                return context.Employees.Find(EmployeeID);
            }
        }
        public List<Employee> FindByPartialName(string partialname)
        {
            using (var context = new StarTed())
            {
                IEnumerable<Employee> results =
                    context.Database.SqlQuery<Employee>("Employees_FindByPartialName @PartialName",
                         new SqlParameter("PartialName", partialname));
                return results.ToList();
            }
        }
        public int Add(Employee item)
        {
            using (var context = new StarTed())
            {
                context.Employees.Add(item);
                context.SaveChanges();
                return item.EmployeeID;

            }
        }
        public int Update(Employee item)
        {
            using (var context = new StarTed())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges();
            }
        }
        public int Delete(int employeeid)
        {
            using (var context = new StarTed())
            {
                var existing = context.Employees.Find(employeeid);
                if (existing == null)
                {
                    throw new Exception("Employee has been removed from database");
                }
                context.Employees.Remove(existing);
                return context.SaveChanges();
            }
        }
    }
}
