using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Net.Http.Headers;
using System.IO;
using System.Net.Http;

namespace Aaron.MVC.Formatters
{
    public class PlainTextMediaTypeFormatter : BufferedMediaTypeFormatter
    {
        public PlainTextMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(string);
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            using (var writer = new StreamWriter(writeStream))
            {
                writer.Write((string)value);
            }
        }
    }
}