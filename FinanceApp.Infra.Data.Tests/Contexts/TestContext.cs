using FinancasApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FinancasApp.Infra.Data.Test.Contexts
{
    public class TestContext
    {
        public static DataContext CreateDataContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "FinancasApp")
                .Options;
        
            return new DataContext(options);
        }
    }
}
