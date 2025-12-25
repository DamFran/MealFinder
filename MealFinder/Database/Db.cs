using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace MealFinder.Database
{
    public class Db
    {
        public static SqlConnection Conn()
        {
            return new SqlConnection(DbConfig.ConnectionString);
        }
    }
}
