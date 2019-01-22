using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlusUltraDB.Entities;
namespace PlusUltra.DataAccess.Repositories
{
    public class OrganizationRepository : BaseRepository<Organization>
    {
        public OrganizationRepository(PlusUltraDbContext context)
        {
            this.Context = context;
        }

        public void Save(Organization organization)
        {
            if (organization.Id == 0)
            {
                Create(organization);
            }
            else
            {
                Update(organization, item => item.Id == organization.Id);
            }
        }
    }
}
