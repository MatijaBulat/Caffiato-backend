namespace Caffiato.Dtos.AddressDtos
{
    public class UpdateAddressDto
    {
        public int Idaddress { get; set; }
        public string StreetNumber { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? PostCode { get; set; }

    }
}
