using System;
using Auto;

class Program
{
    static void Main()
    {
        Vehicle vehicle = new Vehicle();
        vehicle.VehicleInfo();

		Roadster roadster = new Roadster();
        roadster.RoadsterInfo();
	
		FClassCar fClassCar = new FClassCar();
		fClassCar.FClassCarInfo();
	
        Console.ReadLine();
    }
}