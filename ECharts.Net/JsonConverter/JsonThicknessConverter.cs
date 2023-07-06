namespace ECharts.Net.JsonConverter;

internal class JsonThicknessConverter : JsonConverter<Thickness>
{
    public override Thickness Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            var value = reader.GetDouble();
            return new Thickness(value);
        }
        var arrayReader = (JsonConverter<IList<double>>)options.GetConverter(typeof(IList<double>));
        var values = arrayReader.Read(ref reader, typeof(IList<double>), options);
        return values?.Count switch
        {
            2 => new Thickness(values[0], values[1]),
            4 => new Thickness(values[0], values[1], values[2], values[3]),
            _ => throw new JsonException()
        };
    }

    public override void Write(Utf8JsonWriter writer, Thickness value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        writer.WriteNumberValue(value.Top);
        writer.WriteNumberValue(value.Right);
        writer.WriteNumberValue(value.Bottom);
        writer.WriteNumberValue(value.Left);
        writer.WriteEndArray();
    }
}
