using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusUltra.DataAccess.Repositories
{
    public class UnitOfWork
    {
        private readonly PlusUltraDbContext context;

        private GameRepository gameRepository;
        private GenreRepository genreRepository;
        private OrganizationRepository organizationRepository;

        public UnitOfWork(PlusUltraDbContext connection)
        {
            context = connection;
        }

        public GameRepository GameRepository
        {
            get
            {
                if (gameRepository == null)
                {
                    gameRepository = new GameRepository(context);
                }

                return gameRepository;
            }
        }

        public GenreRepository GenreRepository
        {
            get
            {
                if(genreRepository == null)
                {
                    genreRepository = new GenreRepository(context);
                }

                return genreRepository;
            }
        }

        public OrganizationRepository OrganizationRepository
        {
            get
            {
                if(organizationRepository == null)
                {
                    organizationRepository = new OrganizationRepository(context);
                }

                return organizationRepository;
            }
        }
    }
}
