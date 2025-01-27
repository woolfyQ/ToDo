using Core.Entity;

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
        //public async Task<bool> DeleteTask(ToDoList toDoList)
        //{
        //    var reponse = await _httpClient.DeleteAsync("api/ToDoTask/Delete", toDoList);
        //    if (reponse.IsSuccessStatusCode)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //        throw new Exception("Delete client service Error");
        //    }




    }
}
