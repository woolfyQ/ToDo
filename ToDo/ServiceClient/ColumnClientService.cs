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
            var response = await _httpClient.PostAsJsonAsync("api/Columns/Create", column);
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

        public async Task<bool>Update(Column column)
        {

            var response = await _httpClient.PutAsJsonAsync("api/Columns/Update", column);
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
         public async Task<bool>Delete(CancellationToken cancellationToken)
        {

            var response = await _httpClient.DeleteAsync("api/Columns/Update", cancellationToken);
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
            var response = await _httpClient.GetAsync("api/Columns/GetById", cancellationToken);
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
