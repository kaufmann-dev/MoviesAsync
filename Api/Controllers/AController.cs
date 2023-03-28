using Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public abstract class AController<TEntity> : ControllerBase where TEntity: class {

    private readonly IRepository<TEntity> _repository;

    private readonly ILogger<AController<TEntity>> _logger;

    protected AController(IRepository<TEntity> repository, ILogger<AController<TEntity>> logger) {
        _repository = repository;
        _logger = logger;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TEntity?>> ReadAsync(int id) => Ok(await _repository.ReadAsync(id));

    [HttpGet("control")]
    public async Task<ActionResult<List<TEntity>>> ReadAsync(int start, int count) => Ok(await _repository.ReadAsync(start, count));

    [HttpGet]
    public async Task<ActionResult<List<TEntity>>> ReadAllAsync() => Ok(await _repository.ReadAllAsync());

    [HttpPost]
    public async Task<ActionResult<TEntity>> CreateAsync(TEntity t) {
        var item = await _repository.CreateAsync(t);
        _logger.LogInformation($"created resource");

        return Ok(item);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateAsync(int id, TEntity t) {
        var item = await _repository.ReadAsync(id);

        if (item is null) return NotFound();
        await _repository.UpdateAsync(t);
        _logger.LogInformation($"updated resource: {id}");
        
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync(int id) {
        var item = await _repository.ReadAsync(id);

        if (item is null) return NotFound();
        await _repository.DeleteAsync(item);
        _logger.LogInformation($"deleted resource: {id}");
        
        return NoContent();
    }
}