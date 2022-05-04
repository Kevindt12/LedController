using System;
using System.Linq;

using LedController.Domain.Models;
using LedController.WebPortal.Domain.Models;



namespace LedController.WebPortal.Domain.Services;

/// <summary>
/// The controller service that handles things with the connection and the controller its self.
/// </summary>
public interface IControllerService
{
	/// <summary>
	/// Gets if the controller is connected.
	/// </summary>
	/// <param name="controller"> The controller that we want to check that is connected. </param>
	/// <returns> a flag indicating that we are connected. </returns>
	bool IsControllerConnected(Controller controller);


	/// <summary>
	/// Gets the playing animation on a ledstrip. If there is no animation playing it will give default.
	/// </summary>
	/// <param name="ledstrip"> </param>
	/// <returns> </returns>
	Animation? GetPlayingAnimationOnLedstripOrDefault(Ledstrip ledstrip);


	/// <summary>
	/// Connects to the controller.
	/// </summary>
	/// <param name="controller"> </param>
	/// <returns> </returns>
	Task ConnectToControllerAsync(Controller controller, CancellationToken token = default);


	/// <summary>
	/// Synchronizes a effect with the controller.
	/// </summary>
	/// <param name="controller"> The controller we want to use. </param>
	/// <param name="effect"> The effect we want to synchronize with </param>
	/// <returns> </returns>
	Task SynchronizeEffect(Controller controller, Effect effect, CancellationToken token = default);


	/// <summary>
	/// Plays a animation on a ledstrip.
	/// </summary>
	/// <param name="ledstrip"> The ledstrip we want to play the animation on. </param>
	/// <param name="animation"> The animation that we want to play. </param>
	/// <returns> </returns>
	Task PlayAnimationOnLedstrip(Ledstrip ledstrip, Animation animation, CancellationToken token = default);


	/// <summary>
	/// Requests the controller to stop playing a animation on a ledstrip.
	/// </summary>
	/// <param name="ledstrip"> The ledstrip that we want to stop the animation. </param>
	/// <returns> </returns>
	Task StopAnimationOnLedstrip(Ledstrip ledstrip, CancellationToken token = default);


	/// <summary>
	/// Tests a ledstrip on a controller.
	/// </summary>
	/// <param name="ledstrip"> The ledstrip that we want to test. </param>
	/// <param name="token"> A token to stop the current operation. </param>
	/// <returns> </returns>
	Task TestLedstripAsync(Ledstrip ledstrip, CancellationToken token = default);


	/// <summary>
	/// Disconnects controller from application.
	/// </summary>
	/// <param name="controller"> The controller that we want to disconnect. </param>
	/// <param name="token"> </param>
	/// <returns> </returns>
	Task DisconnectAsync(Controller controller, CancellationToken token = default);
}