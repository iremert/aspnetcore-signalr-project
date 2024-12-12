namespace SignalRWebUI.Dtos.BasketDtos
{
    public class ResultBasketDto
    {
        public int BasketID { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int CarId { get; set; }
        public int TableNumberId { get; set; }
        public string CarName { get; set; }
    }
}
