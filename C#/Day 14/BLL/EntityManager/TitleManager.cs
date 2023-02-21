using DB.DBContext;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EntityManager
{
    public class TitleManager
    {

        public static BindingList<Title> Load()
        {
            try
            {
                ContextManager.Context.Titles.Load();
                return ContextManager.Context.Titles.Local.ToBindingList();
            }
            catch
            {
                return new();
            }
        }
    }
}
