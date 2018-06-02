namespace WebServer.Server.Enums
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public enum HttpStatusCode
    {
        Ok = 200,
        MovedPermanently = 301,
        Found = 302,
        MovedTemporary = 303,
        NotAuthorized = 401,
        NotFound = 404,
        InternalServerError = 500
    }
}
