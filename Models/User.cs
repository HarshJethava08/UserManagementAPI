namespace UserManagementAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        // Use 'required' to avoid warnings
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}