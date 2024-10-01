using Azure.Storage.Queues;

namespace ST10390916CLDVPOE
{
    public class QueueService
    {
        //store message using queue
        public async Task SendMessageAsync(string queueName, string message)
        {
            HttpClient client = new HttpClient();
            string url = "https://st10390916function.azurewebsites.net/api/ProcessQueueMessage?code=nYdFs-SQC4xRktDdfDOfFWxmzuWhGMAVe0o9AxJEuydpAzFuv7K20Q%3D%3D" + $"&queueName={queueName}&message={message}";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            System.Diagnostics.Debug.WriteLine(await response.Content.ReadAsStringAsync());
            System.Diagnostics.Debug.WriteLine(response.StatusCode);

        }

    }
}
