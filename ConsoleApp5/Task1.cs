using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp5
{

    public class Song
    {
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public double Duration { get; set; }

        public Song() { }

        public Song(string title, string genre, double duration)
        {
            Title = title;
            Genre = genre;
            Duration = duration;
        }
    }

    public class Album
    {
        public string? Title { get; set; }
        public string? Artist { get; set; }
        public int ReleaseYear { get; set; }
        public double TotalDuration { get; set; } 
        public string? RecordLabel { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();

        public Album() { }

        public Album(string title, string artist, int releaseYear, double totalDuration, string recordLabel)
        {
            Title = title;
            Artist = artist;
            ReleaseYear = releaseYear;
            TotalDuration = totalDuration;
            RecordLabel = recordLabel;
        }

        public void InputAlbumInfo()
        {
            Console.WriteLine("Введіть інформацію про альбом:");

            Console.Write("Назва альбому: ");
            Title = Console.ReadLine();

            Console.Write("Назва виконавця: ");
            Artist = Console.ReadLine();

            while (true)
            {
                Console.Write("Рік випуску: ");
                if (int.TryParse(Console.ReadLine(), out int releaseYear))
                {
                    ReleaseYear = releaseYear;
                    break;
                }
                else
                {
                    Console.WriteLine("Невірний формат. Введіть ціле число для року випуску");
                }
            }
            while (true)
            {
                Console.Write("Загальна тривалість (в секундах): ");
                if (double.TryParse(Console.ReadLine(), out double totalDuration))
                {
                    TotalDuration = totalDuration;
                    break;
                }
                else
                {
                    Console.WriteLine("Невірний формат. Введіть число для тривалості.");
                }
            }

            Console.Write("Студія звукозапису: ");
            RecordLabel = Console.ReadLine();

            int numberOfSongs;
            while (true)
            {
                Console.Write("Скільки пісень у альбомі? ");
                if (int.TryParse(Console.ReadLine(), out numberOfSongs) && numberOfSongs > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Невірний формат. Введіть ціле число більше нуля.");
                }
            }

            for (int i = 0; i < numberOfSongs; i++)
            {
                Console.WriteLine($"\nВведіть інформацію про пісню #{i + 1}:");

                Console.Write("Назва пісні: ");
                string songTitle = Console.ReadLine();

                Console.Write("Жанр: ");
                string genre = Console.ReadLine();


                double songDuration;
                while (true)
                {
                    Console.Write("Тривалість (в секундах): ");
                    if (double.TryParse(Console.ReadLine(), out songDuration) && songDuration > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Невірний формат. Введіть число більше нуля для тривалості.");
                    }
                }

                Songs.Add(new Song(songTitle, genre, songDuration));
            }
        }



        public void DisplayAlbumInfo()
        {
            Console.WriteLine($"Назва альбому: {Title ?? "Невідомо"}");
            Console.WriteLine($"Виконавець: {Artist ?? "Невідомо"}");
            Console.WriteLine($"Рік випуску: {ReleaseYear}");
            Console.WriteLine($"Загальна тривалість: {TotalDuration} сек");
            Console.WriteLine($"Студія звукозапису: {RecordLabel ?? "Невідомо"}");
            Console.WriteLine("Список пісень:");

            if (Songs.Count == 0)
            {
                Console.WriteLine("Пісні відсутні");
            }
            else
            {
                foreach (var song in Songs)
                {
                    Console.WriteLine($"- {song.Title ?? "Невідомо"} (жанр: {song.Genre ?? "Невідомо"}, тривалість: {song.Duration} сек)");
                }
            }
        }

        public void SerializeAlbum(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Album));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, this);
            }
            Console.WriteLine("Дані збережені");
        }

        public static Album DeserializeAlbum(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Album));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                return (Album)serializer.Deserialize(fileStream);
            }
        }

        public void UpdateAlbumInfo()
        {
            Console.WriteLine("\nКоригування інформації про альбом:");
            Console.Write("Введіть нову назву альбому: ");
            Title = Console.ReadLine();

            Console.Write("Введіть нового виконавця: ");
            Artist = Console.ReadLine();

            Console.Write("Введіть новий рік випуску: ");
            ReleaseYear = int.Parse(Console.ReadLine());

            Console.Write("Введіть нову загальну тривалість (в секундах): ");
            TotalDuration = double.Parse(Console.ReadLine());

            Console.Write("Введіть нову студію звукозапису: ");
            RecordLabel = Console.ReadLine();
        }


    }
}
