using System;

namespace Model
{
    public class Song
    {
        public string Title { get; set; }
        public int Length { get; set; }
        public Genre Genre { get; set; }

        public Song(string title, int length, Genre genre)
        {
            Title = title;
            Length = length;
            Genre = genre;
        }
        public void ReturnInfo()
        {
            Console.WriteLine($"{Title} {Length} {Genre}"); 
        }

    }
}
