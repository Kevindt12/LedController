using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using LedController.Core.Animations;
using LedController.Core.Effects;

using Microsoft.Extensions.Logging;



namespace LedController.Core.Managers;

public class AnimationManager : IAnimationManager
{
	private readonly ILogger<AnimationManager> _logger;
	private readonly ApplicationDbContext _context;


	public AnimationManager(ILogger<AnimationManager> logger, ApplicationDbContext context)
	{
		_logger = logger;
		_context = context;
	}


	/// <summary>
	/// Gets all the animations from the application.
	/// </summary>
	/// <returns> </returns>
	public async Task<IEnumerable<Animation>> GetAnimationsAsync(CancellationToken token = default)
	{
		_logger.LogTrace("Getting all the animations.");

		return (await _context.Animations.ToListAsync(token)).Select(ConvertFromEntity);
	}


	/// <summary>
	/// Gets a single animation by id.
	/// </summary>
	/// <param name="id"> </param>
	/// <returns> </returns>
	public async Task<Animation> GetAnimationById(string id, CancellationToken token = default)
	{
		_logger.LogTrace($"Getting a animation by id with id {id}.");

		return ConvertFromEntity(await _context.Animations.SingleAsync(e => e.Id == id, token));
	}


	/// <summary>
	/// Adds a single animation.
	/// </summary>
	/// <param name="animation"> </param>
	/// <returns> </returns>
	public async Task AddAnimation(Animation animation, CancellationToken token = default)
	{
		_logger.LogTrace($"Adding a new animation {animation.Id} with name {animation.Name}.");

		_context.Animations.Add(ConvertToEntity(animation));
		await _context.SaveChangesAsync(token);
	}


	/// <summary>
	/// Updates a animation.
	/// </summary>
	/// <param name="animation"> </param>
	/// <returns> </returns>
	public async Task UpdateAnimation(Animation animation, CancellationToken token = default)
	{
		_logger.LogTrace($"updating an animation {animation.Id} with name {animation.Name}.");

		_context.Animations.Update(ConvertToEntity(animation));
		await _context.SaveChangesAsync(token);
	}


	/// <summary>
	/// Removes a animation./
	/// </summary>
	/// <param name="animation"> </param>
	/// <returns> </returns>
	public async Task RemoveAnimation(Animation animation, CancellationToken token = default)
	{
		_logger.LogTrace($"Removing an animation {animation.Id} with name {animation.Name}.");

		_context.Animations.Remove(ConvertToEntity(animation));
		await _context.SaveChangesAsync(token);
	}


	/// <summary>
	/// Checks if a animation already exists in the database.
	/// </summary>
	/// <param name="animation"> </param>
	/// <returns> </returns>
	public Task<bool> DoesAnimationExist(Animation animation)
	{
		return _context.Animations.AnyAsync(x => x.Id == animation.Id);
	}


	protected virtual Animation ConvertFromEntity(AnimationEntity entity)
	{
		Animation animation = new Animation();

		animation.Id = entity.Id;
		animation.Name = entity.Name;
		animation.Frequency = entity.Frequency;
		animation.IsStatic = entity.IsStatic;

		animation.Effects = JsonSerializer.Deserialize<List<Effect>>(entity.EffectsJson);

		return animation;
	}


	protected virtual AnimationEntity ConvertToEntity(Animation animation)
	{
		AnimationEntity entity = new AnimationEntity();

		entity.Id = animation.Id;
		entity.Name = animation.Name;
		entity.Frequency = animation.Frequency;
		entity.IsStatic = animation.IsStatic;

		entity.EffectsJson = JsonSerializer.Serialize(animation.Effects);

		return entity;
	}
}