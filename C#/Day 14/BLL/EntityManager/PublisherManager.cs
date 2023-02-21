using DB.DBContext;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EntityManager
{
    public class PublisherManager 
    {
        public static BindingList<Publisher> Load()
        {
            try
            {
                ContextManager.Context.Publishers.Load();
                return ContextManager.Context.Publishers.Local.ToBindingList();
            }
            catch
            {
                return new();
            }
        }
    }
}
