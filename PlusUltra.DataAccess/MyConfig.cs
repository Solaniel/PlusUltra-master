
namespace PlusUltra.DataAccess
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public class MyConfig : DbConfiguration
    {
        public MyConfig()
        {
            SetDefaultConnectionFactory(
                new LocalDbConnectionFactory("MSSQLLocalDB")
            );
        }
    }
}
