using BLL.Entity;
using BLL.EntityList;
using BLL.EntityManager;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace DetailedView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TitleList titleList = new TitleList();
        PublisherList publisherList = new PublisherList();
        BindingSource titleListBS;
        BindingNavigator nav;
        string lastID;
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData(); 
        }

        void ClearData()
        {
            titleList.Clear();
            publisherList.Clear();
            lastID = null;
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

            nav.DeleteItem.Click += DeleteItem_Click;
            titleListBS.AddingNew += TitleListBS_AddingNew;
            titleListBS.ListChanged += TitleListBS_ListChanged;
            titleListBS.PositionChanged += TitleListBS_PositionChanged;
            titleListBS.MoveFirst();
            lastID = titleList[0].title_id;
        }

        private void TitleListBS_AddingNew(object? sender, System.ComponentModel.AddingNewEventArgs e)
        {
            e.NewObject = new Title();
            Title title = e.NewObject as Title;
            var dic = CreateDictionaryFromRow(title);
            if (!TitleManager.InsertTitle(dic))
            {
                ClearData();
                LoadData();
            }
        }

        private void TitleListBS_PositionChanged(object? sender, EventArgs e)
        {
            var title = titleListBS.Current as Title;
            if (title is not null)
                lastID = title.title_id;
        }

        private void DeleteItem_Click(object? sender, EventArgs e)
        {
            Title title = titleListBS.Current as Title;
            if (title is not null)
            {
                if(!TitleManager.DeleteTitleByID(new() { ["title_id"] = lastID })) {
                    ClearData();
                    LoadData();
                }
            }
            
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

        private void TitleListBS_ListChanged(object? sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemChanged)
            {
                var title = titleListBS[e.NewIndex] as Title;
                if (title is not null && title.State != EntityState.Added)
                    title.State = EntityState.Changed;
            } 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Title title = titleListBS.Current as Title;
            var dic = CreateDictionaryFromRow(title);
            if (!TitleManager.UpdateTitleByTitleID(dic))
            {
                ClearData();
                LoadData();
            }
        }
    }
}