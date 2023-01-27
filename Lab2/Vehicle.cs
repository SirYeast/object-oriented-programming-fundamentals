namespace Lab2
{
    public class Vehicle
    {
        private readonly HashSet<ParkingSpot> _parkingSpots = new();

        private string _licenseNumber;

        public IReadOnlySet<ParkingSpot> RegisteredParkingSpots { get { return _parkingSpots; } }

        public string LicenseNumber { get { return _licenseNumber; } }

        public Vehicle(string licenseNumber)
        {
            UpdateLicenseNumber(licenseNumber);
        }

        public void UpdateLicenseNumber(string licenseNumber)
        {
            if (licenseNumber.Length < 2 || licenseNumber.Length > 7 || !licenseNumber.All(c => char.IsLetterOrDigit(c)))
                throw new ArgumentException("License must be alphanumerical and between 2 and 7 characters");

            _licenseNumber = licenseNumber;
        }

        public void RegisterParkingSpot(ParkingSpot parkingSpot)
        {
            if (_parkingSpots.Contains(parkingSpot))
                throw new ArgumentException("Parking spot is already owned by this vehicle");

            _parkingSpots.Add(parkingSpot);
        }

        public void Unpark(ParkingSpot parkingSpot)
        {
            _parkingSpots.Remove(parkingSpot);
        }
    }
}
