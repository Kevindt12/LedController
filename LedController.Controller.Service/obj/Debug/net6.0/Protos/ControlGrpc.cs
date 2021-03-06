// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/Control.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace LedController.Controller.Service {
  public static partial class GrpcConnection
  {
    static readonly string __ServiceName = "connection.GrpcConnection";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Protobuf.WellKnownTypes.Empty.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::LedController.Controller.Service.PlayAnimationOnLedstripMessage> __Marshaller_connection_PlayAnimationOnLedstripMessage = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::LedController.Controller.Service.PlayAnimationOnLedstripMessage.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::LedController.Controller.Service.ResultMessage> __Marshaller_connection_ResultMessage = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::LedController.Controller.Service.ResultMessage.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::LedController.Controller.Service.LedstripInfo> __Marshaller_connection_LedstripInfo = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::LedController.Controller.Service.LedstripInfo.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::LedController.Controller.Service.Ledstrip> __Marshaller_connection_Ledstrip = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::LedController.Controller.Service.Ledstrip.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::LedController.Controller.Service.LedstripAnimationInfo> __Marshaller_connection_LedstripAnimationInfo = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::LedController.Controller.Service.LedstripAnimationInfo.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::LedController.Controller.Service.EffectAssembly> __Marshaller_connection_EffectAssembly = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::LedController.Controller.Service.EffectAssembly.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::Google.Protobuf.WellKnownTypes.Empty> __Method_Connect = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Connect",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_google_protobuf_Empty);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::Google.Protobuf.WellKnownTypes.Empty> __Method_Disconnect = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Disconnect",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_google_protobuf_Empty);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::LedController.Controller.Service.PlayAnimationOnLedstripMessage, global::LedController.Controller.Service.ResultMessage> __Method_PlayAnimationOnLedstrip = new grpc::Method<global::LedController.Controller.Service.PlayAnimationOnLedstripMessage, global::LedController.Controller.Service.ResultMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "PlayAnimationOnLedstrip",
        __Marshaller_connection_PlayAnimationOnLedstripMessage,
        __Marshaller_connection_ResultMessage);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::LedController.Controller.Service.LedstripInfo, global::LedController.Controller.Service.ResultMessage> __Method_StopAnimationOnLedstrip = new grpc::Method<global::LedController.Controller.Service.LedstripInfo, global::LedController.Controller.Service.ResultMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "StopAnimationOnLedstrip",
        __Marshaller_connection_LedstripInfo,
        __Marshaller_connection_ResultMessage);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::LedController.Controller.Service.Ledstrip, global::LedController.Controller.Service.ResultMessage> __Method_TestLedstrip = new grpc::Method<global::LedController.Controller.Service.Ledstrip, global::LedController.Controller.Service.ResultMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "TestLedstrip",
        __Marshaller_connection_Ledstrip,
        __Marshaller_connection_ResultMessage);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::LedController.Controller.Service.LedstripAnimationInfo> __Method_GetPlayingLedstrips = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::LedController.Controller.Service.LedstripAnimationInfo>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetPlayingLedstrips",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_connection_LedstripAnimationInfo);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::LedController.Controller.Service.EffectAssembly, global::LedController.Controller.Service.ResultMessage> __Method_UploadEffectAssembly = new grpc::Method<global::LedController.Controller.Service.EffectAssembly, global::LedController.Controller.Service.ResultMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UploadEffectAssembly",
        __Marshaller_connection_EffectAssembly,
        __Marshaller_connection_ResultMessage);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::LedController.Controller.Service.ControlReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of GrpcConnection</summary>
    [grpc::BindServiceMethod(typeof(GrpcConnection), "BindService")]
    public abstract partial class GrpcConnectionBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> Connect(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> Disconnect(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::LedController.Controller.Service.ResultMessage> PlayAnimationOnLedstrip(global::LedController.Controller.Service.PlayAnimationOnLedstripMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::LedController.Controller.Service.ResultMessage> StopAnimationOnLedstrip(global::LedController.Controller.Service.LedstripInfo request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::LedController.Controller.Service.ResultMessage> TestLedstrip(global::LedController.Controller.Service.Ledstrip request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task GetPlayingLedstrips(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::IServerStreamWriter<global::LedController.Controller.Service.LedstripAnimationInfo> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::LedController.Controller.Service.ResultMessage> UploadEffectAssembly(global::LedController.Controller.Service.EffectAssembly request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(GrpcConnectionBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Connect, serviceImpl.Connect)
          .AddMethod(__Method_Disconnect, serviceImpl.Disconnect)
          .AddMethod(__Method_PlayAnimationOnLedstrip, serviceImpl.PlayAnimationOnLedstrip)
          .AddMethod(__Method_StopAnimationOnLedstrip, serviceImpl.StopAnimationOnLedstrip)
          .AddMethod(__Method_TestLedstrip, serviceImpl.TestLedstrip)
          .AddMethod(__Method_GetPlayingLedstrips, serviceImpl.GetPlayingLedstrips)
          .AddMethod(__Method_UploadEffectAssembly, serviceImpl.UploadEffectAssembly).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, GrpcConnectionBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Connect, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Google.Protobuf.WellKnownTypes.Empty, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.Connect));
      serviceBinder.AddMethod(__Method_Disconnect, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Google.Protobuf.WellKnownTypes.Empty, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.Disconnect));
      serviceBinder.AddMethod(__Method_PlayAnimationOnLedstrip, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::LedController.Controller.Service.PlayAnimationOnLedstripMessage, global::LedController.Controller.Service.ResultMessage>(serviceImpl.PlayAnimationOnLedstrip));
      serviceBinder.AddMethod(__Method_StopAnimationOnLedstrip, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::LedController.Controller.Service.LedstripInfo, global::LedController.Controller.Service.ResultMessage>(serviceImpl.StopAnimationOnLedstrip));
      serviceBinder.AddMethod(__Method_TestLedstrip, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::LedController.Controller.Service.Ledstrip, global::LedController.Controller.Service.ResultMessage>(serviceImpl.TestLedstrip));
      serviceBinder.AddMethod(__Method_GetPlayingLedstrips, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::Google.Protobuf.WellKnownTypes.Empty, global::LedController.Controller.Service.LedstripAnimationInfo>(serviceImpl.GetPlayingLedstrips));
      serviceBinder.AddMethod(__Method_UploadEffectAssembly, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::LedController.Controller.Service.EffectAssembly, global::LedController.Controller.Service.ResultMessage>(serviceImpl.UploadEffectAssembly));
    }

  }
}
#endregion
