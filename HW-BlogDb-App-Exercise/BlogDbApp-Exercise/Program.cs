using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDbApp_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //ListAllPosts();
            //ListAllUsers();
            //ListTitleAndBody();
            //OrderData();
            //OrderByTwoColums();
            //SelectAuthor();
            //JoinAuthorWithTitle();
            //SelectAuthorWithSpecificName();
            //OrderPostAuthors();
            //CreateData();
            //UpdateData();
            //DeleteComment();
            //DeletePost();

        }

        private static void DeleteComment()
        {
            var blogDbContext = new BlogDbContext();
            var commentInfo = blogDbContext.Comments.Single(comment => comment.Id == 31);
            blogDbContext.Comments.Remove(commentInfo);
            blogDbContext.SaveChanges();
            Console.WriteLine($"Comment {commentInfo.Id} successfully removed.");
        }

        private static void DeletePost()
        {
            var blogDbContext = new BlogDbContext();
            var postInfo = blogDbContext.Posts.Single(post => post.Id == 31);
            blogDbContext.Comments.RemoveRange(postInfo.Comments);
            postInfo.Tags.Clear();
            blogDbContext.Posts.Remove(postInfo);
            blogDbContext.SaveChanges();
            Console.WriteLine($"Post {postInfo.Id} successfully removed.");
        }

        private static void UpdateData()
        {
            var blogDbContext = new BlogDbContext();
            var userInfo = blogDbContext.Users.Single(user => user.UserName == "GBotev");
            string oldname = userInfo.FullName;
            userInfo.FullName = "Georgi Botev";
            blogDbContext.SaveChanges();
            Console.WriteLine($"User '{oldname}' has been renamed to '{userInfo.FullName}'");
        }

        private static void CreateData()
        {
            var blogDbContext = new BlogDbContext();
            var post = new Posts()
            {
                AuthorId = 2,
                Title = "Random title",
                Body = "Random body",
                Date = DateTime.Now
            };
            blogDbContext.Posts.Add(post);
            blogDbContext.SaveChanges();
            Console.WriteLine($"Post {post.Id} successfully created.");
        }

        private static void OrderPostAuthors()
        {
            var blogDbContext = new BlogDbContext();
            List<Users> users = blogDbContext.Users.Select(user => user)
                .Where(user => user.Posts.Count > 0)
                .OrderByDescending(user => user.Id)
                .ToList();
            foreach (var user in users)
            {
                Console.WriteLine($"Username: {user.UserName}");
                Console.WriteLine($"FullName: {user.FullName}");
                Console.WriteLine($"Id: {user.Id}");
                Console.WriteLine($"Posts count: {user.Posts.Count()}");
                Console.WriteLine();
            }
        }

        private static void SelectAuthorWithSpecificName()
        {
            var blogDbContext = new BlogDbContext();
            var users = blogDbContext.Users.SelectMany(user => user.Posts, (user, post) => new { user.UserName, user.FullName, post.Id })
                .Single(post => post.Id == 4);
            Console.WriteLine($"Username: {users.UserName}");
            Console.WriteLine($"FullName: {users.FullName}");
            Console.WriteLine();
        }

        private static void JoinAuthorWithTitle()
        {
            var blogDbContext = new BlogDbContext();
            var users = blogDbContext.Users.SelectMany(user => user.Posts, (user, post) => new { user.UserName, post.Title });
            foreach (var user in users)
            {
                Console.WriteLine($"Username: {user.UserName}");
                Console.WriteLine($"Title: {user.Title}");
                Console.WriteLine();
            }
        }

        private static void SelectAuthor()
        {
            var blogDbContext = new BlogDbContext();
            List<Users> users = blogDbContext.Users.Select(user => user)
                .Where(user => user.Posts.Count > 0)
                .ToList();
            foreach (var user in users)
            {
                Console.WriteLine($"Username: {user.UserName}");
                Console.WriteLine($"FullName: {user.FullName}");
                Console.WriteLine($"Posts count: {user.Posts.Count()}");
                Console.WriteLine();
            }
        }

        private static void OrderByTwoColums()
        {
            var blogDbContext = new BlogDbContext();
            var users = blogDbContext.Users.Select(user =>
            new { user.UserName, user.FullName }
            ).OrderByDescending(user => user.UserName)
            .ThenByDescending(user => user.FullName)
            .ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"Username: {user.UserName}");
                Console.WriteLine($"FullName: {user.FullName}");
                Console.WriteLine();
            }
        }

        private static void OrderData()
        {
            var blogDbContext = new BlogDbContext();
            var users = blogDbContext.Users.Select(user =>
            new { user.UserName, user.FullName }
            ).OrderBy (user => user.UserName)
            .ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"Username: {user.UserName}");
                Console.WriteLine($"FullName: {user.FullName}");
                Console.WriteLine();
            }
        }

        private static void ListTitleAndBody()
        {
            var blogDbContext = new BlogDbContext();
            var posts = blogDbContext.Posts.Select(post =>
            new { post.Title, post.Body }
            ).ToList();

            foreach (var post in posts)
            {
                Console.WriteLine($"Title: {post.Title}");
                Console.WriteLine($"Body: {post.Body}");
                Console.WriteLine();
            }
        }

        private static void ListAllUsers()
        {
            var blogDbContext = new BlogDbContext();
            List<Users> users = blogDbContext.Users.Select(user => user).ToList();
            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}");
                Console.WriteLine($"Name: {user.FullName}");
                Console.WriteLine($"Comments count: {user.Comments.Count()}");
                Console.WriteLine($"Tags count: {user.Posts.Count()}");
                Console.WriteLine();
            }
        }

        private static void ListAllPosts()
        {
            var blogDbContext = new BlogDbContext();
            List<Posts> posts = blogDbContext.Posts.Select(post => post).ToList();
            foreach (var post in posts)
            {
                Console.WriteLine($"Title: {post.Title}");
                Console.WriteLine($"AuthorId: {post.AuthorId}");
                Console.WriteLine($"Comments Count: {post.Comments.Count()}");
                Console.WriteLine($"Tags Count: {post.Tags.Count()}");
                Console.WriteLine();
            }
        }
    }

}