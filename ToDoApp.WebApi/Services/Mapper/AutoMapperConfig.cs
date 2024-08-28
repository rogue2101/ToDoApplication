using AutoMapper;
using ToDoApp.WebApi.DAL.Entities;
using ToDoApp.WebApi.Models.RequestModel;
using ToDoApp.WebApi.Models.ResponseModel;

namespace ToDoApp.WebApi.Services.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ToDoEntity, ToDoRequestModel>().ReverseMap();
            CreateMap<ToDoEntity, ToDoResponseModel>().ReverseMap();
        }
    }
}
