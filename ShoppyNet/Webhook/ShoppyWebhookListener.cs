using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shoppy
{
    public class ShoppyWebhookListener
    {
        private readonly byte[] _key;
        private readonly HttpListener _listener;

        public delegate void LogHandler(object sender, ShoppyWebhookLog message);
        public event LogHandler OnMessage;

        public ShoppyWebhookListener(int port, string key)
        {
            _key = Encoding.UTF8.GetBytes(key);

            _listener = new HttpListener();
            _listener.Prefixes.Add($"http://*:{port}/");
        }

        private bool ValidateMessage(string signature, string body)
        {
            using (HMACSHA512 hmacSha256 = new HMACSHA512(_key))
            {
                var computed = hmacSha256.ComputeHash(Encoding.UTF8.GetBytes(body));

                string computedStr = "";
                for (int i = 0; i < computed.Length; i++)
                    computedStr += computed[i].ToString("x2");

                return computedStr == signature;
            }
        }

        public void Start()
        {
            _listener.Start();

            while (true)
            {
                var context = _listener.GetContext();
                string body = new StreamReader(context.Request.InputStream).ReadToEnd();

                if (ValidateMessage(context.Request.Headers.Get("X-Shoppy-Signature"), body))
                {
                    Task.Run(() =>
                    {
                        var msg = JsonConvert.DeserializeObject<ShoppyWebhookLog>(body);
                        OnMessage?.Invoke(this, msg);
                    });
                }

                context.Response.Close();
            }
        }
    }
}
