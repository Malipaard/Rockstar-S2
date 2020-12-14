using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static ITtrainees.MVC.APITools.APIHelper;

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
    }
}
