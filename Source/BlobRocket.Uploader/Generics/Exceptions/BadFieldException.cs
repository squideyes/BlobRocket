﻿using System;

namespace BlobRocket.Uploader.Generics
{
    public class BadFieldException : Exception
    {
        public BadFieldException(string fieldName) 
            : base(string.Format("The \"{0}\" field is invalid!", fieldName))
        {
            FieldName = fieldName;
        }

        public string FieldName { get; }
    }
}
