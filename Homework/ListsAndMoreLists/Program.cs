using System;
using System.Collections.Generic;
using System.Windows;

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
        }
    }
}
