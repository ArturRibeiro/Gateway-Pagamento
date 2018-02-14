﻿using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Integration.Tests
{
    public class FluentJsonContent : StringContent
    {
        public FluentJsonContent(object value)
            : base (JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json")
        {
        }

        public FluentJsonContent(object value, string mediaType)
            : base(JsonConvert.SerializeObject(value), Encoding.UTF8, mediaType)
        {
        }
    }
}
