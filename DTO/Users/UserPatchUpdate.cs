namespace IoT.DTO.Users
{
    public class UserPatchUpdate
    {
        // using nullable fields for that reason.

        public string? Name { get; set; }
        public string? Surname { get; set; }

        public int? Age { get; set; }
    }
}
