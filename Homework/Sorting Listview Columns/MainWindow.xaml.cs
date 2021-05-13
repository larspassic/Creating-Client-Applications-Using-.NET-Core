﻿using System;
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
            


            //Add a "Sort Description"
            //Tested switching back and forth between ascending and descending and this does work
            view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Descending));

            //Add another "Sort Description" ?
            //Tested and confirmed that this secondary SortDescription works! Even though 2DavePwd is added first, the secondary sort kicks in for the password column.
            view.SortDescriptions.Add(new SortDescription("Password", ListSortDirection.Ascending));
        }
    }
}
