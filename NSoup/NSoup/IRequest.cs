using System;
using System.Collections.Generic;

namespace NSoup
{
    /**
       * Represents a HTTP request.
       */
    public interface IRequest : CommunicationBase<IRequest>
    {

        /**
         * Get the request timeout, in milliseconds.
         * @return the timeout in milliseconds.
         */
        int Timeout();

        /**
         * Update the request timeout.
         * @param millis timeout, in milliseconds
         * @return this Request, for chaining
         */
        IRequest Timeout(int millis);

        /**
         * Get the maximum body size, in bytes.
         * @return the maximum body size, in bytes.
         */
        int MaxBodySize();

        /**
         * Update the maximum body size, in bytes.
         * @param bytes maximum body size, in bytes.
         * @return this Request, for chaining
         */
        IRequest MaxBodySize(int bytes);

        /**
         * Get the current followRedirects configuration.
         * @return true if followRedirects is enabled.
         */
        bool FollowRedirects();

        /**
         * Configures the request to (not) follow server redirects. By default this is <b>true</b>.
         * @param followRedirects true if server redirects should be followed.
         * @return this Request, for chaining
         */
        IRequest FollowRedirects(bool followRedirects);

        /**
         * Get the current ignoreHttpErrors configuration.
         * @return true if errors will be ignored; false (default) if HTTP errors will cause an IOException to be
         * thrown.
         */
        bool IgnoreHttpErrors();

        /**
         * Configures the request to ignore HTTP errors in the response.
         * @param ignoreHttpErrors set to true to ignore HTTP errors.
         * @return this Request, for chaining
         */
        IRequest IgnoreHttpErrors(bool ignoreHttpErrors);

        /**
         * Get the current ignoreContentType configuration.
         * @return true if invalid content-types will be ignored; false (default) if they will cause an IOException to
         * be thrown.
         */
        bool IgnoreContentType();

        /**
         * Configures the request to ignore the Content-Type of the response.
         * @param ignoreContentType set to true to ignore the content type.
         * @return this Request, for chaining
         */
        IRequest IgnoreContentType(bool ignoreContentType);

        /**
         * Get the current state of TLS (SSL) certificate validation.
         * @return true if TLS cert validation enabled
         */
        bool ValidateTLSCertificates();

        /**
         * Set TLS certificate validation.
         * @param value set false to ignore TLS (SSL) certificates
         */
        void ValidateTLSCertificates(bool value);

        /**
         * Add a data parameter to the request
         * @param keyval data to add.
         * @return this Request, for chaining
         */
        IRequest Data(KeyVal keyval);

        /**
         * Get all of the request's data parameters
         * @return collection of keyvals
         */
        List<KeyVal> Data();

        /**
         * Specify the parser to use when parsing the document.
         * @param parser parser to use.
         * @return this Request, for chaining
         */
        IRequest Parser(Parser parser);

        /**
         * Get the current parser to use when parsing the document.
         * @return current Parser
         */
        Parser Parser();

        /**
         * Sets the post data character set for x-www-form-urlencoded post data
         * @param charset character set to encode post data
         * @return this Request, for chaining
         */
        IRequest PostDataCharset(string charset);

        /**
         * Gets the post data character set for x-www-form-urlencoded post data
         * @return character set to encode post data
         */
        string PostDataCharset();

    }
}
