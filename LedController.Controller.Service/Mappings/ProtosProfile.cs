using System;
using System.Linq;

using AutoMapper;

using LedController.Domain.Models;
using LedController.Shared.Mapping;



namespace LedController.Controller.Service.Mappings;

public class ProtosProfile : Profile
{
	public ProtosProfile()
	{
		CreateMap<SpiBusSettings, LedController.Domain.Models.SpiBusSettings>();

		CreateMap<SpiBus, LedController.Domain.Models.SpiBus>()
		   .ForMember(dest => dest.Settings, opt => opt.MapFrom(src => src.SpiBusSettings));

		CreateMap<Ledstrip, LedController.Domain.Models.Ledstrip>();

		CreateMap<Animation, LedController.Domain.Models.Animation>();
		CreateMap<AnimationEffect, LedController.Domain.Models.AnimationEffect>();

		CreateMap<AnimationEffectParameter, AnimationEffectParameterValue>()
		   .ForMember(dest => dest.Value, opt => opt.ConvertUsing(new JsonStringObjectValueConverter(), src => src.Value))
		   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.PropertyName));

		CreateMap<Effect, LedController.Domain.Models.Effect>()
		   .ForMember(dest => dest.EffectAssembly,
					  opt => opt.MapFrom(src => new LedController.Domain.Models.EffectAssembly
					  {
						  Id = new Guid(src.EffectAssemblyId)
					  }));
	}
}