using System;
using System.Collections.Generic;
using System.Text;

namespace RoverMotionControl
{
    public static class Ensrure
    {

        public static void EnsureNotNullOrWhiteSpace(this string target, string name)
        {
            if (string.IsNullOrWhiteSpace(target))
                throw new ArgumentNullException(name);
        }

        public static void EnsureNotNull<T>(this T target, string name)
        {
            if (target == null)
                throw new ArgumentNullException(name);
        }
    }
}
