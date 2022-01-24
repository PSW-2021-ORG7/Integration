using Integration_API;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationIntegrationTests
{
    public class MedicineSpecificationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private bool skippable = Environment.GetEnvironmentVariable("SkippableTest") != null;

        public MedicineSpecificationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        public HttpClient createClient()
        {
            WebApplicationFactoryClientOptions clientOptions = new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = true,
                BaseAddress = new Uri("http://localhost:44298"),
                HandleCookies = true
            };

            var client = _factory.CreateClient(clientOptions);
            client.DefaultRequestHeaders.Add("ApiKey", "ABC");

            return client;

        }

        public ByteArrayContent createByteArrayContent(object obj)
        {

            var content = JsonConvert.SerializeObject(obj);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return byteContent;
        }

        [SkippableTheory]
        [InlineData("/api/pharmacy/downloadSpec/Ibuprofen_400.pdf", "OK")]
        [InlineData("/api/pharmacy/downloadSpec/Brufen_600.pdf", "OK")]
        [InlineData("/api/pharmacy/downloadSpec/Bisoprolol_300.pdf", "NotFound")]
        [InlineData("/api/pharmacy/downloadSpec/Aspirin_100.pdf", "NotFound")]
        public async Task Download_specification(string url, string expectedStatusCode)
        {
            Skip.If(skippable);

            var client = createClient();

            var response = await client.GetAsync(url);

            Assert.Equal(expectedStatusCode, response.StatusCode.ToString());
        }

    }
}
