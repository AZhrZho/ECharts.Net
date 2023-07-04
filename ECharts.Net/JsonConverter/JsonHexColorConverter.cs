namespace ECharts.Net.JsonConverter;

internal class JsonHexColorConverter : JsonConverter<Color>
{
    public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var hexColorString = Encoding.UTF8.GetString(reader.ValueSpan[1..]);
        var intColor = int.Parse(hexColorString, System.Globalization.NumberStyles.HexNumber);
        return Color.FromArgb(intColor);
    }

    public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
    {
        writer.WriteStringValue($"#{value.ToArgb():X}");
    }
}
