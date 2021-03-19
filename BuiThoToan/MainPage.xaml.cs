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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BuiThoToan
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        SQLiteConnection conn;
        private ObservableCollection<Contact> ContactList;
        public MainPage()
        {
            this.InitializeComponent();
            conn = DbConfigure();
            conn.CreateTable<Contact>();
            ContactList = new ObservableCollection<Contact>();
            
            
        }


        public static SQLiteConnection DbConfigure()
        {
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Contact.db");
            SQLiteConnection c = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            Debug.WriteLine(path);
            return c;
        }
        public void InsertContact(Contact c)
        {
            conn.Insert(c);
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            var contact = conn.Table<Contact>().Where(c => c.ContactPhone == phone.Text).FirstOrDefault();
            if (contact == null)
            {
                Contact NewContact = new Contact
                {
                    ContactName = name.Text,
                    ContactPhone = phone.Text

                };
                InsertContact(NewContact);
                message.Text = "";
            }
            else
            {
                message.Text = "phone number existed in database, use another phone number";
            }
            
        }

        private void showBtn_Click(object sender, RoutedEventArgs e)
        {
            var query = conn.Table<Contact>().ToList();
            ContactList.Clear();
            query.ForEach(c =>
            {
                ContactList.Add(c);
            });
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SearchPage));
        }
    }
}
