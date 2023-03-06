using MoviesApi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApi.Services
{
    public class InMemoryRepository : IRepository
    {
        private List<Genre> _genres;

        public InMemoryRepository() {
            _genres = new List<Genre>()
            {
                new Genre() {Id = 1, Name = "Comedy" },
                new Genre() {Id = 2, Name = "Action" }
            };
        }

        public List<Genre> getGenres()
        {
            return _genres;
        }

        public Genre getGenre(int id)
        {
            return _genres.FirstOrDefault(x => x.Id == id);

        }

    }
}
