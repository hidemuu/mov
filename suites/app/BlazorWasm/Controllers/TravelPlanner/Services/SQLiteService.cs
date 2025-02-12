using Microsoft.JSInterop;

namespace TravelPlannerApp.Controllers.Services
{
    public class SQLiteService
    {
        private readonly IJSRuntime _js;

        public SQLiteService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task InitializeDatabaseAsync()
        {
            await _js.InvokeVoidAsync("initDb");
        }

        public async Task ExecuteSqlAsync(string sql)
        {
            await _js.InvokeVoidAsync("executeSql", sql);
        }

        public async Task<List<Dictionary<string, object>>> QuerySqlAsync(string sql)
        {
            var result = await _js.InvokeAsync<List<Dictionary<string, object>>>("querySql", sql);
            return result ?? new List<Dictionary<string, object>>();
        }
    }

}
