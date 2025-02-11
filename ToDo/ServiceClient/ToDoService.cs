﻿using Core.Entity;

namespace ToDo.ServiceClient
{
    public class ToDoService
    {
        private readonly HttpClient _httpClient;

        public ToDoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateTask(ToDoList toDoList)
        {
            var response = await _httpClient.PostAsJsonAsync("api/ToDoTask/Create",toDoList);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
                throw new Exception("Client CreateTask method error");
            }
        }
        
        public async Task<bool> UpdateTask(ToDoList toDoList)
        {
            var response = await _httpClient.PutAsJsonAsync("api/ToDoTask/Update", toDoList);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
                throw new Exception("Update client service Error");
            }

        }

        public async Task<bool>Delete(Guid Id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.DeleteAsync($"api/ToDoTask/Delete/{Id}", cancellationToken );
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public async Task<IEnumerable<ToDoList>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ToDoList>>("api/ToDoTask/GetAll");
        }

       

    }
}
