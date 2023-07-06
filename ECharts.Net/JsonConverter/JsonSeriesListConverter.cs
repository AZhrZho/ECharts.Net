namespace ECharts.Net.JsonConverter;

internal class JsonSeriesListConverter : JsonConverter<IList<Series>>
{
    public override IList<Series>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new JsonException("not support deserialization of Series list.");
    }

    public override void Write(Utf8JsonWriter writer, IList<Series> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        foreach (var item in value)
        {
            var type = item.GetType();
            var converter = options.GetConverter(type);
            var writeMethod = converter.GetType().GetMethod("Write", new Type[] { typeof(Utf8JsonWriter), type, typeof(JsonSerializerOptions) });
            writeMethod?.Invoke(converter, new object[] { writer, item, options });
        }
        writer.WriteEndArray();
    }
}
