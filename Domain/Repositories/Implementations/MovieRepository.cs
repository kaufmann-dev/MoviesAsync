using Domain.Repositories.Interfaces;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class MovieRepository : ARepository<Movie>, IMovieRepository {
        
    public MovieRepository(ImdbContext movieDbContext) : base(movieDbContext)
    {
        
    }
}