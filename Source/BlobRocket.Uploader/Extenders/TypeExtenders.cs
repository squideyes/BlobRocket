﻿using System;

namespace BlobRocket.Uploader
{
    public static class TypeExtenders
    {
        public static bool IsNullableType(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }
    }
}
