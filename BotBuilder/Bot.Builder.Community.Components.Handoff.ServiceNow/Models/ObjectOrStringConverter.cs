﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.Builder.Community.Components.Handoff.ServiceNow.Models
{
    public class ObjectOrStringConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            // CanConvert is not called when the [JsonConverter] attribute is used
            return false;
        }



        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Object)
            {
                return token.ToObject<T>(serializer);
            }
            return token.ToString();
        }


        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
