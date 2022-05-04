using System;
using System.Linq;



namespace LedController.Communication.Attributes;

internal class MessageAttribute : Attribute
{
	public int Id { get; set; }


	public MessageAttribute() { }
}