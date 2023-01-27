using Lab2;

CarPark park1 = new(10);

Vehicle newVehicle = new("A1A1A1");
Vehicle newVehicle2 = new("A2A2A2");

park1.ParkVehicle(newVehicle);
park1.ParkVehicle(newVehicle2);
park1.ParkVehicle(newVehicle);

foreach (ParkingSpot parkingSpot in park1.GetParkingSpots())
{
    Console.WriteLine($"Spot {parkingSpot.Number}: {parkingSpot.Vehicle?.LicenseNumber}");
}

park1.RemoveVehicle(newVehicle.LicenseNumber);

Console.WriteLine("-------------------------------");

foreach (ParkingSpot parkingSpot in park1.GetParkingSpots())
{
    Console.WriteLine($"Spot {parkingSpot.Number}: {parkingSpot.Vehicle?.LicenseNumber}");
}