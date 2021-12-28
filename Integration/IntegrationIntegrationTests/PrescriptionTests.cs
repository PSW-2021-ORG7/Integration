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
    public class PrescriptionTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public PrescriptionTests(WebApplicationFactory<Startup> factory)
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

        [Theory]
        [InlineData("/api/prescription/test", "OK")]
        [InlineData("/api/prescription", "OK")]
        public async Task Get_http_request(string url, string expectedStatusCode)
        {
            //Arrange
            var client = createClient();

            //Act
            var response = await client.GetAsync(url);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(expectedStatusCode, response.StatusCode.ToString());
        }

        [Theory]
        [InlineData("/api/prescription/1", "OK")]
        [InlineData("/api/prescription/2", "OK")]
        [InlineData("/api/prescription/222", "NotFound")]
        public async Task Get_prescription_by_id(string url, string expectedStatusCode)
        {

            //Arrange
            var client = createClient();

            //Act
            var response = await client.GetAsync(url);

            //Assert
            //response.EnsureSuccessStatusCode();
            Assert.Equal(expectedStatusCode, response.StatusCode.ToString());

        }

    }
}
