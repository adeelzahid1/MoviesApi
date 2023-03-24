using MoviesApi.DTOs;
using System.Linq;

namespace MoviesApi.Helpers
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDTO paginationDTO)
        {
            return queryable
                .Skip((paginationDTO.Page -1) * paginationDTO.RecordPerPage )
                .Take(paginationDTO.RecordPerPage);
        }
    }
}
