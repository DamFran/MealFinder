using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealFinder.Database
{
    public static class DbConfig
    {
        // GANTI sesuai database kamu
        public static string ConnectionString =
            "Data Source=localhost;" +
            "Initial Catalog=MealFinderDB;" +
            "Integrated Security=True";

        internal static SqlConnection GetConnection()
        {
            throw new NotImplementedException();
        }
    }
}
