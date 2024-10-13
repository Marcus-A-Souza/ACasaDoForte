using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CasaDoForte.Controllers
{
    public class ChatController : Controller
    {
        private readonly string apiKey = "SUA_OPENAI_API_KEY";

        [HttpPost]
        public async Task<IActionResult> GetResponseFromAI([FromBody] UserInput input)
        {
            var openAiResponse = await CallOpenAiApi(input.Message);
            return Json(new { response = openAiResponse });
        }

        private async Task<string> CallOpenAiApi(string userMessage)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                var requestBody = new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                    {
                        new { role = "system", content = "Você é um assistente que ajuda com reservas de espaços." },
                        new { role = "user", content = userMessage }
                    },
                    max_tokens = 150
                };

                var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
                var responseString = await response.Content.ReadAsStringAsync();

                dynamic result = JsonConvert.DeserializeObject(responseString);
                return result.choices[0].message.content;
            }
        }
    }

    public class UserInput
    {
        public string Message { get; set; }
    }
}

