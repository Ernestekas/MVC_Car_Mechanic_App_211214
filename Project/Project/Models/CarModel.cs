namespace Project.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public int YearManufactured { get; set; }
        public string Manufacturer { get; set; }
        public string PlateNumbers { get; set; }
        public int MechanicId { get; set; }
    }
}
