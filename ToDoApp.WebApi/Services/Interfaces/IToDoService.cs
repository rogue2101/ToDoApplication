using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.DAL.Repositories.Interfaces;
using ToDoApp.WebApi.DAL.Entities;
using ToDoApp.WebApi.Models.ResponseModel;
using ToDoApp.WebApi.Models.RequestModel;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.WebApi.ApiResponse;

namespace ToDo.WebApi.Services.Interfaces
{
    public interface IToDoService
    {
        Task<ActionResult<List<ToDoResponseModel>>> GetAsync();
        Task<ActionResult<ToDoResponseModel>> GetByIdAsync(int id);
        Task<ActionResult<ToDoResponseModel>> PostAsync(ToDoRequestModel toDoRequestModel);
        Task<ActionResult<ToDoResponseModel>> PutAsync(int id,ToDoRequestModel toDoRequestModel);
        Task<ActionResult> DeleteAsync(int id);
    }
}
