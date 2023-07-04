namespace ECharts.Net.JsonConverter;

internal class JsonFontWeightConverter : JsonConverter<FontWeight>
{
    public override FontWeight? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.Number) return FontWeight.Normal;
        return reader.GetInt32();
    }

    public override void Write(Utf8JsonWriter writer, FontWeight value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.Value);
    }
}
