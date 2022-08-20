namespace Caffiato.Dtos.CaffeDtos
{
    public class UpdateCaffeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int UserCaffeId { get; set; }

    }
}
