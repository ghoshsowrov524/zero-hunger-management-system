using AutoMapper;
using BLL.Models;
using DAL.EF.Tables;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public  class CollectRequestService
    {
        CollectRequestRepo repo;
        EmployeeRepo employeeRepo;
        IMapper mapper;
        public CollectRequestService(CollectRequestRepo repo, EmployeeRepo employeeRepo, IMapper mapper)
        {
            this.repo = repo;
            this.employeeRepo = employeeRepo;
            this.mapper = mapper;
        }
        public List<CollectRequestModel> Get()
        {
            var data = repo.Get();
            return mapper.Map<List<CollectRequestModel>>(data);
        }
        public CollectRequestModel Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<CollectRequestModel>(data);
        }
        public bool Create(CollectRequestModel model)
        {
            var mapped = mapper.Map<CollectRequest>(model);
            return repo.Create(mapped);
        }
        public bool Update(CollectRequestModel model)
        {
            var mapped = mapper.Map<CollectRequest>(model);
            return repo.Update(mapped);
        }
        public bool Delete(int id)
        {

            return repo.Delete(id);
        }
        public bool Accept(int id)
        {
            var request = repo.Get(id);

            if (request == null)
                return false;

            if (request.Status != "Pending")
                return false;

            if (DateTime.Now > request.MaximumPreserveTime)
                return false;

            return repo.UpdateStatus(id, "Accepted");
        }
        public bool AssignEmployee(int requestId, int employeeId)
        {
            var request = repo.Get(requestId);

            if (request == null)
                return false;

            var employee = employeeRepo.Get(employeeId);

            if (employee == null)
                return false;

            if (employee.IsActive == false)
                return false;

            if (request.Status != "Accepted")
                return false;

            return repo.AssignEmployee(requestId, employeeId);
        }
        public bool MarkCollected(int id)
        {
            var request = repo.Get(id);

            if (request == null)
                return false;

            if (request.Status != "Assigned")
                return false;

            return repo.MarkCollected(id);
        }
        public List<CollectRequestModel> GetPending()
        {
            var data = repo.GetPending();

            return mapper.Map<List<CollectRequestModel>>(data);
        }
        public List<CollectRequestModel> GetAccepted()
        {
            var data = repo.GetAccepted();

            return mapper.Map<List<CollectRequestModel>>(data);
        }
        public List<CollectRequestModel> GetAssigned()
        {
            var data = repo.GetAssigned();

            return mapper.Map<List<CollectRequestModel>>(data);
        }
        public List<CollectRequestModel> GetCollected()
        {
            var data = repo.GetCollected();

            return mapper.Map<List<CollectRequestModel>>(data);
        }
        public List<CollectRequestModel> GetCompleted()
        {
            var data = repo.GetCompleted();

            return mapper.Map<List<CollectRequestModel>>(data);
        }
        public List<CollectRequestModel> GetByRestaurant(int restaurantId)
        {
            var data = repo.GetByRestaurant(restaurantId);

            return mapper.Map<List<CollectRequestModel>>(data);
        }
        public List<CollectRequestModel> GetByEmployee(int employeeId)
        {
            var data = repo.GetByEmployee(employeeId);

            return mapper.Map<List<CollectRequestModel>>(data);
        }
    }
}
