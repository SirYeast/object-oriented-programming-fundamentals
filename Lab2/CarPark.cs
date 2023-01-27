namespace Lab2
{
    public class CarPark
    {
        private readonly HashSet<ParkingSpot> _parkingSpots = new();

        private int _capacity = 0;

        public int Capacity { get { return _capacity; } }

        public CarPark(int capacity)
        {
            SetCapacity(capacity);
            InitializeEmptySpots();
        }

        private void SetCapacity(int newCapacity)
        {
            if (newCapacity < 1)
                throw new ArgumentException("Capacity must be greater than 0");

            _capacity = newCapacity;
        }

        private void InitializeEmptySpots()
        {
            for (int i = 1; i <= Capacity; i++)
            {
                _parkingSpots.Add(new ParkingSpot(i, this));
            }
        }

        public IReadOnlySet<ParkingSpot> GetParkingSpots()
        {
            return _parkingSpots;
        }

        public void ParkVehicle(Vehicle vehicle)
        {
            foreach (ParkingSpot parkingSpot in _parkingSpots)
            {
                if (parkingSpot.Vehicle == null)
                {
                    parkingSpot.Vehicle = vehicle;
                    vehicle.RegisterParkingSpot(parkingSpot);
                    break;
                }
            }
        }

        public void RemoveVehicle(string license)
        {
            Vehicle? vehicle = null;
            
            foreach (ParkingSpot parkingSpot in _parkingSpots)
            {
                if (parkingSpot.Vehicle?.LicenseNumber == license)
                {
                    vehicle = parkingSpot.Vehicle;
                    break;
                }
            }

            if (vehicle == null)
                throw new Exception($"Vehicle ({license}) could not be found in the car park");

            foreach (ParkingSpot parkingSpot in vehicle.RegisteredParkingSpots)
            {
                parkingSpot.Vehicle = null;
                vehicle.Unpark(parkingSpot);
            }
        }
    }
}
