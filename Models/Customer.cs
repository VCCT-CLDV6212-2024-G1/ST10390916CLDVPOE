using Azure;
using Azure.Data.Tables;

namespace ST10390916CLDVPOE.Models
{
    public class Customer : ITableEntity
    {

        //properties for ITableEntity
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Customer()
        {
            PartitionKey = "Customer";
            RowKey = Guid.NewGuid().ToString();
        }

    }
}
