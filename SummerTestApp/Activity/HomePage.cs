using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using SummerTestApp.Resources.DataHelper;
using Toolbar=Android.Support.V7.Widget.Toolbar;
namespace SummerTestApp.Activity
{
    [Activity(Label = "SummerTestApp", Theme = "@style/NoSmoking.Theme",  Icon = "@drawable/icon")]
    public class HomePage : AppCompatActivity
    {
        private TextView _maintextview;
        private DataBase _db;
        private Toolbar _toolbar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.home_page);
            _toolbar = FindViewById<Toolbar>(Resource.Id.main_toolbar);
            SetSupportActionBar(_toolbar);
            _maintextview = FindViewById<TextView>(Resource.Id.main_textview);
            _db = DataBase.GetInstance();
            var a = _db.SelectTablePerson();
            _maintextview.Text = a[0].ToString();
        }
    }
}