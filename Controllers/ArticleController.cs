using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ArticleController : ControllerBase
{
    private readonly IArticleRepository _repository;

    public ArticleController(IArticleRepository repository)
    {
        _repository = repository;
    }

    // Holt alle Artikel
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
    {
        var articles = await _repository.GetAllArticlesAsync();
        return Ok(articles);
    }

    // Holt einen spezifischen Artikel per ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Article>> GetArticle(int id)
    {
        var article = await _repository.GetArticleByIdAsync(id);
        
        if (article == null)
        {
            return NotFound();
        }

        return Ok(article);
    }

    // Fügt neuen Artikel hinzu
    [HttpPost]
    public async Task<ActionResult<Article>> PostArticle(Article article)
    {
        var createdArticle = await _repository.AddArticleAsync(article);
        return CreatedAtAction(nameof(GetArticle), new { id = createdArticle.Id }, createdArticle);
    }

    // Aktualisiert einen Artikel
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateArticle(int id, Article updatedArticle)
    {
        if (id != updatedArticle.Id)
            return BadRequest();

        if (!await _repository.ArticleExistsAsync(id))
            return NotFound();

        // Konfliktprüfung: Hat sich der Artikel seit dem letzten Abruf verändert?
        var currentTimestamp = await _repository.GetArticleTimestampAsync(id);
        if (updatedArticle.Timestamp < currentTimestamp)
        {
            return Conflict(new
            {
                Message = "Der Artikel wurde inzwischen von einem anderen Benutzer geändert.",
                CurrentTimestamp = currentTimestamp
            });
        }

        try
        {
            var success = await _repository.UpdateArticleAsync(updatedArticle);
            if (!success)
                return NotFound();
                
            return NoContent();
        }
        catch (DbUpdateConcurrencyException)
        {
            return StatusCode(500, "Fehler beim Speichern in der Datenbank.");
        }
    }

    // Löscht einen Artikel
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArticle(int id)
    {
        var success = await _repository.DeleteArticleAsync(id);
        
        if (!success)
            return NotFound();
            
        return NoContent();
    }
}