using System.Net.Http.Json;

namespace Proxy.Examples
{
    public class HttpProxy<TEntity>(HttpClient client) : IHttpProxy<TEntity> where TEntity : class
    {
        private readonly string controller = typeof(TEntity).Name;

        public async Task<TEntity?> GetAsync()
        {
            return await client.GetFromJsonAsync<TEntity>(BuildRequestUri(nameof(GetAsync)));
        }

        public async Task<IEnumerable<TEntity>?> GetListAsync()
        {
            return await client.GetFromJsonAsync<IEnumerable<TEntity>>(BuildRequestUri(nameof(GetListAsync)));
        }

        public async Task<TEntity?> PutAsync(TEntity entity)
        {
            var httpResponseMessage = await client.PutAsJsonAsync(BuildRequestUri(nameof(PutAsync)), entity);
            return httpResponseMessage.IsSuccessStatusCode ? await httpResponseMessage.Content.ReadFromJsonAsync<TEntity>() : null;
        }

        public async Task<TEntity?> PostAsync(TEntity entity)
        {
            var httpResponseMessage = await client.PostAsJsonAsync(BuildRequestUri(nameof(PostAsync)), entity);
            return httpResponseMessage.IsSuccessStatusCode ? await httpResponseMessage.Content.ReadFromJsonAsync<TEntity>() : null;
        }

        private string BuildRequestUri(string action)
        {
            return $"{controller}/{action}";
        }
    }

    internal interface IHttpProxy<TEntity> where TEntity : class
    {
        public Task<TEntity?> GetAsync();
        public Task<IEnumerable<TEntity>?> GetListAsync();
        public Task<TEntity?> PutAsync(TEntity entity);
        public Task<TEntity?> PostAsync(TEntity entity);
    }
}
