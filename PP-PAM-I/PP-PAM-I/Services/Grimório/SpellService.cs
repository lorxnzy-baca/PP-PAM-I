using Newtonsoft.Json;
using PP_PAM_I.Models;


namespace PP_PAM_I.Services
{
    public class SpellService
    {
        private readonly HttpClient _httpClient;

        public SpellService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Spell>> GetSpellsAsync(string level = null, string school = null)
        {
            var url = "https://www.dnd5eapi.co/api/spells";
            if (!string.IsNullOrEmpty(level) || !string.IsNullOrEmpty(school))
            {
                url += "?";
                if (!string.IsNullOrEmpty(level))
                    url += $"level={level}&";
                if (!string.IsNullOrEmpty(school))
                    url += $"school={school}&";
                url = url.TrimEnd('&');
            }

            var response = await _httpClient.GetStringAsync(url);
            var spellListResponse = JsonConvert.DeserializeObject<SpellListResponse>(response);
            return spellListResponse.Results;
        }
    }
}
