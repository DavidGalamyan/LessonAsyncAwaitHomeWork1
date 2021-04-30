using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonAsyncAwaitHomeWork1_v2
{
    public class PostResponse
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

        public static string[] GetStringPost(PostResponse item)
        {
            var userId = item.userId.ToString();
            var id = item.id.ToString();
            var title = item.title.ToString();
            var body = item.body.ToString();
            var fullString = new string[] { userId, id, title, body };
            return fullString;
        }
    }
}
