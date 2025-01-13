namespace MovieShop.Models
{
    public class CastDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePath { get; set; }
        public string TmdbUrl { get; set; }
        public IEnumerable<MovieViewModel> Movies { get; set; }
    }

    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
    }
}
