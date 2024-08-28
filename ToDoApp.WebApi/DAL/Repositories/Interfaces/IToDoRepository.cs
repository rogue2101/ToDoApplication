using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.WebApi.DAL.Entities;

namespace ToDo.WebApi.DAL.Repositories.Interfaces
{
    public interface IToDoRepository
    {
        Task<List<ToDoEntity>> GetAllAsync();
        Task<ToDoEntity> GetByIdAsync(int Id);

        Task<ToDoEntity> PostAsync(ToDoEntity toDoEntity);

        Task<ToDoEntity> PutAsync(int Id, ToDoEntity toDoEntity);

        Task<bool> DeleteAsync(int Id);

    }
}
