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

            //Checked the collection exercise - looks like it is okay to do the homework in main.

            //Use System.Linq for all the requirements. IE.Don't use a for/foreach loop to manipulate the users list.

            //1.Display to the console, the names of the users where the password is "hello" and you can use a foreach here only.
            //Hint: Where

            //Use LINQ query to find the results
            var results = users.Where(t => t.Password = "hello"); //Not sure how to get this working

            //Announce the result to the console
            Console.WriteLine($"Users where password was \"hello\" "); //use escape characters to say "hello"

            //Allowed to use foreach to display each result out
            foreach (var result in results)
            {
                Console.WriteLine($"Found user {result.Name}");

            }

            //2.Delete any passwords that are the lower-cased version of their Name. Do not just look for "steve".It has to be data - driven.
            //Hint: Remove or RemoveAll


            //3.Delete the first User that has the password "hello".
            //Hint: First or FirstOrDefault


            //4.Display to the console the remaining users with their Name and Password.
            //Hint: ForEach
            var finalresults = users.FindAll(a => a != null);

            foreach (var result in finalresults)
            {
                Console.WriteLine($"Found user {result.Name}");

            }
        }
    }
}
