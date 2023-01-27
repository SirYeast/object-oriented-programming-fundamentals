namespace Lab2
{
    public class ParkingSpot
    {
        public int Number { get; }
        public CarPark CarPark { get; set; }
        public Vehicle? Vehicle { get; set; }

        public ParkingSpot(int number, CarPark carPark)
        {
            Number = number;
            CarPark = carPark;
        }
    }
}
