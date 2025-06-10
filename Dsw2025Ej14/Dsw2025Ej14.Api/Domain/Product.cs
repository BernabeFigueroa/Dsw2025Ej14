namespace Dsw2025Ej14.Api.Domain
{
    public class Product
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public decimal CurrentUnitPrice { get; set; }
        public bool IsActive { get; set; }
    }
}
