using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Genre FavoriteMusicType { get; set; }
        public List<Song> FavoriteSongs { get; set; }
        


        public Person(int id, string firstName, string lastName, int age, Genre genre, List<Song> favSongs)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            FavoriteMusicType = genre;
            FavoriteSongs = favSongs;
        }

        public string ReturnInfo()
        {
            return $"{Id} Full Name: {FirstName} {LastName} Age: {Age} Favorite Music Genre: {FavoriteMusicType}";
        }
        public bool GetFavSongs(List <Song> songs)
        {
            if (songs.Count == 0)
            {
                return false;
            } else
            {
                songs.ForEach(song => Console.WriteLine($"Title: {song.Title} Genre: {song.Genre}"));
                return true;
            }
        }
    }
}
