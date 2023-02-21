using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GridView
{
    public partial class Form1 : Form
    {
        SqlConnection sqlCn;

        SqlDataAdapter sqlProducts;
        SqlDataAdapter sqlSuppliers;
        SqlDataAdapter sqlCategories;

        DataTable productsDT;
        DataTable suppliersDT;
        DataTable categoriesDT;

        DataGridViewComboBoxColumn suppliersList;
        DataGridViewComboBoxColumn catergoriesList;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlCn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString);

            sqlSuppliers = new SqlDataAdapter(new SqlCommand("select SupplierID, CompanyName from suppliers", sqlCn));
            sqlCategories = new SqlDataAdapter(new SqlCommand("select CategoryID, CategoryName from categories", sqlCn));
            sqlProducts = new SqlDataAdapter(new SqlCommand("Select * from products", sqlCn));

            productsDT = new DataTable();
            suppliersDT = new DataTable();
            categoriesDT = new DataTable();

            SqlCommandBuilder commandBuilder= new SqlCommandBuilder(sqlProducts);
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearData();
            FillGrid();
        }

        void FillGrid()
        {
            sqlProducts.Fill(productsDT);
            sqlSuppliers.Fill(suppliersDT);
            sqlCategories.Fill(categoriesDT);

            gridData.DataSource = productsDT;

            suppliersList = createNewDropDown(suppliersDT, "Supplier", "CompanyName", "SupplierID");
            catergoriesList = createNewDropDown(categoriesDT, "Category", "CategoryName", "CategoryID");
            suppliersList.DataPropertyName = "SupplierID";
            catergoriesList.DataPropertyName = "CategoryID";
            gridData.Columns.Add(suppliersList);
            gridData.Columns.Add(catergoriesList);

            //gridData.Columns["SupplierID"].Visible = false;
            //gridData.Columns["CategoryID"].Visible = false;

        }

        void clearData()
        {
            gridData.DataSource = null;
            gridData.Rows.Clear();
            gridData.Columns.Clear();
            productsDT.Rows.Clear();
            categoriesDT.Rows.Clear();
            suppliersDT.Rows.Clear();
        }

        private void writeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gridData.EndEdit();
                sqlProducts.Update(productsDT);
                MessageBox.Show("Success");
            }
            catch (Exception)
            {
                MessageBox.Show("Failed");
                clearData();
                FillGrid();
            }
            
        }



        DataGridViewComboBoxColumn createNewDropDown<T>(T _dataSource, string _headerText, string _displayMember, string _valueMember)
        {
            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();

            comboBoxColumn.DataSource = _dataSource;
            comboBoxColumn.HeaderText = _headerText;
            comboBoxColumn.DisplayMember = _displayMember;
            comboBoxColumn.ValueMember = _valueMember;

            return comboBoxColumn;
        }


    }
}