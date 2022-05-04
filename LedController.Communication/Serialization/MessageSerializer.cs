using System;
using System.Linq;

using LedController.Communication.Messages;



namespace LedController.Communication.Serialization;

public class MessageSerializer
{
	public virtual ReadOnlySpan<byte> SerializeHardwareConfigurationRequest(UploadHardwareConfigurationRequest request) { }


	public virtual ReadOnlySpan<byte> SerializeUploadHardwareConfigurationResponse(UploadHardwareConfigurationResponse response) { }


	public virtual ReadOnlySpan<byte> SerializeDownloadHardwareConfigurationRequest(DownloadHardwareConfigurationRequest response) { }


	public virtual ReadOnlySpan<byte> SerializeDownloadHardwareConfigurationResponse(DownloadHardwareConfigurationResponse response) { }


	public virtual ReadOnlySpan<byte> SerializeUploadHardwareConfigurationResponse(UploadAnimationRequest response) { }


	public virtual ReadOnlySpan<byte> SerializeUploadHardwareConfigurationResponse(UploadAnimationResponse response) { }


	public virtual ReadOnlySpan<byte> SerializeUploadHardwareConfigurationResponse(UploadEffectDefinitionRequest response) { }


	public virtual ReadOnlySpan<byte> SerializeUploadHardwareConfigurationResponse(UploadEffectDefinitionResponse response) { }


	public virtual ReadOnlySpan<byte> SerializeUploadHardwareConfigurationResponse(GetAnimationInformationRequest response) { }


	public virtual ReadOnlySpan<byte> SerializeUploadHardwareConfigurationResponse(GetAnimationInformationResponse response) { }


	public virtual ReadOnlySpan<byte> SerializeUploadHardwareConfigurationResponse(GetEffectDefinitionInformationRequest response) { }


	public virtual ReadOnlySpan<byte> SerializeUploadHardwareConfigurationResponse(GetEffectDefinitionInformationResponse response) { }


	public virtual ReadOnlySpan<byte> SerializeUploadHardwareConfigurationResponse(PlayAnimationOnLedstripRequest response) { }


	public virtual ReadOnlySpan<byte> SerializeUploadHardwareConfigurationResponse(PlayAnimationOnLedstripResponse response) { }

	public virtual ReadOnlySpan<byte> SerializeUploadHardwareConfigurationResponse(StopAnimationOnLedstripRequest response) { }


	public virtual ReadOnlySpan<byte> SerializeUploadHardwareConfigurationResponse(StopAnimationOnLedstripResponse response) { }


	public virtual ReadOnlySpan<byte> SerializeUploadHardwareConfigurationResponse(TestLedstripRequest response) { }


	public virtual ReadOnlySpan<byte> SerializeUploadHardwareConfigurationResponse(TestLedstripResponse response) { }
}