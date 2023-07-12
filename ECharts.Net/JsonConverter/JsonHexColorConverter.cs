namespace ECharts.Net.JsonConverter;

internal class JsonHexColorConverter : JsonConverter<EChartsColor>
{
    public override EChartsColor Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, EChartsColor value, JsonSerializerOptions options)
    {
        if (value is SolidColor color) 
        { 
            writer.WriteStringValue($"#{color.ToArgb():X6}");
        }
        else
        {
            var type = value.GetType();
            var converter = options.GetConverter(type);
            var writeMethod = converter.GetType().GetMethod("Write", new Type[] { typeof(Utf8JsonWriter), type, typeof(JsonSerializerOptions) });
            writeMethod?.Invoke(converter, new object[] { writer, value, options });
        }
    }
}

internal class JsonHexSolidColorConverter : JsonConverter<SolidColor>
{
    public override SolidColor Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, SolidColor value, JsonSerializerOptions options)
    {
        writer.WriteStringValue($"#{value.ToArgb():X6}");
    }
}
