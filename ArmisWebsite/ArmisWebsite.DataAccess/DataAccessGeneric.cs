using Microsoft.AspNetCore.Http;
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
        /// <summary>
        /// Basic Get request with one type that defines the type returned.
        /// </summary>
        /// <typeparam name="T">Return & parameter type</typeparam>
        /// <param name="aPath"></param>
        /// <returns></returns>
        public static async Task<T> HttpGetRequest<T>(string aPath, HttpContext anHttpContext)
        {
            using (var client = new HttpClient(new BasicHttpMessageHandler(anHttpContext)))
            {
                var response = await client.GetAsync(aPath);
                if (!response.IsSuccessStatusCode) { throw new Exception(response.ReasonPhrase + ": " + await response.Content.ReadAsStringAsync()); }
                return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
            }
        }

        /// <summary>
        /// Get with a different return type than the parameter type being passed in.
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <typeparam name="U">Parameter type</typeparam>
        /// <param name="aPath"></param>
        /// <param name="aModel"></param>
        /// <returns></returns>
        public static async Task<T> HttpGetRequest<T, U>(string aPath, U aModel, HttpContext anHttpContext)
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
        /// <summary>
        /// Post with a return type that is the same as the parameter type.
        /// </summary>
        /// <typeparam name="T">Return & parameter type</typeparam>
        /// <param name="aPath"></param>
        /// <param name="aModel"></param>
        /// <returns></returns>
        public static async Task<T> HttpPostRequest<T>(string aPath, T aModel, HttpContext anHttpContext)
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

        /// <summary>
        /// Post that has a different return type than the parameter type being passed in.
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <typeparam name="U">Parameter type</typeparam>
        /// <param name="aPath"></param>
        /// <param name="aModel"></param>
        /// <returns></returns>
        public static async Task<T> HttpPostRequest<T, U>(string aPath, U aModel, HttpContext anHttpContext)
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
        /// <summary>
        /// Put request where the return type is the same as the parameter type
        /// </summary>
        /// <typeparam name="T">Return & parameter type</typeparam>
        /// <param name="aPath"></param>
        /// <param name="aModel"></param>
        /// <returns></returns>
        public static async Task<T> HttpPutRequest<T>(string aPath, T aModel, HttpContext anHttpContext)
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
        /// <summary>
        /// Delete request where there is no defined type.  The information should be in the aPath parameter, such as an Id.
        /// </summary>
        /// <param name="aPath"></param>
        /// <returns></returns>
        public static async Task<string> HttpDeleteRequest(string aPath, HttpContext anHttpContext)
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
