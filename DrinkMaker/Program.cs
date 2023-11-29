List<Drink> AllMyDrinks = new List<Drink>();

Soda Coke = new Soda("Coca-Cola", "brown", 40, 100, false);
Soda DCoke = new Soda("Diet Coke", "brown", 40, 10, true);

Coffee Latte = new Coffee("Latte","Caramel", 140, "light", "arabica", 50);
Coffee BlackCoffee = new Coffee("Regular", "Black", 160, "dark", "Java", 60);

Wine TwoBuckChuck = new Wine("Two Buck Chuck", "Red", 50, "Northern California", 2022, false, 40);
Wine WinterWhite = new Wine("Leelanau Winter White", "White", 50, "Traverse Valley", 2021, false, 40);

AllMyDrinks.Add(Coke);
AllMyDrinks.Add(DCoke);
AllMyDrinks.Add(Latte);
AllMyDrinks.Add(BlackCoffee);
AllMyDrinks.Add(TwoBuckChuck);
AllMyDrinks.Add(WinterWhite);

foreach (Drink drink in AllMyDrinks)
{
    drink.ShowDrink();
}