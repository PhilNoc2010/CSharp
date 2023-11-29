public class Soda : Drink
{
    public bool IsDiet;

    public Soda(string name, string color, double temp, int calories, bool isDiet) : base(name, color, temp, true, calories)
    {
        IsDiet = isDiet;
    }

    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Is a Diet Drink: {this.IsDiet}");
    }


}