﻿namespace Chapter11_LINQ.Model
{
    public static class StaticCounter
    {
        static int next = 1;

        public static int Next()
        {
            return next++;
        }
    }
}
