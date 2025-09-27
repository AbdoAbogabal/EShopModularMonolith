namespace Shared.Pagination;

public class PaginatedResult<TEntity>
    (int pageNumber, int pageSize, long count, IEnumerable<TEntity> data)
    where TEntity : class
{

    public long Count { get; } = count;
    public int PageSize { get; } = pageSize;
    public int PageNumber { get; } = pageNumber;
    public IEnumerable<TEntity> Data { get; } = data;

}