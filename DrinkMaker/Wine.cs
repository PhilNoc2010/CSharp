public class Wine : Drink
{
    public string Region;
    public int YearBottled;

    public Wine (string name, string color, double temp, string region, int yearBottled, bool isCarbonated, int calories) : base(name, color, temp, isCarbonated, calories)
    {
        Region = region;
        YearBottled = yearBottled;
    }
    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Bottled in {this.YearBottled} from the {this.Region}.");
    }
}
