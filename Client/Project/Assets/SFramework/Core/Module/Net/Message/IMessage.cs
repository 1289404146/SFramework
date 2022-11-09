using Google.Protobuf;
using Google.Protobuf.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IMessage: Google.Protobuf.IMessage
{
}
public interface IRequest : IMessage
{
	int RpcId { get; set; }
}

public interface IResponse : IMessage
{
	int Error { get; set; }
	string Message { get; set; }
	int RpcId { get; set; }
}
public class ResponseMessage : IResponse
{
	public int Error { get; set; }
	public string Message { get; set; }
	public int RpcId { get; set; }
    public MessageDescriptor Descriptor => throw new NotImplementedException();

    public void MergeFrom(CodedInputStream input)
	{
		throw new System.NotImplementedException();
	}

	public void WriteTo(CodedOutputStream output)
	{
		throw new System.NotImplementedException();
	}

	public int CalculateSize()
	{
		throw new System.NotImplementedException();
	}
}