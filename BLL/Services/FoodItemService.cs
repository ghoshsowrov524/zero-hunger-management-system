using AutoMapper;
using BLL.Models;
using DAL.EF.Tables;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class FoodItemService
    {
        FoodItemRepo repo;
        IMapper mapper;
        public FoodItemService(FoodItemRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public List<FoodItemModel> Get()
        {
            var data = repo.Get();
            return mapper.Map<List<FoodItemModel>>(data);
        }
        public FoodItemModel Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<FoodItemModel>(data);
        }
        public bool Create(FoodItemModel model)
        {
            var mapped = mapper.Map<FoodItem>(model);
            return repo.Create(mapped);
        }
        public bool Update(FoodItemModel model)
        {
            var mapped = mapper.Map<FoodItem>(model);
            return repo.Update(mapped);
        }
        public bool Delete(int id)
        {

            return repo.Delete(id);
        }
    }

}

