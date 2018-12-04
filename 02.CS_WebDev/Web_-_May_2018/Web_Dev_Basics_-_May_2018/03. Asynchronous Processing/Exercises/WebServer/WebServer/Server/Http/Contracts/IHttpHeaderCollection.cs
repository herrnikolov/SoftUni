namespace WebServer.Server.Http.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IHttpHeaderCollection
    {
        void Add(HttpHeader head);
        bool ContainsKey(string key);

        HttpHeader GetHeader(string key);
    }
}
