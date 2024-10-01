using Azure;
using Azure.Storage.Files.Shares;
using System.Net.Http.Headers;

namespace ST10390916CLDVPOE
{
    public class FileService
    {
        public async Task UploadFileAsync(string shareName, string fileName, Stream content)
        {
            var client = new HttpClient();
            string url = $"https://st10390916function.azurewebsites.net/api/UploadFile?" +
                $"code=2fpQeXmGvCpTRwnNxKjyNjbxKVZY99IcLL0A9wVvaBTTAzFug9CJ8Q%3D%3D&shareName={shareName}&fileName={fileName}";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            StreamContent streamcontent = new StreamContent(content);
            streamcontent.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.MimeUtility.GetMimeMapping(fileName));
            request.Content = streamcontent;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            System.Diagnostics.Debug.WriteLine(await response.Content.ReadAsStringAsync());
            System.Diagnostics.Debug.WriteLine(response.StatusCode);
        }
    }
}
