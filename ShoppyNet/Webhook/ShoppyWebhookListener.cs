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
        public byte[] Key { get; private set; }
        private readonly HttpListener _listener;

        public delegate void LogHandler(object sender, ShoppyWebhookLog message);
        public event LogHandler OnMessage;

        public ShoppyWebhookListener(int port)
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add($"http://*:{port}/");
        }

        public ShoppyWebhookListener(int port, string key) : this(port)
        {
            Key = Encoding.UTF8.GetBytes(key);
        }

        protected virtual bool ValidateMessage(string signature, string body)
        {
            return ShoppyUtils.ComputeHash(Key, body) == signature;
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
