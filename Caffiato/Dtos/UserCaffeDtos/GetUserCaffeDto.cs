namespace Caffiato.Dtos.UserCaffeDtos
{
    public class GetUserCaffeDto
    {
        public GetUserCaffeDto()
        {
            Caffes = new HashSet<Caffe>();
            Transacts = new HashSet<Transact>();
        }

        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Oib { get; set; }
        public int Points { get; set; }

        public virtual ICollection<Caffe> Caffes { get; set; }
        public virtual ICollection<Transact> Transacts { get; set; }
    }
}
