using Google.Protobuf;
using Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class TestController : BaseController
{
    public TestController()
    {
        requestCode = RequestCode.Test;
    }
    public string TestFun(byte[] dataByte, Client client, Server server)
    {
        //...
        //将字节数组转换为OnePerson对象
        IMessage message = new OnePerson();
        OnePerson mySelf = new OnePerson();
        mySelf = (OnePerson)message.Descriptor.Parser.ParseFrom(dataByte);
        //打印输出
        Console.WriteLine($"My name is:{mySelf.Name}");
        Console.WriteLine($"My idNumber is:{mySelf.IdNumber}");
        Console.WriteLine($"My gender is:{mySelf.Gender}");
        Console.WriteLine($"My profession is:{mySelf.Profession}");
        return dataByte.ToString();
    }
}
