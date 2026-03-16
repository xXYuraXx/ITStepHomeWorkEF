namespace _02_Relationships_Seeder.Entities
{
    internal class OrderItemEntity
    {
        public int OrderId { get; set; }
        public OrderEntity? Order { get; set; }
        public int GameId { get; set; }
        public GameEntity? Game { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"OrderItem: Order {OrderId} - Game {GameId} x{Quantity}";
        }
    }
}
