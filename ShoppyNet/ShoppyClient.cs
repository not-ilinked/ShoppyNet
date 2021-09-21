using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace Shoppy
{
    class ParsedResponse
    {
        public ParsedResponse(HttpResponseMessage origin)
        {
            Body = JsonConvert.DeserializeObject<JToken>(origin.Content.ReadAsStringAsync().Result);

            Headers = new Dictionary<string, string>();
            foreach (var header in origin.Headers)
                Headers.Add(header.Key, header.Value.ElementAt(0));
        }

        public JToken Body { get; private set; }
        public Dictionary<string, string> Headers { get; private set; }
    }

    public class ShoppyClient
    {
        private readonly HttpClient _client;

        public string Token { get; private set; }
        public ShoppyUserSettings User { get; private set; }
        public ShoppySettings Settings { get; private set; }

        public ShoppyClient(string authToken)
        {
            Token = authToken;

            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Authorization", authToken);
            _client.DefaultRequestHeaders.Add("User-Agent", "Shoppy.NET");
        }

        private ParsedResponse MakeRequest(string httpMethod, string endpoint, object jsonObject = null)
        {
            while (true)
            {
                var resp = _client.SendAsync(new HttpRequestMessage() { RequestUri = new Uri("https://shoppy.gg/api/v1" + endpoint), Method = new HttpMethod(httpMethod), Content = jsonObject == null ? null : new StringContent(JsonConvert.SerializeObject(jsonObject), Encoding.UTF8, "application/json" )}).Result;

                if (resp.StatusCode == (HttpStatusCode)429)
                {
                    Thread.Sleep(resp.Headers.RetryAfter.Delta.Value);

                    continue;
                }
                else if (resp.StatusCode == HttpStatusCode.Unauthorized)
                    throw new ShoppyTokenException();
                else if (resp.StatusCode >= HttpStatusCode.BadRequest)
                    throw new ShoppyException(resp.StatusCode, resp.ReasonPhrase);

                return new ParsedResponse(resp);
            }
        }


        public ShoppyPaginatedList<ShoppyOrder> GetOrders(int page = 1)
        {
            return new ShoppyPaginatedList<ShoppyOrder>(MakeRequest("GET", "/orders/?page=" + page));
        }

        public ShoppyOrder GetOrder(string id)
        {
            return MakeRequest("GET", "/orders/" + id).Body.ToObject<ShoppyOrder>();
        }


        public ShoppyPaginatedList<ShoppyProduct> GetProducts(int page = 1)
        {
            return new ShoppyPaginatedList<ShoppyProduct>(MakeRequest("GET", "/products/?page=" + page));
        }

        public ShoppyProduct GetProduct(string id)
        {
            return MakeRequest("GET", "/products/" + id).Body.ToObject<ShoppyProduct>();
        }


        public void CreateProduct(ShoppyProductUpdate product)
        {
            MakeRequest("PUT", "/products/", product);
        }

        public void UpdateProduct(string id, ShoppyProductUpdate product)
        {
            MakeRequest("POST", "/products/" + id, product);
        }

        public void DeleteProduct(string id)
        {
            MakeRequest("DELETE", "/products/" + id);
        }


        public ShoppyPaginatedList<ShoppyFeedback> GetFeedbacks(int page = 1)
        {
            return new ShoppyPaginatedList<ShoppyFeedback>(MakeRequest("GET", "/feedbacks/?page=" + page));
        }

        public ShoppyFeedback GetFeedback(string id)
        {
            return MakeRequest("GET", "/feedbacks/" + id).Body.ToObject<ShoppyFeedback>();
        }

        public ShoppySettingsContainer GetSettings()
        {
            var acc = MakeRequest("GET", "/settings").Body.ToObject<ShoppySettingsContainer>();
            User = acc.User;
            Settings = acc.Settings;
            return acc;
        }

        public void ChangeSettings(ShoppySettings settings)
        {
            MakeRequest("POST", "/settings", new { settings });
        }

        public ShoppyPayResponse Pay(ShoppyProductUpdate options)
        {
            return MakeRequest("POST", "/pay", new { product = options }).Body.ToObject<JObject>().Value<JObject>("details").ToObject<ShoppyPayResponse>();
        }
    }
}
