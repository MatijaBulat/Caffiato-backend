namespace Caffiato.Dtos.AddressDtos
{
    public class AddAddressDto
    {
        public string StreetNumber { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? PostCode { get; set; }
        public int CaffeId { get; set; }

    }
}
