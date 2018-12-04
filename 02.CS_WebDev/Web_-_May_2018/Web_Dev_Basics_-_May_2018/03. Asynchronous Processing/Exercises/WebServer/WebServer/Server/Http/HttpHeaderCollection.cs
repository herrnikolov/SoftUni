namespace WebServer.Server.Http
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WebServer.Server.Http.Contracts;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly IDictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            //TODO
        }

        public bool ContainsKey(string key)
        {
            //TODO
        }

        public HttpHeader GetHeader(string key)
        {
            //TODO
            return null;
        }

        public override string ToString()
        {
            return string.Join("\n", this.headers);
        }
    }
}
