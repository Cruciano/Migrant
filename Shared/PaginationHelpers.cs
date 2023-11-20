namespace Shared;

public static class PaginationHelpers
{
    public static IQueryable<T> Page<T>(this IQueryable<T> query, int pageNumber, int pageSize) =>
        query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

    public static int TotalPages(this int count, int pageSize) => (count + pageSize - 1) / pageSize;
}