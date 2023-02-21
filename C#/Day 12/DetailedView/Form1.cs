using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DetailedView
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

        SqlCommand sqlUpdateCommand;

        BindingSource productsBS;
        BindingNavigator bindingNavigator;
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

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(sqlProducts);
            LoadData();
        }

        void ClearData()
        {
            productsDT.Clear();
            categoriesDT.Clear();
            suppliersDT.Clear();
            prdID.DataBindings.Clear();
            prdName.DataBindings.Clear();
            prdSupplier.DataBindings.Clear();
            prdSupplier.DataSource = null;
            prdCategory.DataBindings.Clear();
            prdCategory.DataSource = null;
            prdUnitPrice.DataBindings.Clear();
            prdUnitsInStock.DataBindings.Clear();
            prdQunatityPerUnit.DataBindings.Clear();
            prdUnitsOnOrder.DataBindings.Clear();
            prdReorderLevel.DataBindings.Clear();
            prdDiscontinued.DataBindings.Clear();
            this.Controls.Remove(bindingNavigator);
        }

        void LoadData()
        {
            sqlProducts.Fill(productsDT);
            sqlSuppliers.Fill(suppliersDT);
            sqlCategories.Fill(categoriesDT);

            productsBS = new BindingSource(productsDT, "");

            prdID.DataBindings.Add("Text", productsBS, "ProductID");
            prdName.DataBindings.Add("Text", productsBS, "ProductName");

            prdSupplier.DataSource = suppliersDT;
            prdSupplier.DisplayMember = "CompanyName";
            prdSupplier.ValueMember = "SupplierID";
            prdSupplier.DataBindings.Add("SelectedValue", productsBS, "SupplierID");

            prdCategory.DataSource = categoriesDT;
            prdCategory.DisplayMember = "CategoryName";
            prdCategory.ValueMember = "CategoryID";
            prdCategory.DataBindings.Add("SelectedValue", productsBS, "CategoryID");

            prdQunatityPerUnit.DataBindings.Add("Text", productsBS, "QuantityPerUnit");
            prdUnitPrice.DataBindings.Add("Value", productsBS, "UnitPrice");
            prdUnitsInStock.DataBindings.Add("Value", productsBS, "UnitsInStock");
            prdUnitsOnOrder.DataBindings.Add("Value", productsBS, "UnitsOnOrder");
            prdReorderLevel.DataBindings.Add("Value", productsBS, "ReorderLevel");
            prdDiscontinued.DataBindings.Add("Checked", productsBS, "Discontinued");

            bindingNavigator = new BindingNavigator(productsBS);
            this.Controls.Add(bindingNavigator);

            sqlUpdateCommand = new();
            sqlUpdateCommand.CommandText = "UPDATE Products SET ProductName = @ProductName, " +
                "SupplierID = @SupplierID, " +
                "CategoryID = @CategoryID, " +
                "QuantityPerUnit = @Quantity, " +
                "UnitPrice = @UnitPrice, " +
                "UnitsInStock = @UnitsInStock, " +
                "UnitsOnOrder = @UnitsOnOrder, " +
                "ReorderLevel = @ReorderLevel, " +
                "Discontinued = @Discontinued " +
                "WHERE  (ProductID = @ProductID)";

            sqlUpdateCommand.Connection = sqlCn;

            sqlUpdateCommand.Parameters.Add("@ProductName", SqlDbType.NVarChar);
            sqlUpdateCommand.Parameters.Add("@Quantity", SqlDbType.NVarChar);
            sqlUpdateCommand.Parameters.Add("@SupplierID", SqlDbType.Int);
            sqlUpdateCommand.Parameters.Add("@CategoryID", SqlDbType.Int);
            sqlUpdateCommand.Parameters.Add("@UnitPrice", SqlDbType.Money);
            sqlUpdateCommand.Parameters.Add("@UnitsInStock", SqlDbType.SmallInt);
            sqlUpdateCommand.Parameters.Add("@UnitsOnOrder", SqlDbType.SmallInt);
            sqlUpdateCommand.Parameters.Add("@ReorderLevel", SqlDbType.SmallInt);
            sqlUpdateCommand.Parameters.Add("@Discontinued", SqlDbType.Bit);
            sqlUpdateCommand.Parameters.Add("@ProductID", SqlDbType.Int);

            bindingNavigator.DeleteItem.Click += DeleteItem_Click;
            bindingNavigator.AddNewItem.Click += AddNewItem_Click;
        }

        private void AddNewItem_Click(object sender, EventArgs e)
        {
            DataRow newRow = productsDT.NewRow();
            newRow["ProductName"] = "New Product";
            newRow["SupplierID"] = 1;
            newRow["CategoryID"] = 1;
            newRow["QuantityPerUnit"] = "1";
            newRow["UnitPrice"] = 0;
            newRow["UnitsInStock"] = 0;
            newRow["UnitsOnOrder"] = 0;
            newRow["ReorderLevel"] = 0;
            newRow["Discontinued"] = false;

            productsDT.Rows.Add(newRow);

            try
            {
                sqlProducts.Update(productsDT);
                ClearData();
                LoadData();
                productsBS.MoveLast();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed");
            }

            
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                sqlProducts.Update(productsDT);
                MessageBox.Show("Success");
            } 
            catch(Exception)
            {
                ClearData();
                LoadData();
                MessageBox.Show("Failed");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            sqlUpdateCommand.Parameters["@ProductName"].Value = prdName.Text;
            sqlUpdateCommand.Parameters["@Quantity"].Value = prdQunatityPerUnit.Text;
            sqlUpdateCommand.Parameters["@SupplierID"].Value = prdSupplier.SelectedValue;
            sqlUpdateCommand.Parameters["@CategoryID"].Value = prdCategory.SelectedValue;
            sqlUpdateCommand.Parameters["@UnitPrice"].Value = prdUnitPrice.Value;
            sqlUpdateCommand.Parameters["@UnitsInStock"].Value = prdUnitsInStock.Value;
            sqlUpdateCommand.Parameters["@UnitsOnOrder"].Value = prdUnitsOnOrder.Value;
            sqlUpdateCommand.Parameters["@ReorderLevel"].Value = prdReorderLevel.Value;
            sqlUpdateCommand.Parameters["@Discontinued"].Value = prdDiscontinued.Checked;
            sqlUpdateCommand.Parameters["@ProductID"].Value = prdID.Text;

            sqlCn.Open();

            if (sqlUpdateCommand.ExecuteNonQuery() > 0)
                MessageBox.Show("Success");
            else
                MessageBox.Show("Failed");

            sqlCn.Close();
        }
    }
}