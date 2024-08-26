using Azure.Data.Tables;
using Azure;

namespace ST10390916CLDVPOE.Models
{
    public class Product : ITableEntity
    {

        //properties for ITableEntity
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public string ProductName { get; set; }
        public double Price { get; set; }
        public string ProductCode { get; set; }
        public double ProductWeight { get; set; }

        public Product()
        {
            PartitionKey = "Product";
            RowKey = Guid.NewGuid().ToString();
        }
    }
}
