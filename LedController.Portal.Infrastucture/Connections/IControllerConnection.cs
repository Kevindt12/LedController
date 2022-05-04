using System;
using System.Linq;

using LedController.Domain.Models;
using LedController.WebPortal.Domain.Models;



namespace LedController.WebPortal.Infrastructure.Connections;

/// <summary>
/// The connection with a controller.
/// </summary>
public interface IControllerConnection : IDisposable, IAsyncDisposable
{
	/// <summary>
	/// The controller that we are connect to.
	/// </summary>
	Controller Controller { get; }


	/// <summary>
	/// Connects to the controller.
	/// </summary>
	/// <returns> </returns>
	Task ConnectAsync();


	/// <summary>
	/// Requests the controller to play the animation.
	/// </summary>
	/// <param name="ledstrip"> The led strip we want to play it on. </param>
	/// <param name="animation"> The animation that we want to play. </param>
	/// <param name="token"> A token to stop the current operation. </param>
	/// <returns> </returns>
	Task PlayAsync(Ledstrip ledstrip, Animation animation, CancellationToken token = default);


	/// <summary>
	/// Requests to stop playing animation.
	/// </summary>
	/// <param name="ledstrip"> The ledstrip that we want to stop playing. </param>
	/// <param name="token"> A token to stop the current operation. </param>
	/// <returns> </returns>
	Task StopAsync(Ledstrip ledstrip, CancellationToken token = default);


	/// <summary>
	/// Requests to test the ledstrip.
	/// </summary>
	/// <param name="ledstrip"> The ledstrip we want to test. </param>
	/// <param name="token"> A token to stop the current operation. </param>
	/// <returns> </returns>
	Task TestAsync(Ledstrip ledstrip, CancellationToken token = default);


	/// <summary>
	/// Uploads a effect assembly to the controller.
	/// </summary>
	/// <summary>
	/// WE are not using stream because memory wise this is not so heavy. we are talking about 5 -100KV assemblies/
	/// </summary>
	/// <param name="assembly"> The assembly meta data that we want to send. </param>
	/// <param name="file"> The file that we ant to send. </param>
	/// <param name="token"> A token to stop the current operation. </param>
	/// <returns> </returns>
	Task UploadEffectAssemblyAsync(EffectAssembly assembly, ReadOnlyMemory<byte> file, CancellationToken token = default);
}