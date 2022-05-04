using System;
using System.Linq;

using AutoMapper;

using LedController.Domain.Models;
using LedController.Shared.Mapping;
using LedController.WebPortal.Infrastructure.Connections.Protos;

using Animation = LedController.Domain.Models.Animation;
using AnimationEffect = LedController.Domain.Models.AnimationEffect;
using Effect = LedController.Domain.Models.Effect;
using Ledstrip = LedController.Domain.Models.Ledstrip;
using SpiBus = LedController.Domain.Models.SpiBus;
using SpiBusSettings = LedController.Domain.Models.SpiBusSettings;



namespace LedController.WebPortal.Infrastructure.Connections.Profiles;

public class ProtoProfile : Profile
{
	public ProtoProfile()
	{
		CreateMap<SpiBusSettings, Protos.SpiBusSettings>();

		CreateMap<SpiBus, Protos.SpiBus>()
		   .ForMember(src => src.SpiBusSettings, opt => opt.MapFrom(dest => dest.Settings));

		CreateMap<Ledstrip, Protos.Ledstrip>();

		CreateMap<Animation, Protos.Animation>();
		CreateMap<AnimationEffect, Protos.AnimationEffect>();

		CreateMap<AnimationEffectParameterValue, AnimationEffectParameter>()
		   .ForMember(dest => dest.Value, opt => opt.ConvertUsing(new JsonObjectStringValueConverter(), src => src.Value))
		   .ForMember(dest => dest.PropertyName, opt => opt.MapFrom(src => src.Name));

		CreateMap<Effect, Protos.Effect>()
		   .ForMember(dest => dest.EffectAssemblyId, opt => opt.MapFrom(src => src.EffectAssembly!.Id));

		CreateMap<TimeSpan, long>().ConvertUsing(x => x.Ticks);
	}
}