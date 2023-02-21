using BLL.Entity;
using BLL.EntityList;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EntityManager
{
    public class PublisherManager : EntityManagerBase
    {
        static DBManger manager = new();

        public static PublisherList SelectAllPublishers()
        {
            try
            {
                return DataTableToList(manager.ExecuteDataTable("SelectAllPublishers"));
            }
            catch
            {
                return new();
            }
        }

        internal static PublisherList DataTableToList(DataTable Dt)
        {
            PublisherList list = new PublisherList();

            try
            {
                foreach (DataRow dr in Dt.Rows)
                {
                    list.Add(DataRowToEntity(dr));
                }
            }
            catch
            {
                return list;
            }

            return list;
        }

        internal static Publisher DataRowToEntity(DataRow Dr)
        {
            Publisher item = new Publisher();

            try
            {
                item.pub_id = Dr.Field<string>("pub_id");
                item.pub_name = Dr.Field<string>("pub_name");
                item.city = Dr.Field<string>("city");
                item.state = Dr.Field<string>("state");
                item.country = Dr.Field<string>("country");
            }
            catch
            {
                return new();
            }

            return item;
        }
    }
}
