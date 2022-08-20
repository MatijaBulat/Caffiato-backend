namespace Caffiato.Dtos.UserCaffeDtos
{
    public class AddUserCaffeDto
    {
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Oib { get; set; }
        public int Points { get; set; }

    }
}
