// See https://aka.ms/new-console-template for more information

Vehicle MyCar = new Vehicle("Ford Minivan", 7, "Blue", true);
Vehicle MyTruck = new Vehicle("Chevy Silverado", "Black");
Vehicle MySailboat = new Vehicle("Sailboat", 7, "Red, Blue, and Orange", false);
Vehicle MyMonsterTruck = new Vehicle("Bigfoot", "Neon Green");

List<Vehicle> AllMyVehicles = new List<Vehicle>();

AllMyVehicles.Add(MyCar);
AllMyVehicles.Add(MyTruck);
AllMyVehicles.Add(MySailboat);
AllMyVehicles.Add(MyMonsterTruck);

foreach (Vehicle vehicle in AllMyVehicles)
{
    vehicle.ShowInfo();
}

MySailboat.Travel(100);

Console.WriteLine(MySailboat._Mileage);