using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class DistributionRepo
    {
        ZeroHungerDbContext db;
        public DistributionRepo(ZeroHungerDbContext db)
        {
            this.db = db;
        }
        public List<Distribution> Get()
        {
            return db.Distributions.ToList();
        }
        public Distribution Get(int id)
        {
            return db.Distributions.Find(id);

        }
        public bool Create(Distribution Distribution)
        {
            db.Distributions.Add(Distribution);
            return db.SaveChanges() > 0;
        }
        public bool Update(Distribution Distribution)
        {
            var ex = Get(Distribution.Id);
            ex.CollectRequestId = Distribution.CollectRequestId;
            ex.EmployeeId = Distribution.EmployeeId;
            ex.DistributionDate = Distribution.DistributionDate;
            ex.Location = Distribution.Location;
            ex.BeneficiaryCount = Distribution.BeneficiaryCount;
            ex.Remarks = Distribution.Remarks;

            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Distributions.Remove(ex);
            return db.SaveChanges() > 0;
        }
        public bool Complete(int id)
        {
            var request = db.CollectRequests.Find(id);

            if (request == null)
                return false;

            request.Status = "Completed";
            request.CompletedDate = DateTime.Now;

            return db.SaveChanges() > 0;
        }
    }
}
