using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MealFinder.Database;
using System.Data.SqlClient;

namespace MealFinder.Controllers
{
    public abstract class BaseController
    {
        protected SqlConnection GetConnection()
        {
            return Db.Conn();
        }
    }
}

