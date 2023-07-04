﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace ECharts.Net;

public class EChartInstance
{
    public EChartInstance(IWebViewProxy webView, string instanceName = "chart")
    {
        this.webView = webView;
        this.instanceName = instanceName;
    }

    private readonly IWebViewProxy webView;
    private readonly string instanceName;

    public void SetOption(Option option) 
    {
        SetOption(JsonSerializer.Serialize(option, SerializerOptions));
    }

    public void SetOption(dynamic option)
    {
        SetOption(JsonSerializer.Serialize(option, SerializerOptions));
    }

    public void SetOption(string optionInJson) 
    {
        webView.InvokeScriptAsync($"{instanceName}.setOption({optionInJson})");
    }

    private static JsonSerializerOptions SerializerOptions { get; }
    static EChartInstance()
    {
        SerializerOptions = new JsonSerializerOptions();
        var enumConverter = new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, false);
        SerializerOptions.Converters.Add(enumConverter);
        SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    }
}
