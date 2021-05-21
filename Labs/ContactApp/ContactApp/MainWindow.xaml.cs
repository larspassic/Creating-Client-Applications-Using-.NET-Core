using ContactApp.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Documents;

namespace ContactApp
{
    public partial class MainWindow : Window
    {
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        
        public MainWindow()
        {
            InitializeComponent();

            LoadContacts();
        }

        private void LoadContacts()
        {
            var contacts = App.ContactRepository.GetAll();

            uxContactList.ItemsSource = contacts
                .Select(t => ContactModel.ToModel(t))
                .ToList();

            // OR
            //var uiContactModelList = new List<ContactModel>();
            //foreach (var repositoryContactModel in contacts)
            //{
            //    This is the .Select(t => ... )
            //    var uiContactModel = ContactModel.ToModel(repositoryContactModel);
            //
            //    uiContactModelList.Add(uiContactModel);
            //}

            //uxContactList.ItemsSource = uiContactModelList;
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new ContactWindow();

            if (window.ShowDialog() == true)
            {
                var uiContactModel = window.Contact;

                var repositoryContactModel = uiContactModel.ToRepositoryModel();

                App.ContactRepository.Add(repositoryContactModel);

                // OR
                //App.ContactRepository.Add(window.Contact.ToRepositoryModel());

                LoadContacts();
            }
        }

        //Empty functions for now
        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
        }

        //Created during Exercise 1 at 8:30PM on 5/20
        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            //Create a GridViewColumnHeader object
            GridViewColumnHeader column = (sender as GridViewColumnHeader);

            //Store the column name as a string
            string sortBy = column.Tag.ToString();

            //I don't really understand what this does
            if (listViewSortCol != null) //If there is already a sort applied previously maybe?
            {
                //Remove the existing sort?
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);

                //What does this do?
                uxContactList.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending; //Use Ascending as a default NEW direction to sort
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir) //If it's already ascending
            {
                //...then toggle to Descending
                newDir = ListSortDirection.Descending;
            }

            //Apply the sort?
            listViewSortCol = column;

            //Create a new adorner with the column name and direction?
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);

            //Apply the new sort adorner that we made... ...to the adorner layer? //MAYBE THIS IS THE TRIANGLES
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);

            //Sort the column
            uxContactList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));

        }
    }
}