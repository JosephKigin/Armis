using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess
{
    public static class DataAccessGeneric
    {
        /*
         * SUMMARY
         * This is a generic class intended to be used by every DataAccess class.  Each method will create a new DataAccessGeneric and feed it a type and a path to the API controller it wants to access.  DataAccessGeneric will then handle getting that information, handling the error if there is one, and deserializing the info from the API into the type specified.
         */

        //GET
        public static async Task<T> HttpGetRequest<T>(string aPath)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(aPath);
                if (!response.IsSuccessStatusCode) { throw new Exception(response.ReasonPhrase + ": " + await response.Content.ReadAsStringAsync()); }
                return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
            }
        }

        //This is for gets with a different return type than the parameter type being passed in.
        public static async Task<T> HttpGetRequest<T, U>(string aPath, U aModel)
        {
            using (var client = new HttpClient())
            {
                //StringContent data = new StringContent(, Encoding.UTF8, "application/json");
                var response = await client.GetAsync(aPath + JsonSerializer.Serialize(aModel));

                if (!response.IsSuccessStatusCode) { throw new Exception(response.ReasonPhrase + ": " + await response.Content.ReadAsStringAsync()); }
                
                return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
            }
        }

        //POST
        public static async Task<T> HttpPostRequest<T>(string aPath, T aModel)
        {
            using (var client = new HttpClient())
            {
                StringContent data = new StringContent(JsonSerializer.Serialize(aModel), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(aPath, data);

                if (!response.IsSuccessStatusCode) { throw new Exception(response.ReasonPhrase + ": " + await response.Content.ReadAsStringAsync()); }

                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<T>(responseString);

                return result;
            }
        }

        //This is for posts that have a different return type than the parameter type being passed in.
        public static async Task<T> HttpPostRequest<T, U>(string aPath, U aModel)
        {
            using (var client = new HttpClient())
            {
                StringContent data = new StringContent(JsonSerializer.Serialize(aModel), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(aPath, data);

                if (!response.IsSuccessStatusCode) { throw new Exception(response.ReasonPhrase + ": " + await response.Content.ReadAsStringAsync()); }

                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<T>(responseString);

                return result;
            }
        }

        //PUT
        public static async Task<T> HttpPutRequest<T>(string aPath, T aModel)
        {
            using (var client = new HttpClient())
            {
                StringContent data = new StringContent(JsonSerializer.Serialize(aModel), Encoding.UTF8, "application/json");
                var response = await client.PutAsync(aPath, data);

                if (!response.IsSuccessStatusCode) { throw new Exception(response.ReasonPhrase + ": " + await response.Content.ReadAsStringAsync()); }

                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<T>(responseString);

                return result;
            }
        }

        //DELETE
        public static async Task<string> HttpDeleteRequest(string aPath)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync(aPath);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "Deleted successful.";
                }
                else
                {
                    throw new Exception(response.ReasonPhrase + ": " + await response.Content.ReadAsStringAsync());
                }
            }
        }

    }
}
