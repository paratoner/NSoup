
using NSoup.Html;
/**
The core public access point to the jsoup functionality.

@author Jonathan Hedley */
namespace NSoup
{
    public class NSoup
    {

        private NSoup() { }

        /**
         Parse HTML into a Document. The parser will make a sensible, balanced document tree out of any HTML.

         @param html    HTML to parse
         @param baseUri The URL where the HTML was retrieved from. Used to resolve relative URLs to absolute URLs, that occur
         before the HTML declares a {@code <base href>} tag.
         @return sane HTML
         */
        public static Document Parse(string html, string baseUri)
        {
            return Parser.parse(html, baseUri);
        }

        /**
         Parse HTML into a Document, using the provided Parser. You can provide an alternate parser, such as a simple XML
         (non-HTML) parser.

         @param html    HTML to parse
         @param baseUri The URL where the HTML was retrieved from. Used to resolve relative URLs to absolute URLs, that occur
         before the HTML declares a {@code <base href>} tag.
         @param parser alternate {@link Parser#xmlParser() parser} to use.
         @return sane HTML
         */
        public static Document parse(string html, string baseUri, Parser parser)
        {
            return parser.parseInput(html, baseUri);
        }

        /**
         Parse HTML into a Document. As no base URI is specified, absolute URL detection relies on the HTML including a
         {@code <base href>} tag.

         @param html HTML to parse
         @return sane HTML

         @see #parse(string, string)
         */
        public static Document parse(string html)
        {
            return Parser.parse(html, "");
        }

        /**
         * Creates a new {@link IConnection} to a URL. Use to fetch and parse a HTML page.
         * <p>
         * Use examples:
         * <ul>
         *  <li><code>Document doc = Jsoup.connect("http://example.com").userAgent("Mozilla").data("name", "jsoup").get();</code></li>
         *  <li><code>Document doc = Jsoup.connect("http://example.com").cookie("auth", "token").post();</code></li>
         * </ul>
         * @param url URL to connect to. The protocol must be {@code http} or {@code https}.
         * @return the connection. You can add data, cookies, and headers; set the user-agent, referrer, method; and then execute.
         */
        public static IConnection Connect(string url)
        {
            return HttpConnection.Connect(url);
        }

        /**
         Parse the contents of a file as HTML.

         @param in          file to load HTML from
         @param charsetName (optional) character set of file contents. Set to {@code null} to determine from {@code http-equiv} meta tag, if
         present, or fall back to {@code UTF-8} (which is often safe to do).
         @param baseUri     The URL where the HTML was retrieved from, to resolve relative links against.
         @return sane HTML

         @throws IOException if the file could not be found, or read, or if the charsetName is invalid.
         */
        public static Document parse(File in, string charsetName, string baseUri) throws IOException
        {
        return DataUtil.load(in, charsetName, baseUri);
        }

        /**
         Parse the contents of a file as HTML. The location of the file is used as the base URI to qualify relative URLs.

         @param in          file to load HTML from
         @param charsetName (optional) character set of file contents. Set to {@code null} to determine from {@code http-equiv} meta tag, if
         present, or fall back to {@code UTF-8} (which is often safe to do).
         @return sane HTML

         @throws IOException if the file could not be found, or read, or if the charsetName is invalid.
         @see #parse(File, string, string)
         */
        public static Document parse(File in, string charsetName) throws IOException
        {
        return DataUtil.load(in, charsetName, in.getAbsolutePath());
        }

        /**
        Read an input stream, and parse it to a Document.

        @param in          input stream to read. Make sure to close it after parsing.
        @param charsetName (optional) character set of file contents. Set to {@code null} to determine from {@code http-equiv} meta tag, if
        present, or fall back to {@code UTF-8} (which is often safe to do).
        @param baseUri     The URL where the HTML was retrieved from, to resolve relative links against.
        @return sane HTML

        @throws IOException if the file could not be found, or read, or if the charsetName is invalid.
        */
        public static Document parse(InputStream in, string charsetName, string baseUri) throws IOException
        {
        return DataUtil.load(in, charsetName, baseUri);
        }

        /**
         Read an input stream, and parse it to a Document. You can provide an alternate parser, such as a simple XML
         (non-HTML) parser.

         @param in          input stream to read. Make sure to close it after parsing.
         @param charsetName (optional) character set of file contents. Set to {@code null} to determine from {@code http-equiv} meta tag, if
         present, or fall back to {@code UTF-8} (which is often safe to do).
         @param baseUri     The URL where the HTML was retrieved from, to resolve relative links against.
         @param parser alternate {@link Parser#xmlParser() parser} to use.
         @return sane HTML

         @throws IOException if the file could not be found, or read, or if the charsetName is invalid.
         */
        public static Document parse(InputStream in, string charsetName, string baseUri, Parser parser) throws IOException
        {
        return DataUtil.load(in, charsetName, baseUri, parser);
        }

        /**
         Parse a fragment of HTML, with the assumption that it forms the {@code body} of the HTML.

         @param bodyHtml body HTML fragment
         @param baseUri  URL to resolve relative URLs against.
         @return sane HTML document

         @see Document#body()
         */
        public static Document parseBodyFragment(string bodyHtml, string baseUri)
        {
            return Parser.parseBodyFragment(bodyHtml, baseUri);
        }

        /**
         Parse a fragment of HTML, with the assumption that it forms the {@code body} of the HTML.

         @param bodyHtml body HTML fragment
         @return sane HTML document

         @see Document#body()
         */
        public static Document parseBodyFragment(string bodyHtml)
        {
            return Parser.parseBodyFragment(bodyHtml, "");
        }

        /**
         Fetch a URL, and parse it as HTML. Provided for compatibility; in most cases use {@link #connect(string)} instead.
         <p>
         The encoding character set is determined by the content-type header or http-equiv meta tag, or falls back to {@code UTF-8}.

         @param url           URL to fetch (with a GET). The protocol must be {@code http} or {@code https}.
         @param timeoutMillis IConnection and read timeout, in milliseconds. If exceeded, IOException is thrown.
         @return The parsed HTML.

         @throws java.net.MalformedURLException if the request URL is not a HTTP or HTTPS URL, or is otherwise malformed
         @throws HttpStatusException if the response is not OK and HTTP response errors are not ignored
         @throws UnsupportedMimeTypeException if the response mime type is not supported and those errors are not ignored
         @throws java.net.SocketTimeoutException if the connection times out
         @throws IOException if a connection or read error occurs

         @see #connect(string)
         */
        public static Document parse(URL url, int timeoutMillis) throws IOException
        {
            IConnection con = HttpConnection.connect(url);
            con.timeout(timeoutMillis);
        return con.get();
            }

            /**
             Get safe HTML from untrusted input HTML, by parsing input HTML and filtering it through a white-list of permitted
             tags and attributes.

             @param bodyHtml  input untrusted HTML (body fragment)
             @param baseUri   URL to resolve relative URLs against
             @param whitelist white-list of permitted HTML elements
             @return safe HTML (body fragment)

             @see Cleaner#clean(Document)
             */
            public static string clean(string bodyHtml, string baseUri, Whitelist whitelist)
        {
            Document dirty = parseBodyFragment(bodyHtml, baseUri);
            Cleaner cleaner = new Cleaner(whitelist);
            Document clean = cleaner.clean(dirty);
            return clean.body().html();
        }

        /**
         Get safe HTML from untrusted input HTML, by parsing input HTML and filtering it through a white-list of permitted
         tags and attributes.

         @param bodyHtml  input untrusted HTML (body fragment)
         @param whitelist white-list of permitted HTML elements
         @return safe HTML (body fragment)

         @see Cleaner#clean(Document)
         */
        public static string clean(string bodyHtml, Whitelist whitelist)
        {
            return clean(bodyHtml, "", whitelist);
        }

        /**
         * Get safe HTML from untrusted input HTML, by parsing input HTML and filtering it through a white-list of
         * permitted
         * tags and attributes.
         *
         * @param bodyHtml input untrusted HTML (body fragment)
         * @param baseUri URL to resolve relative URLs against
         * @param whitelist white-list of permitted HTML elements
         * @param outputSettings document output settings; use to control pretty-printing and entity escape modes
         * @return safe HTML (body fragment)
         * @see Cleaner#clean(Document)
         */
        public static string clean(string bodyHtml, string baseUri, Whitelist whitelist, Document.OutputSettings outputSettings)
        {
            Document dirty = parseBodyFragment(bodyHtml, baseUri);
            Cleaner cleaner = new Cleaner(whitelist);
            Document clean = cleaner.clean(dirty);
            clean.outputSettings(outputSettings);
            return clean.body().html();
        }

        /**
         Test if the input HTML has only tags and attributes allowed by the Whitelist. Useful for form validation. The input HTML should
         still be run through the cleaner to set up enforced attributes, and to tidy the output.
         @param bodyHtml HTML to test
         @param whitelist whitelist to test against
         @return true if no tags or attributes were removed; false otherwise
         @see #clean(string, org.jsoup.safety.Whitelist) 
         */
        public static boolean isValid(string bodyHtml, Whitelist whitelist)
        {
            Document dirty = parseBodyFragment(bodyHtml, "");
            Cleaner cleaner = new Cleaner(whitelist);
            return cleaner.isValid(dirty);
        }

    }
}