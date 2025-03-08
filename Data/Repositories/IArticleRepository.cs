using System.Collections.Generic;
using System.Threading.Tasks;

public interface IArticleRepository
{
    Task<IEnumerable<Article>> GetAllArticlesAsync();
    Task<Article> GetArticleByIdAsync(int id);
    Task<Article> AddArticleAsync(Article article);
    Task<bool> UpdateArticleAsync(Article article);
    Task<bool> DeleteArticleAsync(int id);
    Task<bool> ArticleExistsAsync(int id);
    Task<DateTime> GetArticleTimestampAsync(int id);
}