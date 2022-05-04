using System;
using System.Linq;

using AutoMapper;

using UnitsNet;



namespace LedController.Shared.Mapping;

internal class FrequencyTypeConverter : ITypeConverter<Frequency, double>, ITypeConverter<double, Frequency>
{
    /// <inheritdoc />
    public double Convert(Frequency source, double destination, ResolutionContext context)
    {
        return source.Hertz;
    }


    /// <inheritdoc />
    public Frequency Convert(double source, Frequency destination, ResolutionContext context)
    {
        return Frequency.FromHertz(source);
    }
}