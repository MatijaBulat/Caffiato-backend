namespace Caffiato.Dtos.AddressDtos
{
    public class GetAddressDto
    {
        public int Idaddress { get; set; }
        public string StreetNumber { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? PostCode { get; set; }
        public int CaffeId { get; set; }

        public virtual Caffe Caffe { get; set; } = null!;
    }
}
