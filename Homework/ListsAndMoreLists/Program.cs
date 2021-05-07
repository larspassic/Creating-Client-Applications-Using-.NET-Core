using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;  

//Assignment 2
//Author: Passic, Lars, 2011958

namespace ListsAndMoreLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });
            users.Add(new Models.User { Name = "John", Password = "d$Mx&3#" });
            users.Add(new Models.User { Name = "Mary", Password = "asdfJKL1" });

            //Checked the collection exercise - looks like it is okay to do the homework in main.

            //Use System.Linq for all the requirements. IE.Don't use a for/foreach loop to manipulate the users list.

            ////////////////////
            //1.Display to the console, the names of the users where the password is "hello" and you can use a foreach here only.
            //Hint: Where
            ////////////////////

            //Use LINQ query to find the results
            var results = users.Where(t => t.Password == "hello");

            //Announce the result to the console
            Console.WriteLine($"Users where password was \"hello\" "); //use escape characters to say "hello"

            //Allowed to use foreach to display each result out
            foreach (var result in results)
            {
                Console.WriteLine($"Found user {result.Name}, {result.Password}");
            }

            //Extra space
            Console.WriteLine();


            ////////////////////
            //2.Delete any passwords that are the lower-cased version of their Name. Do not just look for "steve".It has to be data - driven.
            //Hint: Remove or RemoveAll
            ////////////////////


            //Use a find query to find users where the name matches the lower case version of their name
            var passwordresults = users.FindAll(t => (t.Name).ToLower() == t.Password);

            //Explain to the console what we are going to do
            Console.WriteLine($"Removing users for their password matching their name, starting with: {passwordresults[0].Name}");

            //Actually remove the users that we found
            users.RemoveAll(t => (t.Name).ToLower() == t.Password);

            //Extra space
            Console.WriteLine();



            ////////////////////
            //3.Delete the first User that has the password "hello".
            //Hint: First or FirstOrDefault
            ////////////////////

            //Find the first user where password is equal to "hello"
            var helloresults = users.Find(t => t.Password == "hello");

            //Explain to the console what we are going to do
            Console.WriteLine($"Removing the first user who's password is \"hello\": {helloresults.Name}, {helloresults.Password}");

            //Actually remove the user
            users.Remove(helloresults);

            //Extra space
            Console.WriteLine();



            ////////////////////
            //4.Display to the console the remaining users with their Name and Password.
            //Hint: ForEach
            ////////////////////

            //Pull back all of the users
            var finalresults = users.FindAll(a => a != null);

            //Announce to the console what we are about to do
            Console.WriteLine($"Displaying all remaining users:");

            //Loop through each remaining user
            foreach (var result in finalresults)
            {
                Console.WriteLine($"Found user {result.Name}, {result.Password}");

            }

            //Extra space
            Console.WriteLine();

            //Keep the program running
            Console.ReadLine();
        }
    }
}
