using BLL.Entity;
using BLL.EntityList;
using BLL.EntityManager;
using System.Data;
using System.Diagnostics;

namespace GridView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TitleList titleList;
        PublisherList publishersList;
        DataGridViewComboBoxColumn pubCol;
        private void Form1_Load(object sender, EventArgs e)
        {
            titleList = TitleManager.SelectAllTitles();
            publishersList = PublisherManager.SelectAllPublishers();
            
            pubCol = new();
            pubCol.DataSource = publishersList;
            pubCol.DisplayMember = "pub_name";
            pubCol.ValueMember = "pub_id";
            pubCol.DataPropertyName = "pub_id";
            pubCol.HeaderText = "Publisher";
            pubCol.Name = "Publisher";

            updateGridView();
        }

        Dictionary<string, object> CreateDictionaryFromRow(DataGridViewRow row)
        {
            var dictParam = new Dictionary<string, object>();

            foreach (DataGridViewCell cell in row.Cells)
            {
                var columnName = cell.OwningColumn.Name;
                if (columnName != "State" && columnName != "Publisher")
                {
                    dictParam.Add(columnName, cell.Value);
                }
            }

            return dictParam;
        }

        int Update(int index)
        {
            var dictParam = CreateDictionaryFromRow(grdTitleLst.Rows[index]);

            if (TitleManager.UpdateTitleByTitleID(dictParam))
            {
                titleList[index].State = BLL.Entity.EntityState.UnChanged;
                return 1;
            }

            return 0;
        }

        bool Delete(int index)
        {
            var dictParam = new Dictionary<string, object> { [grdTitleLst.Rows[index].Cells["title_id"].OwningColumn.Name] = grdTitleLst.Rows[index].Cells["title_id"].Value };

            if (TitleManager.DeleteTitleByID(dictParam))
            {
                titleList.RemoveAt(index);
                return true;
            } 
            else
            {
                titleList[index].State = BLL.Entity.EntityState.UnChanged;
                return false;
            }
        }

        bool Add(int index)
        {
            var dictParam = CreateDictionaryFromRow(grdTitleLst.Rows[index]);

            if (TitleManager.InsertTitle(dictParam))
            {
                titleList[index].State = BLL.Entity.EntityState.UnChanged;
                return true;
            } else
            {
                titleList.RemoveAt(index);
                return false;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = 0;

            for (int i = 0; i < titleList.Count; i++)
            {
                switch (titleList[i].State)
                {
                    case EntityState.Deleted:
                        if (Delete(i))
                        {
                            count++;
                            i--;
                        }
                        break;
                    case EntityState.Added:
                        if (Add(i))
                            count++;
                        else
                            i--;
                        break;
                    case EntityState.Changed:
                        count += Update(i);
                        break;
                    case EntityState.UnChanged:
                        break;
                }
            }

            updateGridView();
            MessageBox.Show($"Rows Updated: {count}");
        }

        private void grdTitleLst_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (titleList[e.RowIndex].State != BLL.Entity.EntityState.Added)
                titleList[e.RowIndex].State = BLL.Entity.EntityState.Changed;


            updateGridView();
        }

        private void newRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            titleList.Add(new() { State = BLL.Entity.EntityState.Added});

            updateGridView();
        }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdTitleLst.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in grdTitleLst.SelectedRows)
                {
                    if (titleList[row.Index].State == EntityState.Added)
                        titleList.RemoveAt(row.Index);
                    else if (titleList[row.Index].State == EntityState.Deleted)
                        titleList[row.Index].State = BLL.Entity.EntityState.UnChanged;
                    else
                        titleList[row.Index].State = BLL.Entity.EntityState.Deleted;
                }
            }

            updateGridView();
        }

        private void grdTitleLst_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var row = grdTitleLst.Rows[e.RowIndex];
                var cell = row.Cells[e.ColumnIndex];

                if (cell.OwningColumn.Name == "State")
                    row.DefaultCellStyle.BackColor = cell.Value.ToString() switch
                    {
                        "Deleted" => Color.Red,
                        "Changed" => Color.Yellow,
                        "Added" => Color.Green,
                        _ => Color.White,
                    };
            }
        }

        private void updateGridView()
        {
            grdTitleLst.DataSource = null;
            grdTitleLst.DataSource = titleList;
            grdTitleLst.Columns["title_id"].ReadOnly = true;
            grdTitleLst.Columns.Add(pubCol);
        }

        private void grdTitleLst_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}