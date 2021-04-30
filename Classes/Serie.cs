using System;

namespace DIO.Series
{
    public class Serie : EntityBase
    {
        // Attributes
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Excluded { get; set; }
        // Methods
        public Serie(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Excluded = false;
        }
        public override string ToString()
        {
            string text = "";
            text += "Genre: " + this.Genre + Environment.NewLine;
            text += "Title: " + this.Title + Environment.NewLine;
            text += "Description: " + this.Description + Environment.NewLine;
            text += "Release year: " + this.Year + Environment.NewLine;
            text += "Excluido: " + this.Excluded;
            return text;
        }
        public string getTitle()
        {
            return this.Title;
        }
        public int getId()
        {
            return this.Id;
        }
        public bool getExcluded()
        {
            return this.Excluded;
        }
        public void Exclude()
        {
            this.Excluded = true;
        }
    }
}