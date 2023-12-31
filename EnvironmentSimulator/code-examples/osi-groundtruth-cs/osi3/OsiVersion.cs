// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: osi_version.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Osi3 {

  /// <summary>Holder for reflection information generated from osi_version.proto</summary>
  public static partial class OsiVersionReflection {

    #region Descriptor
    /// <summary>File descriptor for osi_version.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static OsiVersionReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChFvc2lfdmVyc2lvbi5wcm90bxIEb3NpMxogZ29vZ2xlL3Byb3RvYnVmL2Rl",
            "c2NyaXB0b3IucHJvdG8iVwoQSW50ZXJmYWNlVmVyc2lvbhIVCg12ZXJzaW9u",
            "X21ham9yGAEgASgNEhUKDXZlcnNpb25fbWlub3IYAiABKA0SFQoNdmVyc2lv",
            "bl9wYXRjaBgDIAEoDTpZChljdXJyZW50X2ludGVyZmFjZV92ZXJzaW9uEhwu",
            "Z29vZ2xlLnByb3RvYnVmLkZpbGVPcHRpb25zGOj4BCABKAsyFi5vc2kzLklu",
            "dGVyZmFjZVZlcnNpb25CFEgBwsYnAggDwsYnAhAFwsYnAhgAYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.Reflection.DescriptorReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pb::Extension[] { OsiVersionExtensions.CurrentInterfaceVersion }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Osi3.InterfaceVersion), global::Osi3.InterfaceVersion.Parser, new[]{ "VersionMajor", "VersionMinor", "VersionPatch" }, null, null, null, null)
          }));
    }
    #endregion

  }
  /// <summary>Holder for extension identifiers generated from the top level of osi_version.proto</summary>
  public static partial class OsiVersionExtensions {
    /// <summary>
    /// Extend \c FileOptions with current interface version of OSI
    /// </summary>
    public static readonly pb::Extension<global::Google.Protobuf.Reflection.FileOptions, global::Osi3.InterfaceVersion> CurrentInterfaceVersion =
      new pb::Extension<global::Google.Protobuf.Reflection.FileOptions, global::Osi3.InterfaceVersion>(81000, pb::FieldCodec.ForMessage(648002, global::Osi3.InterfaceVersion.Parser));
  }

  #region Messages
  /// <summary>
  ///
  /// \brief The interface version number.
  ///
  /// The field denoting the version number. This needs to be set by the
  /// sender to the actual OSI version that is to be sent.  Code wanting to
  /// access the version number of the OSI code base can access a FileOptions,
  /// which has the proper values, like this:
  ///
  /// \code
  /// auto currentInterfaceVersion =
  ///   InterfaceVersion::descriptor()->file()->options().GetExtension(current_interface_version);
  /// \endcode
  ///
  /// If a message with all components set to the default value 0 is
  /// received, this indicates that either that the message was sent by
  /// a version 2.2.0 or earlier release, or that the sender did not
  /// properly set the version components prior to sending.
  ///
  /// Increments will happen as part of changes to the whole interface.
  /// The meaning of different InterfaceVersions is defined in [1].
  ///
  /// \par Reference:
  /// [1] Open Simulation Interface. (2020, January 25). &lt;em>README&lt;/em>. Retrieved January 25, 2020, from https://opensimulationinterface.github.io/osi-documentation/open-simulation-interface/README.html
  /// </summary>
  public sealed partial class InterfaceVersion : pb::IMessage<InterfaceVersion>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<InterfaceVersion> _parser = new pb::MessageParser<InterfaceVersion>(() => new InterfaceVersion());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<InterfaceVersion> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Osi3.OsiVersionReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public InterfaceVersion() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public InterfaceVersion(InterfaceVersion other) : this() {
      versionMajor_ = other.versionMajor_;
      versionMinor_ = other.versionMinor_;
      versionPatch_ = other.versionPatch_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public InterfaceVersion Clone() {
      return new InterfaceVersion(this);
    }

    /// <summary>Field number for the "version_major" field.</summary>
    public const int VersionMajorFieldNumber = 1;
    private uint versionMajor_;
    /// <summary>
    /// Major version number.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint VersionMajor {
      get { return versionMajor_; }
      set {
        versionMajor_ = value;
      }
    }

    /// <summary>Field number for the "version_minor" field.</summary>
    public const int VersionMinorFieldNumber = 2;
    private uint versionMinor_;
    /// <summary>
    /// Minor version number.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint VersionMinor {
      get { return versionMinor_; }
      set {
        versionMinor_ = value;
      }
    }

    /// <summary>Field number for the "version_patch" field.</summary>
    public const int VersionPatchFieldNumber = 3;
    private uint versionPatch_;
    /// <summary>
    /// Patch version number.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint VersionPatch {
      get { return versionPatch_; }
      set {
        versionPatch_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as InterfaceVersion);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(InterfaceVersion other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (VersionMajor != other.VersionMajor) return false;
      if (VersionMinor != other.VersionMinor) return false;
      if (VersionPatch != other.VersionPatch) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (VersionMajor != 0) hash ^= VersionMajor.GetHashCode();
      if (VersionMinor != 0) hash ^= VersionMinor.GetHashCode();
      if (VersionPatch != 0) hash ^= VersionPatch.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (VersionMajor != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(VersionMajor);
      }
      if (VersionMinor != 0) {
        output.WriteRawTag(16);
        output.WriteUInt32(VersionMinor);
      }
      if (VersionPatch != 0) {
        output.WriteRawTag(24);
        output.WriteUInt32(VersionPatch);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (VersionMajor != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(VersionMajor);
      }
      if (VersionMinor != 0) {
        output.WriteRawTag(16);
        output.WriteUInt32(VersionMinor);
      }
      if (VersionPatch != 0) {
        output.WriteRawTag(24);
        output.WriteUInt32(VersionPatch);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (VersionMajor != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(VersionMajor);
      }
      if (VersionMinor != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(VersionMinor);
      }
      if (VersionPatch != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(VersionPatch);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(InterfaceVersion other) {
      if (other == null) {
        return;
      }
      if (other.VersionMajor != 0) {
        VersionMajor = other.VersionMajor;
      }
      if (other.VersionMinor != 0) {
        VersionMinor = other.VersionMinor;
      }
      if (other.VersionPatch != 0) {
        VersionPatch = other.VersionPatch;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            VersionMajor = input.ReadUInt32();
            break;
          }
          case 16: {
            VersionMinor = input.ReadUInt32();
            break;
          }
          case 24: {
            VersionPatch = input.ReadUInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            VersionMajor = input.ReadUInt32();
            break;
          }
          case 16: {
            VersionMinor = input.ReadUInt32();
            break;
          }
          case 24: {
            VersionPatch = input.ReadUInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
