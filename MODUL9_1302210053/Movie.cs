using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MODUL9_1302210053
{
    public class Movie
    {
        public int Id { get; set; }
         public string Title { get; set; }
         public string Director { get; set; }
        public List<string> Stars { get; set; }
        public string Description { get; set; }


         //public Movie(string Title , string Director, List<string> stars , string description ) { this.Title = Title; this.Director = Director; this.stars = stars; this.description = description;  }


        

    }
}
