using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Book
{
    //1. Add Fields
    private string title;
    private string author;
    private decimal price;

    //2. Add Constructors
    public Book(string author, string title, decimal price)
    {
        this.Title = title;
        this.Author = author;
        this.Price = price;
    }

    //3. Add Properties
    public string Title
    {
        get
        {
            return this.title;
        }
        set
        {
            //TODO validate value
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }
    public string Author
    {
        get
        {
            return this.author;
        }
        set
        {
            //TODO validate value
            string[] authorNames = value.Split();
            if (authorNames.Length == 2 && char.IsDigit(authorNames[1] [0]))
            {
                throw new ArgumentException("Author not valid!");
            }
            this.author = value;
        }
    }
    public virtual decimal Price
    {
        get
        {
            return this.price;
        }
        set
        {
            //TODO validate value
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }
    //4. Add Methods
    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.Append("Type: ").AppendLine(this.GetType().Name)
            .Append("Title: ").AppendLine(this.Title)
            .Append("Author: ").AppendLine(this.Author)
            .Append("Price: ").Append($"{this.Price:f2}")
            .AppendLine();

        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }


}