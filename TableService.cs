using Azure.Data.Tables;
using ST10390916CLDVPOE.Models;

namespace ST10390916CLDVPOE
{
    public class TableService
    {
        //add customer to table
        public async Task AddEntityAsync(Customer customer)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://st10390916function.azurewebsites.net/api/UploadCustomer?" +
                $"code=dpiadHLR9_DYyLTaJdc6QbnY9xUs95ipadsbk7FPR_orAzFud0qENA%3D%3D&tableName=customers" +
                $"&partitionKey={customer.PartitionKey}&rowKey={customer.RowKey}&data={customer}" +
                $"&firstName={customer.FirstName}&lastName={customer.LastName}&phoneNumber={customer.PhoneNumber}&email={customer.Email}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            System.Diagnostics.Debug.WriteLine(await response.Content.ReadAsStringAsync());
            System.Diagnostics.Debug.WriteLine(response.StatusCode);
        }

        //add product to table
        public async Task AddEntityAsync(Product product)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://st10390916function.azurewebsites.net/api/UploadProduct?" +
                $"code=sT3mfhPxFzBLFeOu8AazVAVvpnO1dJiYWzkFw0x55UqOAzFuwPVPmg%3D%3D&tableName=products&partitionKey={product.PartitionKey}" +
                $"&rowKey={product.RowKey}&data={product}&productName={product.ProductName}&productCode={product.ProductCode}" +
                $"&price={product.Price}&productWeight={product.ProductWeight}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            System.Diagnostics.Debug.WriteLine(await response.Content.ReadAsStringAsync());
            System.Diagnostics.Debug.WriteLine(response.StatusCode);
        }

    }
}
