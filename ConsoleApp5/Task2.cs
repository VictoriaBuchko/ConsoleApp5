using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Article
    {
        public string? Title { get; set; }
        public int CharacterCount { get; set; }
        public string? Preview { get; set; }

        public Article()
        {
            Title = string.Empty;
            CharacterCount = 0;
            Preview = string.Empty;
        }

        public Article(string title, int characterCount, string preview)
        {
            Title = title;
            CharacterCount = characterCount;
            Preview = preview;
        }
    }


    public class Journal
    {
        public string? Name { get; set; }
        public string? Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public int PageCount { get; set; }
        public List<Article> Articles { get; set; } = new List<Article>();

        public Journal()
        {
            Name = string.Empty;
            Publisher = string.Empty;
            PublishDate = DateTime.Now;
            PageCount = 0;
            Articles = new List<Article>();
        }

        public Journal(string name, string publisher, DateTime publishDate, int pageCount, List<Article> articles)
        {
            Name = name;
            Publisher = publisher;
            PublishDate = publishDate;
            PageCount = pageCount;
            Articles = articles;
        }

        public void AddArticle(Article article)
        {
            Articles.Add(article);
        }

        public override string ToString()
        {
            var articleDetails = Articles.Select(a => $"- {a.Title} ({a.CharacterCount} символів): {a.Preview}");
            return $"Назва журналу: {Name}\nВидавництво: {Publisher}\nДата видання: {PublishDate.ToShortDateString()}\nКількість сторінок: {PageCount}\nСписок статей:\n{string.Join("\n", articleDetails)}";
        }
    }
}
