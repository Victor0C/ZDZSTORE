namespace ZDZSTORE.Sale.DTO
{
    public class ResponseSaleDTO
    {
        public string id { get; set; }

        public string userID { get; set; }

        public long customerCPF { get; set; }

        public long price { get; set; }

        public int amountItems { get; set; }
    }
}
