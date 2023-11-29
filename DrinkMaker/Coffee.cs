public class Coffee : Drink
{
    public string RoastValue;
    public string BeanType;

    public Coffee(string name, string color, double temp, string roast, string bean, int calories) : base(name, color, temp, false, calories)
    {
        BeanType = bean;
        RoastValue = roast;
    }
    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"A {this.RoastValue} roast made with {this.BeanType} beans.");
    }
}