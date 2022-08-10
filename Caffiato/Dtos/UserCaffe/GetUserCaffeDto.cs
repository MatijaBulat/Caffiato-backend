namespace Caffiato.Dtos.UserCaffe
{
    public class GetUserCaffeDto
    {
        public GetUserCaffeDto()
        {
            Caffes = new HashSet<Caffe>();
            Transacts = new HashSet<Transact>();
        }

        public int IduserCaffe { get; set; }
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Username { get; set; }
        public string? Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Oib { get; set; }
        public int Points { get; set; }

        public virtual ICollection<Caffe> Caffes { get; set; }
        public virtual ICollection<Transact> Transacts { get; set; }
    }
}
