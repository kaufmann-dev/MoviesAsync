using Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;

namespace Api.Controllers;

[ApiController]
[Route("/movies")]
public class MovieController : AController<Movie> {
    
    public MovieController(IRepository<Movie> repository, ILogger<MovieController> logger) : base(repository, logger) {
    }
}