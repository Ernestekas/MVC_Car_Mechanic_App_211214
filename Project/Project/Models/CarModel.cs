using System.ComponentModel;

namespace Project.Models
{
    public class CarModel
    {
        [DisplayName("Id: ")]
        public int Id { get; set; }
        [DisplayName("Year Manufactured: ")]
        public int YearManufactured { get; set; }
        [DisplayName("Manufacturer: ")]
        public string Manufacturer { get; set; }
        [DisplayName("Plate Numbers: ")]
        public string PlateNumbers { get; set; }
        [DisplayName("Mechanic Id: ")]
        public int MechanicId { get; set; }
    }
}
