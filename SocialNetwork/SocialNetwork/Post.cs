using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PostNamespace

{
    class Post
    {
        public static int ID { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int LikeCount { get; set; }
        public int ViewCount { get; set; }
        public Post(string content)
        {
            PostId = ++ID;
            Content = content;
            CreationDateTime = DateTime.Now;
        }
        public void Show()
        {
            Console.WriteLine($"Post id: {PostId}");
            Console.WriteLine($"Post content: {Content}");
            Console.WriteLine($"{ViewCount} views \u2219 liked by {LikeCount}");
            Console.WriteLine($"Post creation datetime: {CreationDateTime}");
            Console.WriteLine();
        }




    }
}
