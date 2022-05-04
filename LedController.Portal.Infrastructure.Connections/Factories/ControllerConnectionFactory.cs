using System;
using System.Linq;

using AutoMapper;

using LedController.WebPortal.Domain.Managers;
using LedController.WebPortal.Domain.Models;
using LedController.WebPortal.Infrastructure.Connections.Connections;

using Microsoft.Extensions.Logging;



namespace LedController.WebPortal.Infrastructure.Connections.Factories;

internal class ControllerConnectionFactory
{
	private readonly ILoggerFactory _loggerFactory;
	private readonly IEffectManager _effectManager;
	private readonly ILedstripManager _ledstripManager;
	private readonly IAnimationManager _animationManager;
	private readonly ISpiBusManager _spiBusManager;
	private readonly IMapper _mapper;


	public ControllerConnectionFactory(ILoggerFactory loggerFactory,
									   IEffectManager effectManager,
									   ILedstripManager ledstripManager,
									   IAnimationManager animationManager,
									   ISpiBusManager spiBusManager,
									   IMapper mapper)
	{
		_loggerFactory = loggerFactory;
		_effectManager = effectManager;
		_ledstripManager = ledstripManager;
		_animationManager = animationManager;
		_spiBusManager = spiBusManager;
		_mapper = mapper;
	}


	/// <summary>
	/// Creates a new GRPC connection with the controller.
	/// </summary>
	/// <param name="controller"> The controller that we want to create a connection with. </param>
	/// <returns> </returns>
	public virtual GrpcControllerConnection CreateGrpcConnection(Controller controller)
	{
		GrpcControllerConnection connection = new GrpcControllerConnection(_loggerFactory.CreateLogger<GrpcControllerConnection>(), _mapper, _loggerFactory, controller);

		return connection;
	}
}