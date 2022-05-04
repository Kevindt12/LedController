using System;
using System.Linq;
using System.Text.Json;

using AutoMapper;



namespace LedController.Shared.Mapping;

public class JsonStringObjectValueConverter : IValueConverter<string, object?>
{
	/// <inheritdoc />
	public object? Convert(string sourceMember, ResolutionContext context)
	{
		JsonTypedDto jsonTypedDto = JsonSerializer.Deserialize<JsonTypedDto>(sourceMember)!;

		string typeName = jsonTypedDto.TypeName;

		if (typeName == "NULL") return null;

		Type objectType = Type.GetType(typeName)!;

		object? deserializedObject = JsonSerializer.Deserialize(jsonTypedDto.Content, objectType)!;

		return deserializedObject;
	}
}



public class JsonObjectStringValueConverter : IValueConverter<object?, string>
{
	/// <inheritdoc />
	public string Convert(object? sourceMember, ResolutionContext context)
	{
		if (sourceMember == null)
		{
			return JsonSerializer.Serialize(new JsonTypedDto
			{
				Content = String.Empty,
				TypeName = "NULL"
			});
		}

		return JsonSerializer.Serialize(new JsonTypedDto
		{
			TypeName = sourceMember.GetType().FullName!,
			Content = JsonSerializer.Serialize(sourceMember)
		});
	}
}



internal class JsonTypedDto
{
	public string TypeName { get; init; } = default!;

	public string Content { get; init; } = default!;
}