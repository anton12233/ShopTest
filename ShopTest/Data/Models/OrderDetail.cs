namespace ShopTest.Data.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderID { get; set; }
        public int carID { get; set; }
        public uint price { get; set; }
        public virtual Car someCar { get; set; }
        public virtual Order someOrder { get; set; }
        
    }
}
