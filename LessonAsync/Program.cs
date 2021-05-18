using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LessonAsync
{
    class Program
    { 
        static async Task Main(string[] args)
        {
            PostService service = new PostService();
            int[] arrayNumberId = new int[] { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

            var tasks = arrayNumberId.Select(postId => service.GetPost(postId)).ToList();
            try
            {
                var posts = await Task.WhenAll(tasks);
                var postsArray = posts.Select(post => post.ToString()).ToArray();              
            }
            catch (Exception ex)
            {
                foreach (var task in tasks.Where(x => x.IsFaulted))
                {
                    Console.WriteLine($"Что-то пошло не так:{ex}");
                }                
            }
        }
    }
}
