namespace Entities.Dtos
{
    public class ProductData
    {
        public CountData BasketCount { get; set; }
        public CountData FavoriteCount { get; set; }
        public CountData OrderCountL3D { get; set; }
        public CountData PageViewCount { get; set; }
    }
}
