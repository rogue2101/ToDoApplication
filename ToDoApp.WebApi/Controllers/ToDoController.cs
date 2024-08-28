using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.WebApi.DAL.DatabaseContexts;
using ToDo.WebApi.Services.Interfaces;
using ToDoApp.WebApi.ApiResponse;
using ToDoApp.WebApi.Models.RequestModel;
using ToDoApp.WebApi.Models.ResponseModel;
using ToDoApp.WebApi.Services.Implementations;

namespace DAL.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoServices)
        {
            _toDoService = toDoServices;
        }
        // GET: api/ToDoList
        [HttpGet]
        public async Task<ActionResult<List<ToDoResponseModel>>> Get()
        {
            return await _toDoService.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoResponseModel>> GetById(int id)
        {
            return await _toDoService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<ToDoResponseModel>> Post(ToDoRequestModel toDoRequestModel)
        {
            return await _toDoService.PostAsync(toDoRequestModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ToDoResponseModel>> Put(int id, ToDoRequestModel toDoRequestModel)
        {
            return await _toDoService.PutAsync(id, toDoRequestModel);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _toDoService.DeleteAsync(id);
        }

    }
}
