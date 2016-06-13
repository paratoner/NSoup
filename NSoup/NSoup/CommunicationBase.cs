using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoup
{
    public interface CommunicationBase<T> where T : CommunicationBase<T>
    {

        /**
         * Get the URL
         * @return URL
         */
        Uri Url();

        /**
         * Set the URL
         * @param url new URL
         * @return this, for chaining
         */
        T Url(Uri url);

        /**
         * Get the request method
         * @return method
         */
        Method Method();

        /**
         * Set the request method
         * @param method new method
         * @return this, for chaining
         */
        T Method(Method method);

        /**
         * Get the value of a header. This is a simplified header model, where a header may only have one value.
         * <p>
         * Header names are case insensitive.
         * </p>
         * @param name name of header (case insensitive)
         * @return value of header, or null if not set.
         * @see #hasHeader(string)
         * @see #cookie(string)
         */
        string Header(string name);

        /**
         * Set a header. This method will overwrite any existing header with the same case insensitive name.
         * @param name Name of header
         * @param value Value of header
         * @return this, for chaining
         */
        T Header(string name, string value);

        /**
         * Check if a header is present
         * @param name name of header (case insensitive)
         * @return if the header is present in this request/response
         */
        bool HasHeader(string name);

        /**
         * Check if a header is present, with the given value
         * @param name header name (case insensitive)
         * @param value value (case insensitive)
         * @return if the header and value pair are set in this req/res
         */
        bool HasHeaderWithValue(string name, string value);

        /**
         * Remove a header by name
         * @param name name of header to remove (case insensitive)
         * @return this, for chaining
         */
        T RemoveHeader(string name);

        /**
         * Retrieve all of the request/response headers as a map
         * @return headers
         */
        Dictionary<string, string> headers();

        /**
         * Get a cookie value by name from this request/response.
         * <p>
         * Response objects have a simplified cookie model. Each cookie set in the response is added to the response
         * object's cookie key=value map. The cookie's path, domain, and expiry date are ignored.
         * </p>
         * @param name name of cookie to retrieve.
         * @return value of cookie, or null if not set
         */
        string Cookie(string name);

        /**
         * Set a cookie in this request/response.
         * @param name name of cookie
         * @param value value of cookie
         * @return this, for chaining
         */
        T Cookie(string name, string value);

        /**
         * Check if a cookie is present
         * @param name name of cookie
         * @return if the cookie is present in this request/response
         */
        bool hasCookie(string name);

        /**
         * Remove a cookie by name
         * @param name name of cookie to remove
         * @return this, for chaining
         */
        T RemoveCookie(string name);

        /**
         * Retrieve all of the request/response cookies as a map
         * @return cookies
         */
        Dictionary<string, string> cookies();
    }
}
