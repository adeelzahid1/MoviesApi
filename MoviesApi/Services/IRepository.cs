using MoviesApi.Entities;
using System.Collections.Generic;

namespace MoviesApi.Services
{
    public interface IRepository
    {
        Genre getGenre(int id);
        List<Genre> getGenres();


    }
}
