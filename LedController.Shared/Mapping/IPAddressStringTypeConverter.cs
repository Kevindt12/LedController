using System;
using System.Linq;
using System.Net;

using AutoMapper;



namespace LedController.Shared.Mapping;

internal class IPAddressStringTypeConverter : ITypeConverter<string?, IPAddress?>, ITypeConverter<IPAddress?, string?>
{
    /// <inheritdoc />
    public IPAddress? Convert(string? source, IPAddress? destination, ResolutionContext context)
    {
        return source != null ? IPAddress.Parse(source) : null;
    }


    /// <inheritdoc />
    public string? Convert(IPAddress? source, string? destination, ResolutionContext context)
    {
        return source?.ToString() ?? null;
    }
}