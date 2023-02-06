using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

//Post => id,Content,CreationDateTime,LikeCount,ViewCount

namespace Post
{
    internal class Postc
    {
        
        public int id { get; set; }
        public string Content { get; set; }
        public int likeCount { get; set; } = default;
        public int viewCount { get; set; } = default;
        DateTime CreationDateTime;

        public static int Id;

        static Postc()
        {
            Id = 0;
        }
        public Postc(string content, DateTime creationDateTime)
        {
            likeCount = default;
            viewCount = default;
            id = ++Id;
            Content = content;
            this.CreationDateTime = creationDateTime;
        }

        public void ShowPosts()
        {
            Console.WriteLine($"{id} Post ");
            Console.WriteLine(Content);
            Console.WriteLine($"Likes : {likeCount} ");
            Console.WriteLine($"Views : {viewCount} ");
            Console.WriteLine($"Date : {CreationDateTime}");
        }
    }
}
