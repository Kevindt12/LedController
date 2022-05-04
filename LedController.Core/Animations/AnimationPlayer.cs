using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using LedController.Core.Effects;
using LedController.Core.Ledstrips;
using LedController.Core.Services;
using LedController.Domain.Models;

using Microsoft.Extensions.Logging;



namespace LedController.Core.Animations
{
	public class AnimationPlayer
	{
		private readonly ILogger<AnimationPlayer> _logger;

		private readonly ILedstripConnection _ledstripConnection;


		private CancellationTokenSource _cts;

		private Task _playingTask;


		/// <summary>
		/// The Id of the animation player.
		/// </summary>
		public string Id { get; }

		/// <summary>
		/// A flag indicating if the player is running. 
		/// </summary>
		public bool IsRunning { get; protected set; }

		/// <summary>
		/// The led strip that we are using to play the animation.
		/// </summary>
		public Ledstrip LedStrip { get; }

		/// <summary>
		/// The animation we want to play.
		/// </summary>
		public Animation Animation { get; }


		/// <summary>
		/// The animation player that is used to play a animation of effects
		/// </summary>
		/// <param name="logger"></param>
		/// <param name="animation"></param>
		/// <param name="ledstripConnection"></param>
		public AnimationPlayer(ILogger<AnimationPlayer> logger, Animation animation, ILedstripConnection ledstripConnection)
		{
			Id = Guid.NewGuid().ToString();

			_logger = logger;
			_ledstripConnection = ledstripConnection;
			Animation = animation;
			LedStrip = ledstripConnection.Ledstrip;
		}

		/// <summary>
		/// Start the animation player.
		/// </summary>
		/// <returns></returns>
		public async Task StartAsync()
		{
			// Checkinf if we are already running.
			if (IsRunning) return;

			// Creating a connection for the current led strip.
			_logger.LogDebug($"Starting animation player for {Id} with led strip {LedStrip.Id}.");

			// Checkinf if we need to loop true the animation or if the animation is static.
			if (Animation.IsStatic)
			{
				_logger.LogDebug($"IsStatic animation only showing one frame on the led strip.");

				// Checking if we have a color array to be set.
				if (Animation.Effects.First()?.MoveNext() ?? false)
				{
					_ledstripConnection.Write(Animation.Effects?.First().Current);

					return;
				}
			}

			// Creating a new cancallation token source to be used in the loop; starting a new task that plays the animation.
			_cts = new CancellationTokenSource();
			_playingTask = Task.Factory.StartNew(() => AnimationLoop(Animation, _ledstripConnection, false, _cts.Token), TaskCreationOptions.LongRunning);

			IsRunning = true;
		}


		protected virtual async Task AnimationLoop(Animation animation, ILedstripConnection connection, bool endAtLastLoop, CancellationToken token)
		{
			IEnumerable<Effect> effects = animation.Effects;

			while (!token.IsCancellationRequested)
			{


				foreach (Effect effect in effects)
				{
					while (effect.MoveNext())
					{
						token.ThrowIfCancellationRequested();

						connection.Write(effect.Current);

						await Task.Delay(TimeSpan.FromMilliseconds(HertzToMs(animation.Frequency)), token);
					}

				}

				if (endAtLastLoop)
				{
					break;
				}
			}
		}



		/// <summary>
		/// Converts hertz to ms
		/// </summary>
		/// <param name="hertz"></param>
		/// <returns></returns>
		protected virtual double HertzToMs(int hertz)
		{
			return 1 / hertz * 1000;
		}

		/// <summary>
		/// Stop the animation player.
		/// </summary>
		/// <returns></returns>
		public async Task StopAsync()
		{
			if (!IsRunning) return;

			_logger.LogTrace($"Stopping animation player for {Id}.");

			// If static just clear the led strip.
			if (Animation.IsStatic)
			{
				_ledstripConnection.Clear();
				return;
			}

			// Stopping thel loop and waiting to sync back to the current context.
			_cts.Cancel();
			await _playingTask;


			// Clearing the led strip connection; then disposing of it.
			_logger.LogTrace($"Disconnecting the led strip player for animation player {Id}.");
			_ledstripConnection.Clear();
		}

	}
}
