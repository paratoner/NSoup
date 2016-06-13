using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoup
{
    public abstract class ConnectionBase<T>: CommunicationBase<T>
    {
        Uri url;
        Method method;
        Dictionary<string, string> headers;
        Dictionary<string, string> cookies;

        private ConnectionBase()
        {
            headers = new Dictionary<string, string>();
            cookies = new Dictionary<string, string>();
        }

        public Uri Url()
        {
            return url;
        }

        public T Url(URL url)
        {
            Validate.notNull(url, "URL must not be null");
            this.url = url;
            return (T)this;
        }

        public Method Method()
        {
            return method;
        }

        public T Method(Method method)
        {
            Validate.notNull(method, "Method must not be null");
            this.method = method;
            return (T)this;
        }

        public string Header(string name)
        {
            Validate.notNull(name, "Header name must not be null");
            return getHeaderCaseInsensitive(name);
        }

        public T Header(string name, string value)
        {
            Validate.notEmpty(name, "Header name must not be empty");
            Validate.notNull(value, "Header value must not be null");
            removeHeader(name); // ensures we don't get an "accept-encoding" and a "Accept-Encoding"
            headers.put(name, value);
            return (T)this;
        }

        public bool HasHeader(string name)
        {
            Validate.notEmpty(name, "Header name must not be empty");
            return getHeaderCaseInsensitive(name) != null;
        }

        /**
         * Test if the request has a header with this value (case insensitive).
         */
        public bool hasHeaderWithValue(string name, string value)
        {
            return hasHeader(name) && header(name).equalsIgnoreCase(value);
        }

        public T RemoveHeader(string name)
        {
            Validate.notEmpty(name, "Header name must not be empty");
            Map.Entry<string, string> entry = scanHeaders(name); // remove is case insensitive too
            if (entry != null)
                headers.remove(entry.getKey()); // ensures correct case
            return (T)this;
        }

        public Dictionary<string, string> Headers()
        {
            return headers;
        }

        private string GetHeaderCaseInsensitive(string name)
        {
            Validate.notNull(name, "Header name must not be null");
            // quick evals for common case of title case, lower case, then scan for mixed
            string value = headers.get(name);
            if (value == null)
                value = headers.get(name.toLowerCase());
            if (value == null)
            {
                KeyValuePair<string, string> entry = scanHeaders(name);
                if (entry != null)
                    value = entry.Value();
            }
            return value;
        }

        private Map.Entry<string, string> scanHeaders(string name)
        {
            string lc = name.toLowerCase();
            for (Map.Entry<string, string> entry : headers.entrySet())
            {
                if (entry.getKey().toLowerCase().equals(lc))
                    return entry;
            }
            return null;
        }

        public string cookie(string name)
        {
            Validate.notEmpty(name, "Cookie name must not be empty");
            return cookies.get(name);
        }

        public T cookie(string name, string value)
        {
            Validate.notEmpty(name, "Cookie name must not be empty");
            Validate.notNull(value, "Cookie value must not be null");
            cookies.put(name, value);
            return (T)this;
        }

        public boolean hasCookie(string name)
        {
            Validate.notEmpty(name, "Cookie name must not be empty");
            return cookies.containsKey(name);
        }

        public T removeCookie(string name)
        {
            Validate.notEmpty(name, "Cookie name must not be empty");
            cookies.remove(name);
            return (T)this;
        }

        public Map<string, string> cookies()
        {
            return cookies;
        }
    }
}
