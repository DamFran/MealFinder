using MealFinder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealFinder.Helper
{
    public static class Session
    {
        public static User CurrentUser { get; set; }
    }
    public static class Permission
    {
     public static bool IsAdmin =>
            Session.CurrentUser?.Role?
                .Trim()
                .Equals("admin", StringComparison.OrdinalIgnoreCase) == true;
    
    public static bool IsUser =>
            Session.CurrentUser?.Role?
                .Trim()
                .Equals("user", StringComparison.OrdinalIgnoreCase) == true;
    }
}