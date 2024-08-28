using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.DAL.DatabaseContexts;
using ToDo.WebApi.DAL.Repositories.Interfaces;
using ToDoApp.WebApi.DAL.Entities;

namespace ToDo.WebApi.DAL.Repositories.Implementations
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoListDatabaseContext _databaseContext;

        public ToDoRepository(ToDoListDatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public async Task<List<ToDoEntity>> GetAllAsync()
        {
            List<ToDoEntity> toDoList = await _databaseContext.ToDos.ToListAsync();
            return toDoList;
        }

        public async Task<ToDoEntity> GetByIdAsync(int id)
        {
            
            ToDoEntity toDo = await _databaseContext.ToDos.FindAsync(id);
            return toDo;
        }

        public async Task<ToDoEntity> PostAsync(ToDoEntity toDoEntity)
        {
            await _databaseContext.ToDos.AddAsync(toDoEntity);
            await _databaseContext.SaveChangesAsync();
            ToDoEntity toDo = await _databaseContext.ToDos.FindAsync(toDoEntity.Id);
            return toDo;
        }

        public async Task<ToDoEntity> PutAsync(int id, ToDoEntity toDoEntity)
        {
            _databaseContext.Update(toDoEntity);
            await _databaseContext.SaveChangesAsync();
            ToDoEntity toDo = await _databaseContext.ToDos.FindAsync(id);
            return toDo;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            ToDoEntity toDo = await _databaseContext.ToDos.FindAsync(id);
            if (toDo == null)
            {
                return false;
            }
            _databaseContext.Remove(toDo);
            _databaseContext.SaveChanges();
            return true;
        }
    }
}
