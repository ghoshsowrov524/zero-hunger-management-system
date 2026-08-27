using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class CollectRequestRepo
    {
        ZeroHungerDbContext db;
        public CollectRequestRepo(ZeroHungerDbContext db)
        {
            this.db = db;
        }
        public List<CollectRequest> Get()
        {
            return db.CollectRequests.ToList();
        }
        public CollectRequest Get(int id)
        {
            return db.CollectRequests.Find(id);

        }
        public bool Create(CollectRequest CollectRequest)
        {
            db.CollectRequests.Add(CollectRequest);
            return db.SaveChanges() > 0;
        }
        public bool Update(CollectRequest CollectRequest)
        {
            var ex = Get(CollectRequest.Id);
            ex.RestaurantId = CollectRequest.RestaurantId;
            ex.EmployeeId = CollectRequest.EmployeeId;
            ex.RequestDate = CollectRequest.RequestDate;
            ex.MaximumPreserveTime = CollectRequest.MaximumPreserveTime;
            ex.Status = CollectRequest.Status;
            ex.CollectedDate = CollectRequest.CollectedDate;
            ex.CompletedDate = CollectRequest.CompletedDate;

            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var ex = Get(id);
            db.CollectRequests.Remove(ex);
            return db.SaveChanges() > 0;
        }
        public bool UpdateStatus(int id, string status)
        {
            var request = db.CollectRequests.Find(id);

            if (request == null)
                return false;

            request.Status = status;

            return db.SaveChanges() > 0;
        }
        public bool AssignEmployee(int requestId, int employeeId)
        {
            var request = db.CollectRequests.Find(requestId);

            if (request == null)
                return false;

            request.EmployeeId = employeeId;
            request.Status = "Assigned";

            return db.SaveChanges() > 0;
        }
        public bool MarkCollected(int id)
        {
            var request = db.CollectRequests.Find(id);

            if (request == null)
                return false;

            request.Status = "Collected";
            request.CollectedDate = DateTime.Now;

            return db.SaveChanges() > 0;
        }
        public List<CollectRequest> GetPending()
        {
            return db.CollectRequests
                .Where(x => x.Status == "Pending")
                .ToList();
        }
        public List<CollectRequest> GetAccepted()
        {
            return db.CollectRequests
                .Where(x => x.Status == "Accepted")
                .ToList();
        }
        public List<CollectRequest> GetAssigned()
        {
            return db.CollectRequests
                .Where(x => x.Status == "Assigned")
                .ToList();
        }
        public List<CollectRequest> GetCollected()
        {
            return db.CollectRequests
                .Where(x => x.Status == "Collected")
                .ToList();
        }
        public List<CollectRequest> GetCompleted()
        {
            return db.CollectRequests
                .Where(x => x.Status == "Completed")
                .ToList();
        }
        public List<CollectRequest> GetByRestaurant(int restaurantId)
        {
            return db.CollectRequests
                .Where(x => x.RestaurantId == restaurantId)
                .ToList();
        }
        public List<CollectRequest> GetByEmployee(int employeeId)
        {
            return db.CollectRequests
                .Where(x => x.EmployeeId == employeeId)
                .ToList();
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
