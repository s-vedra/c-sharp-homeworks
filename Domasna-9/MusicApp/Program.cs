using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicApp
{
    internal class Program
    {
        //method for parsing the input
        public static int Parsing(string input)
        {
            if (!int.TryParse(input, out int inputUser))
            {
                return 0;
            }
            return inputUser;
        }
        //method to return the genre the user listents to the most
        public static Genre ReturnGenre()
        {
            string answer = Console.ReadLine().ToLower();
            switch (answer)
            {
                case "hip hop":
                    return Genre.HipHop;
                case "rock":
                    return Genre.Rock;
                case "techno":
                    return Genre.Techno;
                case "classical":
                    return Genre.Classical;
                default:
                    return 0;
            }
        }

        //method to return the song the user entered
        public static Song ReturnSong()
        {
            Console.WriteLine("Enter song title");
            string title = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("Enter duration of the song");
                string durationInput = Console.ReadLine();
                int duration = Parsing(durationInput);
                if (duration != 0)
                {
                    while (true)
                    {
                        Console.WriteLine("Enter genre of the song");
                        Genre genre = ReturnGenre();
                        if (genre != 0)
                        {
                            return new Song(title, duration, genre);
                        }
                        else
                        {
                            continue;
                        }
                    }

                }
                else
                {
                    continue;
                }

            }


        }
        //method to return the user
        public static Person ReturnUser(int id)
        {
            Console.Clear();
            Console.WriteLine("Enter your First Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your Last Name");
            string lastName = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("What's your favorite music genre?");
                Genre genre = ReturnGenre();
                if (genre != 0)
                {
                    while (true)
                    {
                        Console.WriteLine("Enter your Age");
                        string ageInput = Console.ReadLine();
                        int age = Parsing(ageInput);
                        if (age != 0)
                        {
                            while (true)
                            {
                                Console.WriteLine("Do you have any favorite songs?");
                                string answer = Console.ReadLine().ToLower();
                                //if the answer is yes, make a list with 3 of his favorite songs
                                if (answer == "yes")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter your 3 favorite songs");
                                    List<Song> favSongs = new List<Song>();
                                    for (int i = 0; i < 3; i++)
                                    {
                                        favSongs.Add(ReturnSong());

                                    }
                                    return new Person(id, name, lastName, age, genre, favSongs);
                                }
                                //if the answer is no, make an empty list 
                                else if (answer == "no")
                                {
                                    List<Song> favSongs = new List<Song>();
                                    return new Person(id, name, lastName, age, genre, favSongs);
                                }
                                else
                                {
                                    continue;
                                }
                            } 
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
        }
        static void Main(string[] args)
        {
      
            List<Person> users = new List<Person>() 
            { 
                new Person(1, "Jerry", "Jerryson", 25, Genre.Rock, new List<Song>() { new Song("Runaway", 4, Genre.Rock), new Song("Always", 5, Genre.Rock), new Song("Zitti e buoni", 3, Genre.Rock), new Song("Traitor", 5, Genre.Rock) }),
                new Person(2, "Maria", "Jesus", 150, Genre.Classical, new List<Song>() { new Song("Forever", 3, Genre.Classical), new Song("I Need You", 4, Genre.Classical),new Song("Tchaikovsky", 5, Genre.Classical) }),
                new Person(3, "Jane", "Janeson", 15, Genre.HipHop, new List<Song>() { new Song("Lose Yourself", 4, Genre.HipHop), new Song("Not Afraid", 4, Genre.HipHop), new Song("Venom", 5, Genre.HipHop) }),
                new Person(4, "Stefan", "Stefski", 22, Genre.Techno, new List<Song>() { new Song("Help Me", 6, Genre.Techno), new Song("Unity", 4, Genre.Techno),new Song("Echo", 5, Genre.Techno),new Song("Shivers", 6, Genre.Techno) })
            };
            List<Song> songs = new List<Song>() {new Song("Californication",6,Genre.Rock),new Song("In da Club", 2, Genre.HipHop), new Song("Back in Black", 6, Genre.Rock), new Song("Baby", 2, Genre.HipHop) }
           ;

            //repeat the return user method 2 times, so the list of users will contain 2 users
            for (int i = 0; i < 2; i++)
            {
                users.Add(ReturnUser(i + 5));
            }
            Console.Clear();
            //excersise 3
            Person jerry = users.Single(user => user.FirstName.Equals("Jerry"));
            jerry.FavoriteSongs.AddRange(songs.Where(song => song.Title.StartsWith('B')).ToList());
            Person maria = users.Single(user => user.FirstName.Equals("Maria"));
            maria.FavoriteSongs.AddRange(songs.Where(song => song.Length > 6));
            Person stefan = users.Single(user => user.FirstName.Equals("Stefan"));
            stefan.FavoriteSongs.AddRange(songs.Where(song => song.Length < 3));
            List<Person> usersWithMoreSongs = users.Where(user => user.FavoriteSongs.Count > 3).ToList();
            usersWithMoreSongs.ForEach(user => Console.WriteLine($"User with more than 3 songs {user.ReturnInfo()}"));
            
            foreach (Person person in users)
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine(person.ReturnInfo());
                Console.WriteLine("Favorite songs:");

                if (!person.GetFavSongs(person.FavoriteSongs))
                    {
                        Console.WriteLine("This user doesn't have any favorite songs");
                    }
                
            }
            

        }
    }
}
