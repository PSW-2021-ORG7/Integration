using Integration_API;
using Integration_API.DTO;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationIntegrationTests
{
    public class TenderTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public TenderTests(WebApplicationFactory<Startup> factory)
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

        /*
        [Theory]
        [InlineData("/api/tendering/test", "OK")]
        [InlineData("/api/tendering", "OK")]
        //[InlineData("/api/tendering/getAllTenders", "OK")]
        //[InlineData("/api/tendering/getAllActiveTenders", "OK")]

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
        [InlineData("/api/tendering/1", "OK")]
        [InlineData("/api/tendering/2", "OK")]
        [InlineData("/api/tendering/222", "NotFound")]
        public async Task Get_tender_by_id(string url, string expectedStatusCode)
        {

            //Arrange
            var client = createClient();

            //Act
            var response = await client.GetAsync(url);

            //Assert
            //response.EnsureSuccessStatusCode();
            Assert.Equal(expectedStatusCode, response.StatusCode.ToString());

        }

        [Theory]
        [InlineData("/api/tendering/addTender", false, "01/01/2022", "01/02/2022", 0, "OK")]

        public async Task Add_tender(string url, bool isActive, string startDate, string endDate, int idWinnerPharmacy, string expectedStatusCode)
        {

            //Arrange
            var client = createClient();
            TenderDTO dto = new TenderDTO
            {
                IsActive = isActive,
                StartDate = startDate,
                EndDate = endDate,
                IdWinnerPharmacy = idWinnerPharmacy
            };

            var byteContent = createByteArrayContent(dto);
            var result = client.PostAsync(url, byteContent).Result;
            //Act

            //Assert           
            Assert.Equal(expectedStatusCode, result.StatusCode.ToString()); ;

        }
        */
    }
}
