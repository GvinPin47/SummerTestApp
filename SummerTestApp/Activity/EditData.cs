using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using SummerTestApp.Fragments;
using SummerTestApp.Models;
using SummerTestApp.Resources.DataHelper;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SummerTestApp.Activity
{
    [Activity(Label = "SummerTestApp", Theme = "@style/NoSmoking.Theme", MainLauncher = true,NoHistory = true,Icon = "@drawable/icon")]
    public class EditData : AppCompatActivity
    {
        
        private ImageView _datepick;
        private TextView _datetext;
        private ImageView _timepick;
        private TextView _timetext;
        private readonly char[] _delitemerChars = {':'};
        private EditText _cigPerDay;
        private EditText _packetPrice;
        private EditText _resin;
        private EditText _nicotine;
        private Button _saveToDbButton;
        private Toolbar _toolbar;
       private List<User> _lstuser=new List<User>();
        private DataBase _db;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            SetContentView(Resource.Layout.edit_data_layout);
            _db = DataBase.GetInstance();
            _db.CreateDataBase();
            FindViews();
            _saveToDbButton.Click+=SaveToDbButtonOnClick;
            SetSupportActionBar(_toolbar);
            
        }

        private void SaveToDbButtonOnClick(object sender, EventArgs eventArgs)
        {
            var user = new User()
            {
                CurrentDate = _datetext.Text,
                CurrentTime = _timetext.Text,
                CigPerDay = _cigPerDay.Text,
                PacketPrice = _packetPrice.Text,
                Resin = int.Parse(_resin.Text),
                Nicotin = decimal.Parse(_nicotine.Text)         
            };
            _db.InsertIntoTableUser(user);
            StartActivity(typeof(HomePage));
        }

        private void FindViews()
        {
            _toolbar = FindViewById<Toolbar>(Resource.Id.main_toolbar);
            _toolbar.SetTitle(Resource.String.toolbar_title);
            _datepick = FindViewById<ImageView>(Resource.Id.date_picker);
            _datepick.Click += DatepickOnClick;
            _datetext = FindViewById<TextView>(Resource.Id.data_text);

            _timepick = FindViewById<ImageView>(Resource.Id.time_picker);
            _timepick.Click += TimepickOnClick;           
            _timetext = FindViewById<TextView>(Resource.Id.time_text);

            _cigPerDay = FindViewById<EditText>(Resource.Id.sig_per_day_count);
            _packetPrice = FindViewById<EditText>(Resource.Id.packet_price_count);
            _resin = FindViewById<EditText>(Resource.Id.resin_count);
            _nicotine = FindViewById<EditText>(Resource.Id.nicotine_count);
            _saveToDbButton = FindViewById<Button>(Resource.Id.save_toDb_button);          
        }

        private void TimepickOnClick(object sender, EventArgs eventArgs)
        {
            var frag = TimePickerFragment.NewInstance(delegate (TimeSpan time)
            {
                var timestring = time.ToString();
                var splitString = timestring.Split(_delitemerChars);
                _timetext.Text = $"{splitString[0]}:{splitString[1]}";
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

       


        private void DatepickOnClick(object sender, EventArgs eventArgs)
        {
            var frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {

                _datetext.Text = time.ToShortDateString();
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);

        }

      
    }
}