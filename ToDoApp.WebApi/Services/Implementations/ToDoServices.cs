using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.DAL.Repositories.Interfaces;
using ToDo.WebApi.Services.Interfaces;
using ToDoApp.WebApi.DAL.Entities;
using ToDoApp.WebApi.Models.RequestModel;
using ToDoApp.WebApi.Models.ResponseModel;

namespace ToDoApp.WebApi.Services.Implementations
{
    internal class ToDoServices : IToDoService
    {
        private readonly IToDoRepository _repository;
        private readonly IMapper _mapper;
        public ToDoServices(IToDoRepository toDoRepository, IMapper mapper) 
        {
            _mapper = mapper;
            _repository = toDoRepository;
        }

        public async Task<ActionResult<List<ToDoResponseModel>>> GetAsync()
        {
            List<ToDoEntity> toDoList = await _repository.GetAllAsync();
            return _mapper.Map<List<ToDoResponseModel>>(toDoList);
        }
        public async Task<ActionResult<ToDoResponseModel>> GetByIdAsync(int id)
        {
            ToDoEntity toDo = await _repository.GetByIdAsync(id);
            return _mapper.Map<ToDoResponseModel>(toDo);
        }
        public async Task<ActionResult<ToDoResponseModel>> PostAsync(ToDoRequestModel toDoRequestModel)
        {
            ToDoEntity toDoEntity = await _repository.PostAsync(_mapper.Map<ToDoEntity>(toDoRequestModel));
            ToDoEntity toDo = await _repository.GetByIdAsync(toDoRequestModel.Id);
            return _mapper.Map<ToDoResponseModel>(toDo);
        }
        public async Task<ActionResult<ToDoResponseModel>> PutAsync(int id, ToDoRequestModel toDoRequestModel)
        {
            ToDoEntity toDoEntity = await _repository.PutAsync(id, _mapper.Map<ToDoEntity>(toDoRequestModel));
            ToDoEntity toDo = await _repository.GetByIdAsync(id);
            return _mapper.Map<ToDoResponseModel>(toDo);
        }

        public async Task<ActionResult> DeleteAsync(int id)
        {
            bool result = await _repository.DeleteAsync(id);
            if (!result)
            {
                return new NotFoundResult();
            }
            return new OkResult();
        }
    }
}
