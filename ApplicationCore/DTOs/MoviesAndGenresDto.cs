using ApplicationCore.Entities;

namespace ApplicationCore.DTOs;

public class MoviesAndGenresDto
{
    public IEnumerable<Movie>? Movies { get; set; }
    public IEnumerable<Genre>? Genres { get; set; }
    public int TotalPage { get; set; } = 0;

}
