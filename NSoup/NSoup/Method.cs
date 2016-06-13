using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoup
{
    public enum Method
    {
        GET, POST, PUT, DELETE, PATCH
    }
    public static class MethodExtensions
    {
        public static bool HasBody(this Method method)
        {
            switch (method)
            {
                case Method.DELETE: return false;
                case Method.GET: return false;
                case Method.PATCH: return true;
                case Method.POST: return true;
                case Method.PUT: return true;
                default: return false;
            }
        }
    }
}
