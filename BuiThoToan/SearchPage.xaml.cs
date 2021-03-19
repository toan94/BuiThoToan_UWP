using BuiThoToan.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace BuiThoToan
{
    public sealed partial class SearchPage : Page
    {
        SQLiteConnection conn;

        public SearchPage()
        {
            this.InitializeComponent();
            conn = MainPage.DbConfigure();
            conn.CreateTable<Contact>();
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            string mess = "";
            string Cname = name.Text;
            var contact = conn.Table<Contact>().Where(c => c.ContactName == Cname ).FirstOrDefault();
            if (contact == null) { 
                mess = "Contact does not exist";
                msg.Text = mess;
                name.Text = "";
                phone.Text = "";
            }
            else
            {
                msg.Text = "";
                name.Text = contact.ContactName;
                phone.Text = contact.ContactPhone;
            }

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
