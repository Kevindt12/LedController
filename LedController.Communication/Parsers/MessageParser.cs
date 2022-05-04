using System;
using System.Linq;

using LedController.Domain.Configuration;



namespace LedController.Communication.Parsers;

public class MessageParser
{




	public MessageParser()
	{
		
	}


	public virtual ReadOnlySpan<byte> SerializeUploadHardwareConfigurationRequest(HardwareConfiguration hardwareConfiguration)
	{

	}


	public virtual bool DeserializeUploadHardwareConfigurationRequest(ReadOnlySpan<byte> message)
	{


	}



	public virtual ReadOnlySpan<byte> DownloadHardwareConfiguration()

}