
using NSoup;
using NSoup.Html;
using System;
using System.Collections.Generic;
using System.IO;
/**
* A Connection provides a convenient interface to fetch content from the web, and parse them into Documents.
* <p>
* To get a new Connection, use {@link org.jsoup.Jsoup#connect(string)}. Connections contain {@link Connection.Request}
* and {@link Connection.Response} objects. The request objects are reusable as prototype requests.
* </p>
* <p>
* Request configuration can be made using either the shortcut methods in Connection (e.g. {@link #userAgent(string)}),
* or by methods in the Connection.Request object directly. All request configuration must be made before the request is
* executed.
* </p>
*/
namespace NSoup
{
    public interface IConnection
    {

        /**
         * Set the request URL to fetch. The protocol must be HTTP or HTTPS.
         * @param url URL to connect to
         * @return this Connection, for chaining
         */
        IConnection Url(Uri url);

        /**
         * Set the request URL to fetch. The protocol must be HTTP or HTTPS.
         * @param url URL to connect to
         * @return this Connection, for chaining
         */
        IConnection Url(string url);

        /**
         * Set the request user-agent header.
         * @param userAgent user-agent to use
         * @return this Connection, for chaining
         */
        IConnection UserAgent(string userAgent);

        /**
         * Set the request timeouts (connect and read). If a timeout occurs, an IOException will be thrown. The default
         * timeout is 3 seconds (3000 millis). A timeout of zero is treated as an infinite timeout.
         * @param millis number of milliseconds (thousandths of a second) before timing out connects or reads.
         * @return this Connection, for chaining
         */
        IConnection Timeout(int millis);

        /**
         * Set the maximum bytes to read from the (uncompressed) connection into the body, before the connection is closed,
         * and the input truncated. The default maximum is 1MB. A max size of zero is treated as an infinite amount (bounded
         * only by your patience and the memory available on your machine).
         * @param bytes number of bytes to read from the input before truncating
         * @return this Connection, for chaining
         */
        IConnection MaxBodySize(int bytes);

        /**
         * Set the request referrer (aka "referer") header.
         * @param referrer referrer to use
         * @return this Connection, for chaining
         */
        IConnection Referrer(string referrer);

        /**
         * Configures the connection to (not) follow server redirects. By default this is <b>true</b>.
         * @param followRedirects true if server redirects should be followed.
         * @return this Connection, for chaining
         */
        IConnection FollowRedirects(bool followRedirects);

        /**
         * Set the request method to use, GET or POST. Default is GET.
         * @param method HTTP request method
         * @return this Connection, for chaining
         */
        IConnection Method(Method method);

        /**
         * Configures the connection to not throw exceptions when a HTTP error occurs. (4xx - 5xx, e.g. 404 or 500). By
         * default this is <b>false</b>; an IOException is thrown if an error is encountered. If set to <b>true</b>, the
         * response is populated with the error body, and the status message will reflect the error.
         * @param ignoreHttpErrors - false (default) if HTTP errors should be ignored.
         * @return this Connection, for chaining
         */
        IConnection IgnoreHttpErrors(bool ignoreHttpErrors);

        /**
         * Ignore the document's Content-Type when parsing the response. By default this is <b>false</b>, an unrecognised
         * content-type will cause an IOException to be thrown. (This is to prevent producing garbage by attempting to parse
         * a JPEG binary image, for example.) Set to true to force a parse attempt regardless of content type.
         * @param ignoreContentType set to true if you would like the content type ignored on parsing the response into a
         * Document.
         * @return this Connection, for chaining
         */
        IConnection IgnoreContentType(bool ignoreContentType);

        /**
         * Disable/enable TSL certificates validation for HTTPS requests.
         * <p>
         * By default this is <b>true</b>; all
         * connections over HTTPS perform normal validation of certificates, and will abort requests if the provided
         * certificate does not validate.
         * </p>
         * <p>
         * Some servers use expired, self-generated certificates; or your JDK may not
         * support SNI hosts. In which case, you may want to enable this setting.
         * </p>
         * <p>
         * <b>Be careful</b> and understand why you need to disable these validations.
         * </p>
         * @param value if should validate TSL (SSL) certificates. <b>true</b> by default.
         * @return this Connection, for chaining
         */
        IConnection ValidateTLSCertificates(bool value);

        /**
         * Add a request data parameter. Request parameters are sent in the request query string for GETs, and in the
         * request body for POSTs. A request may have multiple values of the same name.
         * @param key data key
         * @param value data value
         * @return this Connection, for chaining
         */
        IConnection Data(string key, string value);

        /**
         * Add an input stream as a request data paramater. For GETs, has no effect, but for POSTS this will upload the
         * input stream.
         * @param key data key (form item name)
         * @param filename the name of the file to present to the remove server. Typically just the name, not path,
         * component.
         * @param inputStream the input stream to upload, that you probably obtained from a {@link java.io.FileInputStream}.
         * You must close the InputStream in a {@code finally} block.
         * @return this Connections, for chaining
         */
        IConnection Data(string key, string filename, Stream inputStream);

        /**
         * Adds all of the supplied data to the request data parameters
         * @param data collection of data parameters
         * @return this Connection, for chaining
         */
        IConnection Data(IList<KeyVal> data);

        /**
         * Adds all of the supplied data to the request data parameters
         * @param data Dictionary of data parameters
         * @return this Connection, for chaining
         */
        IConnection Data(Dictionary<string, string> data);

        /**
         * Add a number of request data parameters. Multiple parameters may be set at once, e.g.: <code>.data("name",
         * "jsoup", "language", "Java", "language", "English");</code> creates a query string like:
         * <code>{@literal ?name=jsoup&language=Java&language=English}</code>
         * @param keyvals a set of key value pairs.
         * @return this Connection, for chaining
         */
        IConnection Data(params string[] keyvals);

        /**
         * Set a request header.
         * @param name header name
         * @param value header value
         * @return this Connection, for chaining
         * @see org.jsoup.Connection.Request#headers()
         */
        IConnection Header(string name, string value);

        /**
         * Set a cookie to be sent in the request.
         * @param name name of cookie
         * @param value value of cookie
         * @return this Connection, for chaining
         */
        IConnection Cookie(string name, string value);

        /**
         * Adds each of the supplied cookies to the request.
         * @param cookies Dictionary of cookie name {@literal ->} value pairs
         * @return this Connection, for chaining
         */
        IConnection Cookies(Dictionary<string, string> cookies);

        /**
         * Provide an alternate parser to use when parsing the response to a Document. If not set, defaults to the HTML
         * parser, unless the response content-type is XML, in which case the XML parser is used.
         * @param parser alternate parser
         * @return this Connection, for chaining
         */
        IConnection Parser(Parser parser);

        /**
         * Sets the default post data character set for x-www-form-urlencoded post data
         * @param charset character set to encode post data
         * @return this Connection, for chaining
         */
        IConnection PostDataCharset(string charset);

        /**
         * Execute the request as a GET, and parse the result.
         * @return parsed Document
         * @throws java.net.MalformedURLException if the request URL is not a HTTP or HTTPS URL, or is otherwise malformed
         * @throws HttpStatusException if the response is not OK and HTTP response errors are not ignored
         * @throws UnsupportedMimeTypeException if the response mime type is not supported and those errors are not ignored
         * @throws java.net.SocketTimeoutException if the connection times out
         * @throws IOException on error
         */
        Document Get();

        /**
         * Execute the request as a POST, and parse the result.
         * @return parsed Document
         * @throws java.net.MalformedURLException if the request URL is not a HTTP or HTTPS URL, or is otherwise malformed
         * @throws HttpStatusException if the response is not OK and HTTP response errors are not ignored
         * @throws UnsupportedMimeTypeException if the response mime type is not supported and those errors are not ignored
         * @throws java.net.SocketTimeoutException if the connection times out
         * @throws IOException on error
         */
        Document Post();

        /**
         * Execute the request.
         * @return a response object
         * @throws java.net.MalformedURLException if the request URL is not a HTTP or HTTPS URL, or is otherwise malformed
         * @throws HttpStatusException if the response is not OK and HTTP response errors are not ignored
         * @throws UnsupportedMimeTypeException if the response mime type is not supported and those errors are not ignored
         * @throws java.net.SocketTimeoutException if the connection times out
         * @throws IOException on error
         */
        IResponse Execute();

        /**
         * Get the request object associated with this connection
         * @return request
         */
        IRequest Request();

        /**
         * Set the connection's request
         * @param request new request object
         * @return this Connection, for chaining
         */
        IConnection Request(IRequest request);

        /**
         * Get the response, once the request has been executed
         * @return response
         */
        IResponse Response();

        /**
         * Set the connection's response
         * @param response new response
         * @return this Connection, for chaining
         */
        IConnection Response(IResponse response);

        /**
         * Common methods for Requests and Responses
         * @param <T> Type of Base, either Request or Response
         */
    }

}