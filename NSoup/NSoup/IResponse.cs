using NSoup.Html;

namespace NSoup
{
    /**
     * Represents a HTTP response.
     */
    public interface IResponse : CommunicationBase<IResponse>
    {

        /**
         * Get the status code of the response.
         * @return status code
         */
        int statusCode();

        /**
         * Get the status message of the response.
         * @return status message
         */
        string statusMessage();

        /**
         * Get the character set name of the response.
         * @return character set name
         */
        string charset();

        /**
         * Get the response content type (e.g. "text/html");
         * @return the response content type
         */
        string contentType();

        /**
         * Parse the body of the response as a Document.
         * @return a parsed Document
         * @throws IOException on error
         */
        Document Parse();

        /**
         * Get the body of the response as a plain string.
         * @return body
         */
        string Body();

        /**
         * Get the body of the response as an array of bytes.
         * @return body bytes
         */
        byte[] BodyAsBytes();
    }
}
