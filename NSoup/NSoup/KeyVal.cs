using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoup
{
    /**
   * A Key Value tuple.
   */
    public abstract class KeyVal
    {

        /**
         * Update the key of a keyval
         * @param key new key
         * @return this KeyVal, for chaining
         */
        public abstract KeyVal Key(string key);

        /**
         * Get the key of a keyval
         * @return the key
         */
        public abstract string Key();

        /**
         * Update the value of a keyval
         * @param value the new value
         * @return this KeyVal, for chaining
         */
        public abstract KeyVal Value(string value);

        /**
         * Get the value of a keyval
         * @return the value
         */
        public abstract string Value();

        /**
         * Add or update an input stream to this keyVal
         * @param inputStream new input stream
         * @return this KeyVal, for chaining
         */
        public abstract KeyVal InputStream(Stream inputStream);

        /**
         * Get the input stream associated with this keyval, if any
         * @return input stream if set, or null
         */
        public abstract Stream InputStream();

        /**
         * Does this keyval have an input stream?
         * @return true if this keyval does indeed have an input stream
         */
        public abstract bool HasInputStream();
    }
}
