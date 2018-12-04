    using System;
    using System.Collections.Generic;

    public class Pizza
    {
        public static int PizzaNameMinLength = 1;
        public static int PizzaNameMaxLength = 15;
        public static int PizzaToppingsMaxCount = 10;

        private string name;
        private Dough dough;
        private ICollection<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public double CalculateCalories()
        {
            double calories = this.dough.CalculateCalories();

            this.toppings.ForEach(t => calories += t.CalculateCalories());

            return calories;
        }

        public Dough Dough
        {
            set
            {
                this.dough = value;
            }
        }

        public int NumberOfToppings
        {
            get => this.toppings.Count;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (value.Length < PizzaNameMinLength || value.Length > PizzaNameMaxLength)
                {
                    throw new ArgumentException(string.Format(Messages.InvalidPizzaName,
                        PizzaNameMinLength, 
                        PizzaNameMaxLength));
                }

                this.name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.NumberOfToppings == PizzaToppingsMaxCount)
            {
                throw new ArgumentException(string.Format(Messages.InvalidToppingsCount, PizzaToppingsMaxCount));
            }
            else
            {
                this.toppings.Add(topping);
            }
        }
    }
