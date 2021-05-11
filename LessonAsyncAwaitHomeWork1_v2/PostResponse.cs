using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonAsyncAwaitHomeWork1_v2
{
    public class PostResponse
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public static string[] GetStringPost(PostResponse item)
        {
            var userId = item.UserId.ToString();
            var id = item.Id.ToString();
            var title = item.Title.ToString();
            var body = item.Body.ToString();
            var fullString = new string[] { userId, id, title, body };
            return fullString;
        }
    }
}
