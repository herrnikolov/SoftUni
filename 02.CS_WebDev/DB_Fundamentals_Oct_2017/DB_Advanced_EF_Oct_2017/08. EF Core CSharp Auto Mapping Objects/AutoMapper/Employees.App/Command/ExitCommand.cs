﻿namespace Employees.App.Command
{
    using System;

    class ExitCommand : ICommand
    {
        public string Execute(params string[] args)
        {
            Console.WriteLine("Goodbye!");
            Environment.Exit(0);

            return String.Empty;
        }
    }
}
