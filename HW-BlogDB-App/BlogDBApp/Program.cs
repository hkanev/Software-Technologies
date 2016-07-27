using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDBApp
{
    class Program
    {
        static void Main()
        {
            //TestGeneratedDbContent();
            //QueryData();
            //CreateNewData();
            //CascadingInsert();
            //UpdateExsistingData();
            //DeletingExistingData();
            //ExecuteNativeSQL();

        }

        private static void ExecuteNativeSQL()
        {
            var db = new BlogDbContext();
            var startDate = new DateTime(2016, 05, 19);
            var endDate = new DateTime(2016, 06, 14);
            var posts = db.Database.SqlQuery<PostData>(
              @"SELECT ID, Title, Date FROM Posts
                WHERE CONVERT(date, Date)
                BETWEEN {0} AND {1}
                ORDER BY Date", startDate, endDate);
            foreach (var p in posts)
                Console.WriteLine($"#{p.ID}: {p.Title} ({p.Date})");
        }

        private static void DeletingExistingData()
        {
            var db = new BlogDbContext();
            var lastPost = db.Posts
              .OrderByDescending(p => p.Id)
              .First();
            db.Comments.RemoveRange(
              lastPost.Comments);
            lastPost.Tags.Clear();
            db.Posts.Remove(lastPost);
            db.SaveChanges();
            Console.WriteLine(
              $"Deleted post #{lastPost.Id}");
        }

        private static void UpdateExsistingData()
        {
            var db = new BlogDbContext();
            var user = db.Users
                .Where(u => u.UserName == "mariika")
                .First();
            user.PasswordHash =
              Guid.NewGuid().ToByteArray();
            db.SaveChanges();
            Console.WriteLine(
                "User #{0} ({1}) has a new random password.",
                user.Id, user.UserName);
        }

        private static void CascadingInsert()
        {
            var db = new BlogDbContext();
            var post = new Posts()
            {
                Title = "New Post Title",
                Date = DateTime.Now,
                Body = "This post have comments and tags",
                Users = db.Users.First(),
                Comments = new Comments[] {
                new Comments() { Text = "Comment 1", Date = DateTime.Now },
                new Comments() { Text = "Comment 2", Date = DateTime.Now,
                   Users = db.Users.First() } },
                Tags = db.Tags.Take(3).ToList()
            };
                db.Posts.Add(post);
                db.SaveChanges();
        }

        private static void CreateNewData()
        {
            var db = new BlogDbContext();
            var post = new Posts()
            {
                Title = "New Title",
                Body = "New Post Body",
                Date = DateTime.Now
            };
            db.Posts.Add(post);
            db.SaveChanges();
            Console.WriteLine("Post #{0} created.", post.Id);
        }

        private static void QueryData()
        {
            var db = new BlogDbContext();
            var posts = db.Posts.Select(p => new
            {
                p.Id,
                p.Title,
                Comments = p.Comments.Count(),
                Tags = p.Tags.Count()
            });
            Console.WriteLine("SQL query:\n{0}\n", posts);
            foreach (var p in posts)
                Console.WriteLine($"{p.Id} {p.Title} ({p.Comments} comments, {p.Tags} tags)");
        }

        private static void TestGeneratedDbContent()
        {
            var db = new BlogDbContext();
            foreach (var user in db.Users)
                Console.WriteLine(user.UserName);
        }
    }
}

