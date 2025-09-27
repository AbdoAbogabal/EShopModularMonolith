namespace Shared.Pagination;

public record PaginatedRequest(int PageNumber = 1, int PageSize = 10);