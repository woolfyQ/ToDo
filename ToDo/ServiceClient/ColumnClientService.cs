using Core.Entity;

namespace ToDo.ServiceClient
{
    public class ColumnClientService
    {
        private readonly HttpClient _httpClient;

        public ColumnClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<bool> Create(Column column)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Column/Create", column);
            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
                throw new Exception("Create method ClientService");
            }

        }

        public async Task<IEnumerable<Column>> GetAll()
        {
            var response = await _httpClient.GetAsync("api/Column/GelAll");
            if (response.IsSuccessStatusCode)
            {
                var columns = await response.Content.ReadFromJsonAsync<List<Column>>();
                return columns ?? new List<Column>();
            }
            else
            {
                throw new Exception("Failed to get columns");
            }
        }

        public async Task<bool>Update(Column column)
        {

            var response = await _httpClient.PutAsJsonAsync("api/Column/Update", column);
            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
                throw new Exception("Update Client Error");
            }


        }
         public async Task<bool>Delete(Guid Id,CancellationToken cancellationToken)
        {

            var response = await _httpClient.DeleteAsync($"api/Column/Delete/{Id}", cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
                throw new Exception("delete client service error");
            }
            
        }

        public async Task<bool> GetById(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync("api/Column/GetById", cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return true;


            }
            else
            {
                return false;
            }
        }


    }
}
