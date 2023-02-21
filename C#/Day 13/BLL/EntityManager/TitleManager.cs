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
    public class TitleManager : EntityManagerBase
    {
        static DBManger manager = new DBManger();

        public static bool DeleteTitleByID(Dictionary<string, object> dictParam)
        {
            try
            {
                return manager.ExecuteNonQuery("DeleteTitleByID", dictParam) > 0;
            }
            catch
            { return false; }
        }

        public static bool InsertTitle(Dictionary<string, object> dictParam)
        {
            try
            {
                return manager.ExecuteNonQuery("InsertTitle", dictParam) > 0;
            }
            catch { return false; }
        }

        public static bool UpdateTitleByTitleID(Dictionary<string, object> dictParam)
        {
            try
            {

                return manager.ExecuteNonQuery("UpdateTitleByTitleID", dictParam) > 0;
            }
            catch
            {
                return false;
            }
        }
        public static TitleList SelectAllTitles()
        {
            try
            {
                return DataTableToTitleList(manager.ExecuteDataTable("SelectAllTitles"));
            }
            catch
            {
                return new TitleList();
            }
        }

        internal static TitleList DataTableToTitleList(DataTable Dt)
        {
            TitleList lst= new TitleList();
            try
            {
                foreach(DataRow dr in Dt.Rows) 
                    lst.Add(DataRowToTitle(dr));
            }
            catch
            {
                return new();
            }
            return lst;
        }


        internal static Title DataRowToTitle(DataRow Dr)
        {
            Title title= new Title();
            try
            {
                title.title_id = Dr.Field<string>("title_id");
                title.title = Dr.Field<string>("title");
                title.type = Dr.Field<string>("type");
                title.pub_id = Dr.Field<string>("pub_id");
                title.price = Dr.Field<decimal?>("price");
                title.advance = Dr.Field<decimal?>("advance");
                title.royalty = Dr.Field<int?>("royalty");
                title.ytd_sales = Dr.Field<int?>("ytd_sales");
                title.notes = Dr.Field<string>("notes");
                title.pubdate = Dr.Field<DateTime?>("pubdate");
            }
            catch
            {
                return new();
            }
            return title;
        }
    }
}
