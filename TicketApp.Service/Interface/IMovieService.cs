using TicketApp.Domain.DomainModels;

namespace TicketApp.Service.Interface;

public interface IMovieService
{
    public void CreateNewMovie(Movie t);

    public void DeleteMovie(int id);

    public List<Movie> GetAllMovies();

    public Movie GetDetailsForMovie(int id);
    
    public void UpdateExistingMovie(Movie t);
}