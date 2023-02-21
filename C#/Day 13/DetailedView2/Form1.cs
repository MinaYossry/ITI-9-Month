using BLL.Entity;
using BLL.EntityList;
using BLL.EntityManager;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace DetailedView2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TitleList titleList;
        TitleList titleListCopy;
        PublisherList publisherList;
        BindingSource titleListBS;
        BindingNavigator nav;

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void ClearData()
        {
            titleList.Clear();
            publisherList.Clear();
            Controls.Remove(nav);
            lblTitleID.DataBindings.Clear();
            txtTitle.DataBindings.Clear();
            txtNotes.DataBindings.Clear();
            txtType.DataBindings.Clear();
            drpPublisher.DataBindings.Clear();
            drpPublisher.DataSource = null;
            numPrice.DataBindings.Clear();
            numAdvance.DataBindings.Clear();
            numRoyalty.DataBindings.Clear();
            numYTDSales.DataBindings.Clear();
            txtNotes.DataBindings.Clear();
            dtPublicationDate.DataBindings.Clear();
        }

        void LoadData()
        {
            titleList = TitleManager.SelectAllTitles();
            publisherList = PublisherManager.SelectAllPublishers();
            titleListCopy = new TitleList();
            foreach (var title in titleList)
                titleListCopy.Add(title);

            titleListBS = new();
            titleListBS.DataSource = titleList;

            nav = new BindingNavigator(titleListBS);
            this.Controls.Add(nav);

            lblTitleID.DataBindings.Add("Text", titleListBS, "title_id");
            txtTitle.DataBindings.Add("Text", titleListBS, "title");
            txtType.DataBindings.Add("Text", titleListBS, "type");
            drpPublisher.DataSource = publisherList;
            drpPublisher.DisplayMember = "pub_name";
            drpPublisher.ValueMember = "pub_id";
            drpPublisher.DataBindings.Add("SelectedValue", titleListBS, "pub_id");
            numPrice.DataBindings.Add("Value", titleListBS, "price", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);
            numAdvance.DataBindings.Add("Value", titleListBS, "advance", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);
            numRoyalty.DataBindings.Add("Value", titleListBS, "royalty", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);
            numYTDSales.DataBindings.Add("Value", titleListBS, "ytd_sales", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);
            txtNotes.DataBindings.Add("Text", titleListBS, "notes");
            dtPublicationDate.DataBindings.Add("Value", titleListBS, "pubdate");
            lblState.DataBindings.Add("Text", titleListBS, "State");

            titleListBS.AddingNew += TitleListBS_AddingNew;
            titleListBS.ListChanged += TitleListBS_ListChanged;
            titleListBS.MoveFirst();
            nav.DeleteItem.Visible = false;
        }

        private void TitleListBS_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
            e.NewObject = new Title() { State = EntityState.Added };
        }


        Dictionary<string, object> CreateDictionaryFromRow(Title title)
        {
            var dictParam = new Dictionary<string, object>();

            if (title is not null)
            {

                PropertyInfo[] propertyInfo = title.GetType().GetProperties();
                foreach (PropertyInfo property in propertyInfo)
                {
                    var columnName = property.Name;
                    if (columnName != "State")
                    {
                        dictParam.Add(columnName, property.GetValue(title));
                    }
                }

            }

            return dictParam;
        }

        private void TitleListBS_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemChanged)
            {
                var title = titleListBS[e.NewIndex] as Title;
                if (title is not null && title.State != EntityState.Added)
                    title.State = EntityState.Changed;
                lblState.Text = title.State.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int count = 0;

            for (int i = 0; i < titleList.Count; i++)
            {
                switch (titleList[i].State)
                {
                    case EntityState.Deleted:
                        if(Delete(titleList[i]))
                        {
                            i--;
                            count++;
                        }
                        break;
                    case EntityState.Added:
                        if (Add(titleList[i]))
                            count++;
                        break;
                    case EntityState.Changed:
                        if (Update(titleList[i]))
                            count++;
                        break;
                }
            }

            lblState.Text = ((Title)(titleListBS.Current)).State.ToString();
            MessageBox.Show($"Rows Updated {count}");
        }

        bool Delete(Title title)
        {
            var dictParam = new Dictionary<string, object> { ["title_id"] = title.title_id };

            if (TitleManager.DeleteTitleByID(dictParam))
            {
                titleListBS.Remove(title);
                return true;
            }
            else
            {
                title.State = BLL.Entity.EntityState.UnChanged;
                return false;
            }
        }

        bool Update(Title title)
        {
            var dictParam = CreateDictionaryFromRow(title);

            if (TitleManager.UpdateTitleByTitleID(dictParam))
            {
                title.State = BLL.Entity.EntityState.UnChanged;
                return true;
            }

            return false;
        }

        bool Add(Title title)
        {
            var dictParam = CreateDictionaryFromRow(title);

            if (TitleManager.InsertTitle(dictParam))
            {
                title.State = BLL.Entity.EntityState.UnChanged;
                return true;
            }
            else
            {
                titleListBS.Remove(title);
                return false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Title title = titleListBS.Current as Title;

            if (title is not null)
            {
                switch(title.State)
                {
                    case EntityState.Added:
                        titleListBS.Remove(title);
                        break;
                    case EntityState.Deleted:
                        title.State = EntityState.UnChanged;
                        break;
                    default:
                        title.State = EntityState.Deleted;
                        break;
                }
            }

            lblState.Text = title.State.ToString();
        }

        private void lblState_TextChanged(object sender, EventArgs e)
        {
            switch(lblState.Text)
            {
                case "Deleted":
                    lblState.ForeColor = Color.Red;
                    break;
                case "Added":
                    lblState.ForeColor = Color.Green;
                    break;
                case "Changed":
                    lblState.ForeColor = Color.Blue;
                    break;
                default:
                    lblState.ForeColor = Color.Black;
                    break;
            }
        }
    }
}