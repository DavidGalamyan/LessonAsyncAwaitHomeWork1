using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LessonAsync
{
    class PostService
    {
        private readonly string _url = "https://jsonplaceholder.typicode.com/posts/";
        private static HttpClient _client = new HttpClient();
        /// <summary>
        /// Enter PostID to get data
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public async Task<PostResponse> GetPost(int postId)
        {
            var response = await _client.GetAsync($"{_url}/{postId}");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Что-то пошло не так");
                return default;
            }
            var content = await response.Content.ReadAsStringAsync();
            var post = JsonConvert.DeserializeObject<PostResponse>(content);
            return post;
        }
    }
}
