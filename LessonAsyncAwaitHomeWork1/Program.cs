using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;

namespace LessonAsyncAwaitHomeWork1
{
    class Program
    {
        /// <summary>
        /// The first version is very wooden, so fast programming, about 15 min work
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var file = "response.txt";
            File.Delete(file);
            var fileList = new List<string>();
            var list = new List<PostDto>();
            var httpClient = new HttpClient();

            string urlAddress = "https://jsonplaceholder.typicode.com/posts";

            for (int i = 4; i < 14; i++)
            {
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{urlAddress}/{i}");
                try
                {
                    HttpResponseMessage httpResponse = httpClient.SendAsync(httpRequest).Result;
                    using var responseStream = httpResponse.Content.ReadAsStreamAsync().Result;
                    var json = JsonSerializer.DeserializeAsync<PostDto>(responseStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }).Result;
                    list.Add(json);
                }
                catch (HttpRequestException)
                {
                    Console.WriteLine("Что-то не так с запросом");
                }
            }
            foreach(var dtoWrite in list)
            {
                fileList.Add(dtoWrite.userId.ToString());
                fileList.Add(dtoWrite.id.ToString());
                fileList.Add(dtoWrite.title);
                fileList.Add(dtoWrite.body);
                File.AppendAllLines(file, fileList);                
                fileList.Clear();
                File.AppendAllText(file, "\n");
            }
            

        }
    }
}
