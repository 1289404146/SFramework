using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


public interface IMHandler
{
    void Handle(ClientManager socket, object message);
    Type GetMessageType();
}
