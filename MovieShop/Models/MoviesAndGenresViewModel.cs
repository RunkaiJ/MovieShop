using ApplicationCore.Entities;

namespace MVC.Models
{
    public class MoviesAndGenresViewModel
    {
        public IEnumerable<Movie>? Movies { get; set; }
        public IEnumerable<Genre>? Genres { get; set; }
        public int SelectedGenreId { get; set; } = -1;
        public int TotalPage { get; set; } = 0;
        public int CurrentPage { get; set; } = 1;
    }
}
