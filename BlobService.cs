namespace ST10390916CLDVPOE
{
    public class BlobService
    {
        public async Task UploadBlobAsync(string containerName, string blobName, Stream content)
        {
            var client = new HttpClient();
            string url = "https://st10390916function.azurewebsites.net/api/UploadBlob?" +
                "code=ytHJfD3JBoUcTdfHRIM-dqDS-vvi2oTT9nUvtaB2JFi1AzFuz16Xfg%3D%3D" + $"&containerName={containerName}&blobName={blobName}";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            StreamContent streamcontent = new StreamContent(content);
            request.Content = streamcontent;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            System.Diagnostics.Debug.WriteLine(await response.Content.ReadAsStringAsync());
            System.Diagnostics.Debug.WriteLine(response.StatusCode);
        }
    }
}
