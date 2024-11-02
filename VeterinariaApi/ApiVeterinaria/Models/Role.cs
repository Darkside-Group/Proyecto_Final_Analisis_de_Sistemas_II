namespace ApiVenta.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        // Propiedad de navegación inversa
        public ICollection<User> Users { get; set; }
    }
}
