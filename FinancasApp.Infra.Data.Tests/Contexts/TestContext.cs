using FinancasApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Data.Tests.Contexts
{
    /// <summary>
    /// Classe para configurar o DataContext do Entity Framework
    /// definindo o tipo de conexão para banco de dados de memória
    /// </summary>
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
