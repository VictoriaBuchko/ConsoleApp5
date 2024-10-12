using System.Text.Json;

namespace ConsoleApp5
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("\nTask1");

            Album album = new Album();
            album.InputAlbumInfo();
            album.DisplayAlbumInfo();

            string filePath = "album.xml";
            album.SerializeAlbum(filePath);

            album.UpdateAlbumInfo();
            Console.WriteLine("\n");

            album.DisplayAlbumInfo();

            Album deserializedAlbum = Album.DeserializeAlbum(filePath);
            if (deserializedAlbum != null)
            {
                Console.WriteLine("\nДесеріалізований альбом:");
                deserializedAlbum.DisplayAlbumInfo();
            }
            else
            {
                Console.WriteLine("Не вдалося десеріалізувати альбом");
            }




            Console.WriteLine("\nTask2");
            var journal = new Journal
            {
                Name = "Scientific ",
                Publisher = "Bob",
                PublishDate = DateTime.Parse("2024-10-11"),
                PageCount = 120,
            };

            journal.AddArticle(new Article("Summer", 3500, "123456789"));
            journal.AddArticle(new Article("Flover", 4200, "987654321"));
            journal.AddArticle(new Article("Music", 3000, "124425664637"));


            Console.WriteLine(journal.ToString());

            var options = new JsonSerializerOptions { WriteIndented = true };
            using (var streamWriter = new StreamWriter("journal.json"))
            {
                string jsonString = JsonSerializer.Serialize(journal, options);
                streamWriter.Write(jsonString);
                Console.WriteLine("\nДані збережені");
            }

            if (File.Exists("journal.json"))
            {
                using (var streamReader = new StreamReader("journal.json"))
                {
                    string inf = streamReader.ReadToEnd();
                    Journal infFile = JsonSerializer.Deserialize<Journal>(inf);

                    Console.WriteLine("\nЗавантажена інформація:");
                    Console.WriteLine(infFile?.ToString()); 
                }
            }
            else
            {
                Console.WriteLine("Файл journal.json не знайдено");
            }
        }
    }
}
