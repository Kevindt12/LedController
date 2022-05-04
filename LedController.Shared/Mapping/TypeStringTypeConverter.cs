using System;
using System.Linq;

using AutoMapper;



namespace LedController.Shared.Mapping;

internal class TypeStringTypeConverter : ITypeConverter<string?, Type?>, ITypeConverter<Type?, string?>
{
    /// <inheritdoc />
    public Type? Convert(string? source, Type? destination, ResolutionContext context)
    {
        return source != null ? Type.GetType(source) : null;
    }


    /// <inheritdoc />
    public string? Convert(Type? source, string? destination, ResolutionContext context)
    {
        return source?.FullName ?? null;
    }
}