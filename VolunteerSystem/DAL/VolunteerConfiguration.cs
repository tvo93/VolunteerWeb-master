using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace VolunteerSystem.DAL
{
    
        public class VolunteerConfiguration: DbConfiguration
    {
            public VolunteerConfiguration()
            {
                SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
          
        }
        }
    
}