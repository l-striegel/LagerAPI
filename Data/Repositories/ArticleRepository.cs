using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ArticleRepository : IArticleRepository
{
    private readonly AppDbContext _context;

    public ArticleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Article>> GetAllArticlesAsync()
    {
        return await _context.Articles.ToListAsync();
    }

    public async Task<Article> GetArticleByIdAsync(int id)
    {
        return await _context.Articles.FindAsync(id);
    }

    public async Task<Article> AddArticleAsync(Article article)
    {
        article.Timestamp = DateTime.UtcNow;
        
        _context.Articles.Add(article);
        await _context.SaveChangesAsync();
        
        return article;
    }

    public async Task<bool> UpdateArticleAsync(Article article)
    {
        var existingArticle = await _context.Articles.FindAsync(article.Id);
        
        if (existingArticle == null)
            return false;
            
        // Timestamp-Prüfung erfolgt im Controller

        existingArticle.Name = article.Name;
        existingArticle.Type = article.Type;
        existingArticle.Stock = article.Stock;
        existingArticle.Unit = article.Unit;
        existingArticle.Price = article.Price;
        existingArticle.Location = article.Location;
        existingArticle.Status = article.Status;
        existingArticle.Link = article.Link;
        existingArticle.StylesJson = article.StylesJson;
        existingArticle.Timestamp = article.Timestamp;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteArticleAsync(int id)
    {
        var article = await _context.Articles.FindAsync(id);
        
        if (article == null)
            return false;
            
        _context.Articles.Remove(article);
        await _context.SaveChangesAsync();
        
        return true;
    }

    public async Task<bool> ArticleExistsAsync(int id)
    {
        return await _context.Articles.AnyAsync(a => a.Id == id);
    }

    public async Task<DateTime> GetArticleTimestampAsync(int id)
    {
        var article = await _context.Articles.FindAsync(id);
        return article?.Timestamp ?? DateTime.MinValue;
    }
}