using AutoMapper;
using BLL.Models;
using DAL.EF.Tables;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class DistributionService
    {
        CollectRequestRepo requestRepo;
        DistributionRepo repo;
        IMapper mapper;
        public DistributionService(DistributionRepo repo, CollectRequestRepo requestRepo, IMapper mapper)
        {
            this.repo = repo;
            this.requestRepo = requestRepo;
            this.mapper = mapper;
        }
        public List<DistributionModel> Get()
        {
            var data = repo.Get();
            return mapper.Map<List<DistributionModel>>(data);
        }
        public DistributionModel Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<DistributionModel>(data);
        }
        public bool Create(DistributionModel model)
        {
            var request = requestRepo.Get(model.CollectRequestId);

            if (request == null)
                return false;

            if (request.Status != "Collected")
                return false;

            var mapped = mapper.Map<Distribution>(model);

            mapped.DistributionDate = DateTime.Now;

            var result = repo.Create(mapped);

            if (result)
            {
                requestRepo.Complete(model.CollectRequestId);
            }

            return result;
        }
        public bool Update(DistributionModel model)
        {
            var mapped = mapper.Map<Distribution>(model);
            return repo.Update(mapped);
        }
        public bool Delete(int id)
        {

            return repo.Delete(id);
        }
    }
}
