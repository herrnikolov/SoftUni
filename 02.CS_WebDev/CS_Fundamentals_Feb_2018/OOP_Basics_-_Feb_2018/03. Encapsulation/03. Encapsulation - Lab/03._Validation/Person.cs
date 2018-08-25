﻿using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private const decimal min_salary = 460;
    private const int min_length = 3;

    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;
    public string FirstName
    {
        get { return this.firstName; }
        private set
        {
            if (value.Length < min_length)
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        private set
        {
            if (value.Length < min_length)
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }

            this.lastName = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
            this.age = value;
        }
    }

    public decimal Salary
    {
        get { return this.salary; }
        private set
        {
            if (value < min_salary)
            {
                throw new ArgumentException($"Salary cannot be less than {min_salary} leva!");
            }
            this.salary = value;
        }
    }
    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }
    public void IncreaseSalary(decimal percentage)
    {
        if (this.Age > 30)
        {
            this.salary += this.salary * percentage / 100;
        }
        else
        {
            this.salary += this.salary * percentage / 200;
        }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
    }

    //public override string ToString()
    //{
    //    return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
    //}
}