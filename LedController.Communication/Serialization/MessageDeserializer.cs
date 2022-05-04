using System;
using System.Linq;

using LedController.Communication.Messages;



namespace LedController.Communication.Serialization;

public class MessageDeserializer
{
	public virtual UploadHardwareConfigurationRequest deserializeHardwareConfigurationRequest(ReadOnlySpan<byte> messsage) { }


	public virtual UploadHardwareConfigurationResponse deserializeHardwareConfigurationRequest(ReadOnlySpan<byte> messsage) { }


	public virtual DownloadHardwareConfigurationRequest deserializeHardwareConfigurationRequest(ReadOnlySpan<byte> messsage) { }


	public virtual DownloadHardwareConfigurationReponse deserializeHardwareConfigurationRequest(ReadOnlySpan<byte> messsage) { }


	public virtual UploadAnimationRequest deserializeHardwareConfigurationRequest(ReadOnlySpan<byte> messsage) { }


	public virtual UploadAnimationResponse deserializeHardwareConfigurationRequest(ReadOnlySpan<byte> messsage) { }


	public virtual UploadEffectDefinitionRequest deserializeHardwareConfigurationRequest(ReadOnlySpan<byte> messsage) { }


	public virtual UploadEffectDefinitionResponse deserializeHardwareConfigurationRequest(ReadOnlySpan<byte> messsage) { }


	public virtual GetAnimationInformationRequest deserializeHardwareConfigurationRequest(ReadOnlySpan<byte> messsage) { }


	public virtual GetAnimationInformationResponse deserializeHardwareConfigurationRequest(ReadOnlySpan<byte> messsage) { }


	public virtual GetEffectDefinitionInformationRequest deserializeHardwareConfigurationRequest(ReadOnlySpan<byte> messsage) { }


	public virtual GetEffectDefinitionInformationResponse deserializeHardwareConfigurationRequest(ReadOnlySpan<byte> messsage) { }


	public virtual PlayAnimationOnLedstripRequest deserializeHardwareConfigurationRequest(ReadOnlySpan<byte> messsage) { }


	public virtual PlayAnimationOnLedstripResponse deserializeHardwareConfigurationRequest(ReadOnlySpan<byte> messsage) { }


	public virtual StopAnimationOnLedstripRequest deserializeHardwareConfigurationRequest(ReadOnlySpan<byte> messsage) { }


	public virtual StopAnimationOnLedstripResponse deserializeHardwareConfigurationRequest(ReadOnlySpan<byte> messsage) { }


	public virtual UploadHardwareConfigurationRequest deserializeHardwareConfigurationRequest(ReadOnlySpan<byte> messsage) { }


	public virtual UploadHardwareConfigurationRequest deserializeHardwareConfigurationRequest(ReadOnlySpan<byte> messsage) { }
}