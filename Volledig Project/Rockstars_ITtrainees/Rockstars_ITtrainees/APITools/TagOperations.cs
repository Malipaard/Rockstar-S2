using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ITtrainees.Models;
using ITtrainees.MVC.Models.Home;
using Newtonsoft.Json;
using static ITtrainees.MVC.APITools.APIHelper;
using ITtrainees.MVC.APITools;
using System.Text;

namespace ITtrainees.MVC.APITools
{
    public class TagOperations
    {
        public static async void Create(string tagName)
        {
            Tag tag = new Tag() { TagId = 0, TagName = tagName };
            var stringContent = new StringContent(JsonConvert.SerializeObject(tag), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await ApiClient.PostAsync($"tag", stringContent);
            Console.WriteLine(response.StatusCode.ToString());
        }

        public static async Task<List<Tag>> GetAll()
        {
            HttpResponseMessage response = await ApiClient.GetAsync($"tag");
            if (response.IsSuccessStatusCode)
            {
                var listJSON = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<Tag>>(listJSON);
                return list;
            }
            return null;
        }

        public static async Task<Tag> Get(int id)
        {
            HttpResponseMessage response = await ApiClient.GetAsync($"tag/{ id }");
            if (response.IsSuccessStatusCode)
            {
                var tagJSON = await response.Content.ReadAsStringAsync();
                var tag = JsonConvert.DeserializeObject<Tag>(tagJSON);
                return tag;
            }
            return null;
        }

        public static async void Update(Tag tag)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(tag), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await ApiClient.PutAsync($"tag", stringContent);
        }

        public static async void Delete(int id)
        {
            HttpResponseMessage response = await ApiClient.DeleteAsync($"tag/{ id }");
        }
    }
}
