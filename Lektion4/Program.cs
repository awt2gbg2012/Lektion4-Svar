using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lektion4.Controller;
using Lektion4.Model.Repository;

namespace Lektion4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exempel 1:   Gör en program-loop som frågar användaren om hen vill lista användare (list)
            //              eller avsluta (exit). Skapa lösningen mha MVC-mönstret.
            bool exit = false;
            Repository Repo = new Repository();
            DefaultController defaultController = new DefaultController();
            string input;
            while (!exit)
            {
                Console.WriteLine("Enter command + [enter] (? for help):");

                input = Console.ReadLine();

                var resultView = defaultController.handleInput(input);

                Console.WriteLine(resultView.Render());

                if (defaultController.Exit)
                    exit = true;
            }
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual string getFullName() { return string.Format("{0} {1}", FirstName, LastName); }
    }

    public class Doctor : Person
    {
        public override string getFullName() { return "Dr. " + base.getFullName(); }
    }
}
