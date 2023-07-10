using TicketApp.Domain.DomainModels;
using TicketApp.Repository.Interface;
using TicketApp.Service.Interface;

namespace TicketApp.Service.Implementation;

public class MovieService : IMovieService
{
    public readonly IMovieRepository<Movie> _movieRepository;

    public MovieService(IMovieRepository<Movie> movieRepository)
    {
        _movieRepository = movieRepository;
    }
    
    public void CreateNewMovie(Movie t)
    {
        this._movieRepository.Insert(t);
    }

    public void DeleteMovie(int id)
    {
        var movie = _movieRepository.Get(id);
        this._movieRepository.Delete(movie);
    }

    public List<Movie> GetAllMovies()
    {
        return _movieRepository.GetAll().ToList();
    }

    public Movie GetDetailsForMovie(int id)
    {
        return _movieRepository.Get(id);
    }

    public void UpdateExistingMovie(Movie t)
    {
        _movieRepository.Update(t);
    }
}