namespace Lab13S13.Models
{
    public class Details
    {
        public int DetailsID { get; set; }
        public Products Products { get; set; }
        public Invoices Invoices { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public float Subtotal { get; set; }

    }
}
