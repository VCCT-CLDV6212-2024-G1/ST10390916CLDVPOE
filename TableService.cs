using Azure.Data.Tables;
using ST10390916CLDVPOE.Models;

namespace ST10390916CLDVPOE
{
    public class TableService
    {
        //used to access Azure table
        private readonly TableClient _tableCustomers;
        private readonly TableClient _tableProducts;

        //connect to table
        public TableService(IConfiguration configuration)
        {
            //define the type of connection string
            var connectionString = configuration["AzureStorage:ConnectionString"];
            var serviceClient = new TableServiceClient(connectionString);

            _tableCustomers = serviceClient.GetTableClient("customers");
            _tableCustomers.CreateIfNotExists();

            _tableProducts = serviceClient.GetTableClient("products");
            _tableProducts.CreateIfNotExists();

        }

        //add customer to table
        public async Task AddEntityAsync(Customer customer)
        {
            await _tableCustomers.AddEntityAsync(customer);
        }

        //add product to table
        public async Task AddEntityAsync(Product product)
        {
            await _tableProducts.AddEntityAsync(product);
        }

    }
}
