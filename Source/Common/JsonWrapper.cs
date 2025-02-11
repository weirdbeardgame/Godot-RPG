using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

public class JsonWrapper
{
    private string _jsonData;

    public bool Write<T>(string path, T data)
    {
        _jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

        if (string.IsNullOrWhiteSpace(_jsonData))
        {
            GD.PrintErr("JSON Serialization Failed!");
            return false;
        }

        using var file = FileAccess.Open(path, FileAccess.ModeFlags.Write);
        file.StoreString(_jsonData);

        var assembly = typeof(JsonSerializerOptions).Assembly;
        var updateHandlerType = assembly.GetType("System.Text.Json.JsonSerializerOptionsUpdateHandler");
        var clearCacheMethod = updateHandlerType?.GetMethod("ClearCache", BindingFlags.Static | BindingFlags.Public);
        clearCacheMethod?.Invoke(null, new object?[] { null });

        return true;
    }

    public bool Read<T>(string path, ref T data)
    {
        if (FileAccess.FileExists(path))
        {
            using var file = FileAccess.Open(path, FileAccess.ModeFlags.Read);
            _jsonData = file.GetAsText();
            data = JsonSerializer.Deserialize<T>(_jsonData);

            if (data == null)
            {
                GD.PrintErr("Failed to Read!");
                return false;
            }
            var assembly = typeof(JsonSerializerOptions).Assembly;
            var updateHandlerType = assembly.GetType("System.Text.Json.JsonSerializerOptionsUpdateHandler");
            var clearCacheMethod = updateHandlerType?.GetMethod("ClearCache", BindingFlags.Static | BindingFlags.Public);
            clearCacheMethod?.Invoke(null, new object?[] { null });
            return true;
        }


        return false;
    }
}

public class PackedSceneJsonConverter : JsonConverter<PackedScene>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(PackedScene);
    }

    public override PackedScene Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        PackedScene packed;

        while (reader.TokenType != JsonTokenType.String)
        {
            reader.Read();
        }

        var path = reader.GetString();
        packed = ResourceLoader.Load<PackedScene>(path);

        var assembly = typeof(JsonSerializerOptions).Assembly;
        var updateHandlerType = assembly.GetType("System.Text.Json.JsonSerializerOptionsUpdateHandler");
        var clearCacheMethod = updateHandlerType?.GetMethod("ClearCache", BindingFlags.Static | BindingFlags.Public);
        clearCacheMethod?.Invoke(null, new object?[] { null });
        return packed!;
    }

    public override void Write(Utf8JsonWriter writer, PackedScene value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.ResourcePath, options);
        var assembly = typeof(JsonSerializerOptions).Assembly;
        var updateHandlerType = assembly.GetType("System.Text.Json.JsonSerializerOptionsUpdateHandler");
        var clearCacheMethod = updateHandlerType?.GetMethod("ClearCache", BindingFlags.Static | BindingFlags.Public);
        clearCacheMethod?.Invoke(null, new object?[] { null });
    }
}

public class DictionaryPackedSceneJsonConverter : JsonConverter<Dictionary<string, PackedScene>>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(Dictionary<string, PackedScene>);
    }

    public override Dictionary<string, PackedScene> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var data = new Dictionary<string, PackedScene>();
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                return data;
            }

            var name = reader.GetString();

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new JsonException("NO SCENE MANAGER DATA");
            }

            reader.Read();

            var packed = ResourceLoader.Load<PackedScene>(reader.GetString());
            data.Add(name!, packed);
        }
        var assembly = typeof(JsonSerializerOptions).Assembly;
        var updateHandlerType = assembly.GetType("System.Text.Json.JsonSerializerOptionsUpdateHandler");
        var clearCacheMethod = updateHandlerType?.GetMethod("ClearCache", BindingFlags.Static | BindingFlags.Public);
        clearCacheMethod?.Invoke(null, new object?[] { null });
        return data;
    }

    public override void Write(Utf8JsonWriter writer, Dictionary<string, PackedScene> value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
        }
        else
        {
            writer.WriteStartObject();
            foreach (var item in value)
            {
                writer.WritePropertyName(item.Key);
                JsonSerializer.Serialize(writer, item.Value.ResourcePath, options);
            }
            writer.WriteEndObject();
        }

        var assembly = typeof(JsonSerializerOptions).Assembly;
        var updateHandlerType = assembly.GetType("System.Text.Json.JsonSerializerOptionsUpdateHandler");
        var clearCacheMethod = updateHandlerType?.GetMethod("ClearCache", BindingFlags.Static | BindingFlags.Public);
        clearCacheMethod?.Invoke(null, new object?[] { null });
    }
}


public class DictionaryStatJsonConverter : JsonConverter<Dictionary<string, StatData>>
{

    private readonly JsonConverter<StatData> _statConverter;

    public DictionaryStatJsonConverter(JsonSerializerOptions options)
    {
        _statConverter = (JsonConverter<StatData>)options.GetConverter(typeof(Dictionary<string, StatData>));
    }

    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(Dictionary<string, StatData>);
    }

    public override Dictionary<string, StatData> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var data = new Dictionary<string, StatData>();
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                return data;
            }

            var name = reader.GetString();

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new JsonException("NO SCENE MANAGER DATA");
            }

            reader.Read();

            var StatData = _statConverter.Read(ref reader, typeToConvert, options);
            data.Add(name, StatData);
        }
        var assembly = typeof(JsonSerializerOptions).Assembly;
        var updateHandlerType = assembly.GetType("System.Text.Json.JsonSerializerOptionsUpdateHandler");
        var clearCacheMethod = updateHandlerType?.GetMethod("ClearCache", BindingFlags.Static | BindingFlags.Public);
        clearCacheMethod?.Invoke(null, new object?[] { null });
        return data;
    }

    public override void Write(Utf8JsonWriter writer, Dictionary<string, StatData> value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
        }
        else
        {
            writer.WriteStartObject();
            foreach (var item in value)
            {
                writer.WritePropertyName(item.Key);
                JsonSerializer.Serialize(writer, item.Value, options);
            }
            writer.WriteEndObject();
        }
        var assembly = typeof(JsonSerializerOptions).Assembly;
        var updateHandlerType = assembly.GetType("System.Text.Json.JsonSerializerOptionsUpdateHandler");
        var clearCacheMethod = updateHandlerType?.GetMethod("ClearCache", BindingFlags.Static | BindingFlags.Public);
        clearCacheMethod?.Invoke(null, new object?[] { null });
    }
}

