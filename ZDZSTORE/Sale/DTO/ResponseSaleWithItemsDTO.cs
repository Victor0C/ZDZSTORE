namespace ZDZSTORE.Sale.DTO
{
    public class ResponseSaleWithItemsDTO
    {
        public string id { get; set; }

        public string userID { get; set; }

        public long customerCPF { get; set; }

        public long price { get; set; }

        public ICollection<ResponseItemDTO> items { get; set; }
    }
}
