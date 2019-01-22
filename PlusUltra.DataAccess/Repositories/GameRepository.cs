using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlusUltraDB.Entities;

namespace PlusUltra.DataAccess.Repositories
{
    public class GameRepository : BaseRepository<Game>
    {

        public GameRepository(PlusUltraDbContext context)
        {
            this.Context = context;
        }

        public void Save(Game game)
        {
            if (game.Id == 0)
            {
                Create(game);
            }
            else
            {
                Update(game, item => item.Id == game.Id);
            }
        }
    }
}
