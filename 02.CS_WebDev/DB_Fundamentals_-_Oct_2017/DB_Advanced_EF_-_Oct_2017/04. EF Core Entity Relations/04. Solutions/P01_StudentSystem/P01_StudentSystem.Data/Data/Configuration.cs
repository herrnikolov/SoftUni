﻿namespace P01_StudentSystem.Data
{
    using System;

    public static class Configuration
    {
        public static string ConnectionString { get; set; } = @"Server=(LocalDb)\MSSQLLocalDB;Database=SoftUni;Integrated Security=True;";
    }
}