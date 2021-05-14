using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//Assignment 03
//Author: Passic, Lars, 2011958

namespace Sorting_Listview_Columns
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Starter data from Cstructor
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "2DavePwd" });
            users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = users;

            //Create a "collectionview" object called view?
            //Got this from one of the links on cstructor but don't really know what it does.
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);

            view.SortDescriptions.Clear();

            //Testing the sorting of the column headers

            //Add a "Sort Description"
            //Tested switching back and forth between ascending and descending and this does work
            view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Descending));

            //Add another "Sort Description" ?
            //Tested and confirmed that this secondary SortDescription works! Even though 2DavePwd is added first, the secondary sort kicks in for the password column.
            view.SortDescriptions.Add(new SortDescription("Password", ListSortDirection.Ascending));
        }

       
        
        
        
        //I tried to create these two event handlers via Visual Studio "click" events but I can't get them to work.

        private void NameColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            //Asked a friend for help and they gave me this - how to pull in the column header
            var columnHeader = e.OriginalSource as GridViewColumnHeader;

            //Create the collectionView object
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);

            //First, Sabet said we need to clear the sort descriptions.
            view.SortDescriptions.Clear();

            //Add a "Sort Description"
            view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Descending));

        }


        private void PasswordColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            
            //Asked a friend for help and they gave me this - how to pull in the column header
            var columnHeader = e.OriginalSource as GridViewColumnHeader;

            //Create the collectionView object
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);

            //First, Sabet said we need to clear the sort descriptions.
            view.SortDescriptions.Clear();

            //Add another "Sort Description" ?
            //Tested and confirmed that this secondary SortDescription works! Even though 2DavePwd is added first, the secondary sort kicks in for the password column.
            view.SortDescriptions.Add(new SortDescription("Password", ListSortDirection.Ascending));

        }
    }
}
