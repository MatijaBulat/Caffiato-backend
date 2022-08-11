namespace Caffiato.Dtos.DealDtos
{
    public class GetDealDto
    {
        public int Iddeal { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public int Points { get; set; }
        public decimal Price { get; set; }
        public int CaffeId { get; set; }
        public bool? Active { get; set; }

        public virtual Caffe Caffe { get; set; } = null!;
    }
}
