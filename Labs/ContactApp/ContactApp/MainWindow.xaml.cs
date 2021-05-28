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
        private ContactModel selectedContact; // Added 5/27/2021 during lab


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

        //Adding "update contact" functions

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            var window = new ContactWindow();
            window.Contact = selectedContact.Clone();

            

            if (window.ShowDialog() == true)
            {
                App.ContactRepository.Update(window.Contact.ToRepositoryModel());
                LoadContacts();
            }
        }

        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileChange.IsEnabled = (selectedContact != null);
            uxContextFileChange.IsEnabled = uxFileChange.IsEnabled;
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

        //Important function - detect if selection has been made
        private void uxContactList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedContact = (ContactModel)uxContactList.SelectedValue; // "Unbox the value as a ContactModel object"

            // Exercise 1 under Delete - fix the context menu
            uxContextFileDelete.IsEnabled = (selectedContact != null);
            uxContextFileChange.IsEnabled = (selectedContact != null);
        }


        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.ContactRepository.Remove(selectedContact.Id);
            selectedContact = null;
            LoadContacts();
        }

        //This code disables the file -> Delete option if there is no contact selected.
        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedContact != null);
        }

        //This code disables the context menu delete option if there is no contact selected.
        private void uxContextFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxContextFileDelete.IsEnabled = (selectedContact != null);
        }

        private void uxContactList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            uxFileChange_Click(sender, null);
        }
    }
}