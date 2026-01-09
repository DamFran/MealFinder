using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealFinder.Database
{
    namespace MealFinder.Database
    {
        public class DbConfig
        {
            // Path absolut ke folder database
            public static string DbFile = @"D:\FinalProject\MealFinder\Database\MealFinder.db";

            public static string ConnectionString =
                $"Data Source={DbFile};Version=3;";
        }
    }
}
