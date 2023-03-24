using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Helpers
{
    public static class HttpContextExtension
    {
        public async static Task InsertParametersPaginationInHeader<T>(this HttpContext httpContext, IQueryable<T> queryable)
        {
            if (httpContext == null) { throw new ArgumentNullException(nameof(httpContext)); }
            
            double count = await queryable.CountAsync();
            httpContext.Response.Headers.Add("totalAmountOfRecord", count.ToString());

        }
    }
}
