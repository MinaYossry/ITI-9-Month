using DB.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EntityManager
{
    public class ContextManager
    {
        public static pubsContext Context { get; set; } = new pubsContext();

        public static int Save()
        {
            try
            {
                return Context.SaveChanges(); 
            }
            catch (Exception)
            {
                Context = new();
                return 0;
            }
        }
    }
}
