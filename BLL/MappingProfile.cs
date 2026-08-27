using AutoMapper;
using BLL.Models;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeModel>().ReverseMap();
            CreateMap<Restaurant, RestaurantModel>().ReverseMap();
            CreateMap<Distribution, DistributionModel>().ReverseMap();
            CreateMap<FoodItem, FoodItemModel>().ReverseMap();
            CreateMap<CollectRequest, CollectRequestModel>().ReverseMap();

        }
    }
}
