
using System.IO;
/**
* Signals that a HTTP request resulted in a not OK HTTP response.
*/
namespace NSoup
{
    public class HttpStatusException : IOException
    {
        private int statusCode;
        private string url;

        public HttpStatusException(string message, int statusCode, string url) : base(message)
        {

            this.statusCode = statusCode;
            this.url = url;
        }

        public int getStatusCode()
        {
            return statusCode;
        }

        public string getUrl()
        {
            return url;
        }

        public override string ToString()
        {
            return base.ToString() + ". Status=" + statusCode + ", URL=" + url;
        }
    }
}
