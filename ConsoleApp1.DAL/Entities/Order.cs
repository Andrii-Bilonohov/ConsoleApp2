namespace ConsoleApp1.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedDate { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
