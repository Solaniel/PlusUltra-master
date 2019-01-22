using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlusUltraDB.Entities;

namespace PlusUltra.DataAccess.Repositories
{
    public class GenreRepository : BaseRepository<Genre>
    {
        public GenreRepository(PlusUltraDbContext context)
        {
            this.Context = context;
        }

        public void Save(Genre genre)
        {
            if (genre.Id == 0)
            {
                Create(genre);
            }
            else
            {
                Update(genre, item => item.Id == genre.Id);
            }
        }
    }
}
