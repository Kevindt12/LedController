using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using LedController.Core.Animations;



namespace LedController.Core.Managers
{
	public interface IAnimationManager
	{



		/// <summary>
		/// Gets all the animations from the application.
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<Animation>> GetAnimationsAsync(CancellationToken token = default);

		/// <summary>
		/// Gets a single animation by id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Animation> GetAnimationById(string id, CancellationToken token = default);

		/// <summary>
		/// Adds a single animation.
		/// </summary>
		/// <param name="animation"></param>
		/// <returns></returns>
		Task AddAnimation(Animation animation, CancellationToken token = default);

		/// <summary>
		/// Updates a animation.
		/// </summary>
		/// <param name="animation"></param>
		/// <returns></returns>
		Task UpdateAnimation(Animation animation, CancellationToken token = default);

		/// <summary>
		/// Removes a animation./
		/// </summary>
		/// <param name="animation"></param>
		/// <returns></returns>
		Task RemoveAnimation(Animation animation, CancellationToken token = default);


		/// <summary>
		/// Checks if a animation already exists in the database.
		/// </summary>
		/// <param name="animation"></param>
		/// <returns></returns>
		Task<bool> DoesAnimationExist(Animation animation);


	}
}
