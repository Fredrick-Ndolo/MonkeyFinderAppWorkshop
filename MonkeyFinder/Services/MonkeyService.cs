using MonkeyFinder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Json;

namespace MonkeyFinder.Services
{
    public class MonkeyService
    {
        HttpClient _httpClient;
        public MonkeyService()
        {
            _httpClient = new HttpClient();
        }
        List<Monkey> monkeyList = new ();
        public async Task<List<Monkey>> GetMonkeys()
        {
            var response = await _httpClient.GetAsync("https://www.montemagno.com/monkeys.json");
            
            if (response.IsSuccessStatusCode)
            {
                monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
            }

            if (monkeyList?.Count > 0)
                return monkeyList;

            return monkeyList;
        }
    }
}
