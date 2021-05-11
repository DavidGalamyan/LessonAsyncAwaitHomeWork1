using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace LessonAsyncAwaitHomeWork1_v2
{
    /// <summary>
    /// Эта версия заняла примерно час чистого времени, не думал что будет так интересно, слегка поломать голову над async
    /// В этой версии реализации, я уверен что все выполняется асинхронно.
    /// </summary>
    class Program
    {
        private readonly static string _urlAddress = "https://jsonplaceholder.typicode.com/posts";
        private readonly static HttpClient _httpClient = new HttpClient();
        private readonly static string _file = "deserializeJson.txt";
        static async Task Main(string[] args)
        {
            var request = _urlAddress;
            File.Delete(_file);
            var tasks = new List<Task<PostResponse>>();
            var listPostResponse = new List<PostResponse>();
            // Создаем запрос под таск и отправляем его на асинхронное выполнение, паралельно с этим записываем его в Лист<Задач>
            for (int i = 4; i <= 13; i++)
            {
                var task = GetHttpResponse(request, i);
                tasks.Add(task);
            }

            // Ждем когда все таски сделают свое дело
            await Task.WhenAll(tasks);

            // После того как удостоверились, что все таски отработали вытаскиваем из них наши Responses
            tasks.ForEach(t => listPostResponse.Add(t.Result) );

            // Записываем наши Responses в файл, не забывая интрополировать после каждой,
            // P.S. Метод GetStringPost возвращает нам массив стрингов для удобной записи в файл
            foreach(var post in listPostResponse)
            {
                File.AppendAllLines(_file, PostResponse.GetStringPost(post));
                File.AppendAllText(_file, "\n");
            }
        }
        static async Task<PostResponse> GetHttpResponse(string request, int numberPost)
        {
            var response = await _httpClient.GetAsync($"{request}/{numberPost}");
            // Идею на проверку статус кода, нагло стыбзил из урока )
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Не что-то пошло не так");
                return default;
            }
            var content = await response.Content.ReadAsStringAsync();
            var post = JsonConvert.DeserializeObject<PostResponse>(content);
            return post;
        }
    }
}
