using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static ITtrainees.MVC.APITools.APIHelper;
using ITtrainees.Models;
using Newtonsoft.Json;
using System.Text;

namespace ITtrainees.MVC.APITools
{
    public static class QuestionOperations
    {
        public static async Task<string> Validate(int id, string answer)
        {
            HttpResponseMessage response = await ApiClient.GetAsync($"question/{ id }/{ answer }");
            if (response.IsSuccessStatusCode)
            {
                string responseMessage = await response.Content.ReadAsStringAsync();
                return responseMessage;
            }
            return null;
        }

        public static async Task<List<Question>> Get(int articleId)
        {
            HttpResponseMessage response = await ApiClient.GetAsync($"question/{ articleId }");
            if (response.IsSuccessStatusCode)
            {
                var listJSON = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<Question>>(listJSON);
                return list;
            }
            return null;
        }
        
        public static async void Create(Question question)
        {
            var jsonQuestion = new StringContent(JsonConvert.SerializeObject(question), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await ApiClient.PostAsync($"question", jsonQuestion);
        }

        public static async void Update(Question question)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(question), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await ApiClient.PutAsync($"question", stringContent);
        }
    }
}
