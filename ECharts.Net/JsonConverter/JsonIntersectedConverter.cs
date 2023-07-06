using ECharts.Net.Util;

namespace ECharts.Net.JsonConverter;

internal class JsonIntersectedConverter : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        if (!typeToConvert.IsGenericType)
        {
            return false;
        }
        if (typeToConvert.GetGenericTypeDefinition() != typeof(Intersected<,>) && 
            typeToConvert.GetGenericTypeDefinition() != typeof(Intersected<,,>))
        {
            return false;
        }
        return true;
    }

    public override System.Text.Json.Serialization.JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var converterType = typeToConvert.GetGenericArguments().Length switch
        {
            2 => typeof(InternalJsonIntersectedConverter<,>),
            3 => typeof(InternalJsonIntersectedConverter<,,>),
            _ => throw new NotSupportedException(),
        };
        return CreateInternalJsonIntersectedConverter(typeToConvert, converterType);
    }

    private static System.Text.Json.Serialization.JsonConverter CreateInternalJsonIntersectedConverter(Type type, Type converterType)
    {
        var converter = (System.Text.Json.Serialization.JsonConverter?)Activator.CreateInstance(
            converterType.MakeGenericType(type.GetGenericArguments()), Array.Empty<object>());
        return converter!;
    }

    internal class InternalJsonIntersectedConverter<T1, T2> : JsonConverter<Intersected<T1, T2>>
    {
        public override Intersected<T1, T2> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException("not support deserialize for Intersected type.");
        }

        public override void Write(Utf8JsonWriter writer, Intersected<T1, T2> value, JsonSerializerOptions options)
        {
            var writingValue = value.Value;
            switch (writingValue)
            {
                case null:
                    writer.WriteNullValue();
                    break;
                default:
                    var converter = options.GetConverter(writingValue.GetType());
                    var type = converter.GetType();
                    var writeMethod = type.GetMethod("Write", new Type[] { typeof(Utf8JsonWriter), writingValue.GetType(), typeof(JsonSerializerOptions) });
                    writeMethod?.Invoke(converter, new object[] { writer, writingValue, options });
                    break;
            }
        }
    }

    internal class InternalJsonIntersectedConverter<T1, T2, T3> : JsonConverter<Intersected<T1, T2, T3>>
    {
        public override Intersected<T1, T2, T3> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException("not support deserialize for Intersected type.");
        }

        public override void Write(Utf8JsonWriter writer, Intersected<T1, T2, T3> value, JsonSerializerOptions options)
        {
            var writingValue = value.Value;
            switch (writingValue)
            {
                case null:
                    writer.WriteNullValue();
                    break;
                default:
                    var converter = options.GetConverter(writingValue.GetType());
                    var type = converter.GetType();
                    var writeMethod = type.GetMethod("Write", new Type[] { typeof(Utf8JsonWriter), writingValue.GetType(), typeof(JsonSerializerOptions) });
                    writeMethod?.Invoke(converter, new object[] { writer, writingValue, options });
                    break;
            }
        }
    }
}
