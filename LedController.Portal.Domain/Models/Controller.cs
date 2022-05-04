using System;
using System.Linq;
using System.Net;

using LedController.Domain.Models;



namespace LedController.WebPortal.Domain.Models;

public class Controller : IEquatable<Controller>
{
	/// <summary>
	/// The if of the controller.
	/// </summary>
	public Guid Id { get; init; }

	/// <summary>
	/// The name of the controller.
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// The ip end point of the controller.
	/// </summary>
	public IPEndPoint EndPoint { get; set; }


	/// <summary>
	/// The spi buses that are available on that controller..
	/// </summary>
	public ICollection<SpiBus> SpiBuses { get; set; }


	/// <summary>
	/// The led strips that we have attached to that controller.
	/// </summary>
	public ICollection<Ledstrip> Ledstrips { get; set; }


	/// <summary>
	/// The effects that are synced with the controller.
	/// </summary>
	public ICollection<Effect> SynchronizedEffects { get; set; }


	/// <summary>
	/// The controller aggrigate root model for the controller that we can connect to.
	/// </summary>
	public Controller()
	{
		Name = $"Controller {Random.Shared.Next()}";
		EndPoint = new IPEndPoint(IPAddress.Loopback, 4423);
		SpiBuses = new List<SpiBus>();
		Ledstrips = new List<Ledstrip>();
		SynchronizedEffects = new List<Effect>();
	}


	/// <inheritdoc />
	public bool Equals(Controller other)
	{
		if (ReferenceEquals(null, other)) return false;
		if (ReferenceEquals(this, other)) return true;

		return Id == other.Id;
	}


	/// <inheritdoc />
	public override bool Equals(object obj)
	{
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != GetType()) return false;

		return Equals((Controller)obj);
	}


	/// <inheritdoc />
	public override int GetHashCode()
	{
		return Id != null ? Id.GetHashCode() : 0;
	}


	public static bool operator ==(Controller left, Controller right)
	{
		return Equals(left, right);
	}


	public static bool operator !=(Controller left, Controller right)
	{
		return !Equals(left, right);
	}


	/// <inheritdoc />
	public override string ToString()
	{
		return Name;
	}
}