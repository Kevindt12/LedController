using System;
using System.Linq;

using AutoMapper;

using Google.Protobuf.WellKnownTypes;

using Grpc.Core;

using LedController.Controller.Domain.Exceptions;
using LedController.Controller.Domain.Services;



namespace LedController.Controller.Service.Services;

public class ServerConnectionService : GrpcConnection.GrpcConnectionBase
{
    private readonly ILogger<ServerConnectionService> _logger;
    private readonly IMapper _mapper;
    private readonly IAnimationService _animationService;
    private readonly ILedstripService _ledstripService;
    private readonly IEffectService _effectService;


    public ServerConnectionService(ILogger<ServerConnectionService> logger,
                                   IMapper mapper,
                                   IAnimationService animationService,
                                   ILedstripService ledstripService,
                                   IEffectService effectService)
    {
        _logger = logger;
        _mapper = mapper;
        _animationService = animationService;
        _ledstripService = ledstripService;
        _effectService = effectService;
    }


    /// <inheritdoc />
    public override Task<Empty> Connect(Empty request, ServerCallContext context)
    {
        _logger.LogInformation($"Portal {context.Host} request to connect.");

        return Task.FromResult(new Empty());
    }


    /// <inheritdoc />
    public override Task<Empty> Disconnect(Empty request, ServerCallContext context)
    {
        _logger.LogInformation($"Portal {context.Host} request to disconnect.");

        return Task.FromResult(new Empty());
    }


    /// <inheritdoc />
    public override async Task GetPlayingLedstrips(Empty request, IServerStreamWriter<LedstripAnimationInfo> responseStream, ServerCallContext context)
    {
        _logger.LogInformation($"Portal {context.Host} request to get the playing animations.");

        foreach (KeyValuePair<LedController.Domain.Models.Ledstrip, LedController.Domain.Models.Animation> animations in _animationService.GetPlayingAnimations())
        {
            _logger.LogTrace($"Sending {animations.Value.Name} playing on ledstrip {animations.Key.Name} to {context.Host}.");

            await responseStream.WriteAsync(new LedstripAnimationInfo
            {
                AnimationId = animations.Value.Id.ToString(),
                LedstripId = animations.Key.Id.ToString()
            });
        }

        _logger.LogDebug($"Send info about playing animations to portal {context.Host}");
    }


    /// <inheritdoc />
    public override async Task<ResultMessage> PlayAnimationOnLedstrip(PlayAnimationOnLedstripMessage request, ServerCallContext context)
    {
        LedController.Domain.Models.Ledstrip ledstrip = _mapper.Map<LedController.Domain.Models.Ledstrip>(request.Ledstrip);
        LedController.Domain.Models.Animation animation = _mapper.Map<LedController.Domain.Models.Animation>(request.Animation);

        _logger.LogInformation($"Get request to play animation {animation.Name} on ledstrip {ledstrip.Name}.");

        // If the animation is already running send back that we can't start it.
        if (_animationService.IsAnimationPlayingOnLedstrip(ledstrip.Id))
        {
            _logger.LogWarning("There is already an animation playing on that ledstrip. So sending back that we can't start the animation.");

            return new ResultMessage
            {
                Success = false,
                ErrorMessage = "There is already an animation playing on that ledstrip."
            };
        }

        try
        {
            await _animationService.StartAnimationAsync(ledstrip, animation);
            _logger.LogInformation($"Animation started on {ledstrip.Name}.");

            // Sending that we have succeeded in starting the animation player.
            return new ResultMessage
            {
                Success = true
            };
        }
        catch (AnimationException animationException)
        {
            _logger.LogError(animationException, "There was a problem with the animation.");

            return ConvertExceptionToResultMessage(animationException);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "There was a problem playing a animation.");

            return ConvertExceptionToResultMessage(e);
        }
    }


    /// <inheritdoc />
    public override async Task<ResultMessage> StopAnimationOnLedstrip(LedstripInfo request, ServerCallContext context)
    {
        _logger.LogInformation($"Request to stop animation on ledstrip {request.LedstripId}.");

        try
        {
            await _animationService.StopAnimationAsync(new Guid(request.LedstripId));
            _logger.LogInformation("Animation has been stopped.");

            return new ResultMessage
            {
                Success = true
            };
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"There was a problem with stopping animation on ledstrip {request.LedstripId}");

            return ConvertExceptionToResultMessage(e);
        }
    }


    /// <inheritdoc />
    public override async Task<ResultMessage> TestLedstrip(Ledstrip request, ServerCallContext context)
    {
        LedController.Domain.Models.Ledstrip ledstrip = _mapper.Map<LedController.Domain.Models.Ledstrip>(request);
        _logger.LogInformation($"Request to Test animation on ledstrip {request.Id}.");

        // First stopping any animations that might be playing on that ledstrip.
        if (_animationService.IsAnimationPlayingOnLedstrip(new Guid(request.Id)))
        {
            _logger.LogTrace($"Stopping animation on ledstrip {ledstrip.Id} for test.");
            await _animationService.StopAnimationAsync(ledstrip.Id);
        }

        try
        {
            await _ledstripService.TestLedstripAsync(ledstrip);

            return new ResultMessage
            {
                Success = true
            };
        }
        catch (LedstripException ledstripException)
        {
            return ConvertExceptionToResultMessage(ledstripException);
        }
        catch (Exception e)
        {
            _logger.LogError($"There was a problem with the test on ledstrip {ledstrip.Id}.");

            return ConvertExceptionToResultMessage(e);
        }
    }


    /// <inheritdoc />
    public override async Task<ResultMessage> UploadEffectAssembly(EffectAssembly request, ServerCallContext context)
    {
        _logger.LogInformation($"Uploading effect {request.Id}.");

        LedController.Domain.Models.EffectAssembly effectAssembly = new LedController.Domain.Models.EffectAssembly
        {
            Id = new Guid(request.Id)
        };

        await _effectService.SaveEffectAssembly(request.Data.Memory, effectAssembly);
        _logger.LogInformation("Effect assembly has been saved.");

        return new ResultMessage
        {
            Success = true
        };
    }


    /// <summary>
    /// Converts an exception to result message to it can be send back what the problem was.
    /// </summary>
    /// <param name="exception"> The exception we want to serialize and send. </param>
    /// <returns> </returns>
    private ResultMessage ConvertExceptionToResultMessage(Exception exception)
    {
        return new ResultMessage
        {
            Success = false,
            ErrorMessage = exception.Message,
            StackTrace = exception.StackTrace
        };
    }
}