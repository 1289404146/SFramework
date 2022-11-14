using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

class ControllerManager
{
    private Dictionary<RequestCode, BaseController> controllerDict = new Dictionary<RequestCode, BaseController>();
    private Server server;

    public ControllerManager(Server server)
    {
        this.server = server;
        InitController();
    }
    public enum DLLType
    {
        Model,
        Hotfix,
        Editor,
    }
    private readonly Dictionary<DLLType, Assembly> assemblies = new Dictionary<DLLType, Assembly>();
    private readonly UnOrderMultiMap<Type, Type> types = new UnOrderMultiMap<Type, Type>();
    void AddAllType()
    {
        if (!assemblies.ContainsKey(DLLType.Model))
        {
            assemblies.Add(DLLType.Model, this.GetType().Assembly);
        }
        foreach (Assembly value in assemblies.Values)
        {
            foreach (Type type in value.GetTypes())
            {
                object[] objects = type.GetCustomAttributes(typeof(BaseAttribute), false);
                if (objects.Length == 0)
                {
                    continue;
                }

                BaseAttribute baseAttribute = (BaseAttribute)objects[0];
                this.types.Add(baseAttribute.AttributeType, type);
            }
        }
    }
    List<Type> GetTypes(Type systemAttributeType)
    {
        if (!this.types.ContainsKey(systemAttributeType))
        {
            return new List<Type>();
        }
        return this.types[systemAttributeType];
    }

    void InitController()
    {
        AddAllType();
        DefaultController defaultController = new DefaultController();
        controllerDict.Add(defaultController.RequestCode, defaultController);
        controllerDict.Add(RequestCode.User, new UserController());
        controllerDict.Add(RequestCode.Room, new RoomController());
        controllerDict.Add(RequestCode.Game, new GameController());
        controllerDict.Add(RequestCode.Test, new TestController());
    }

    public void HandleRequest(RequestCode requestCode, ActionCode actionCode, string data, Client client)
    {
        BaseController controller;
        bool isGet = controllerDict.TryGetValue(requestCode, out controller);
        if (isGet == false)
        {
            Console.WriteLine("无法得到[" + requestCode + "]所对应的Controller,无法处理请求"); return;
        }
        string methodName = Enum.GetName(typeof(ActionCode), actionCode);
        MethodInfo mi = controller.GetType().GetMethod(methodName);
        if (mi == null)
        {
            Console.WriteLine("[警告]在Controller[" + controller.GetType() + "]中没有对应的处理方法:[" + methodName + "]"); return;
        }
        object[] parameters = new object[] { data, client, server };
        object o = mi.Invoke(controller, parameters);
        if (o == null || string.IsNullOrEmpty(o as string))
        {
            return;
        }
        server.SendResponse(client, actionCode, o as string);
    }
    public void HandleRequestByR(RequestCode requestCode, ActionCode actionCode, string data, Client client)
    {
        List<Type> types = GetTypes(Type.GetType("ControllerAttribute"));
        BaseController controller;
        foreach (var item in types)
        {
            switch (requestCode)
            {
                case RequestCode.None:
                    controller = Activator.CreateInstance(typeof(DefaultController)) as DefaultController;
                    break;
                case RequestCode.User:
                    controller = Activator.CreateInstance(typeof(UserController)) as BaseController;
                    break;
                case RequestCode.Room:
                    controller = Activator.CreateInstance(typeof(RoomController)) as BaseController;
                    break;
                case RequestCode.Game:
                    controller = Activator.CreateInstance(typeof(GameController)) as BaseController;
                    break;
                case RequestCode.Test:
                    controller = Activator.CreateInstance(typeof(TestController)) as BaseController;
                    break;
                default:
                    controller = null;
                    break;
            }
            string methodName = Enum.GetName(typeof(ActionCode), actionCode);
            MethodInfo mi = controller.GetType().GetMethod(methodName);
            if (mi == null)
            {
                Console.WriteLine("[警告]在Controller[" + controller.GetType() + "]中没有对应的处理方法:[" + methodName + "]"); return;
            }
            object[] parameters = new object[] { data, client, server };
            object o = mi.Invoke(controller, parameters);
            if (o == null || string.IsNullOrEmpty(o as string))
            {
                return;
            }
            server.SendResponse(client, actionCode, o as string);
        }
    }
    public void HandleProtolRequest(RequestCode requestCode, ActionCode actionCode, byte[] data, Client client)
    {
        BaseController controller;
        bool isGet = controllerDict.TryGetValue(requestCode, out controller);
        if (isGet == false)
        {
            Console.WriteLine("无法得到[" + requestCode + "]所对应的Controller,无法处理请求"); return;
        }
        string methodName = Enum.GetName(typeof(ActionCode), actionCode);
        MethodInfo mi = controller.GetType().GetMethod(methodName);
        if (mi == null)
        {
            Console.WriteLine("[警告]在Controller[" + controller.GetType() + "]中没有对应的处理方法:[" + methodName + "]"); return;
        }
        object[] parameters = new object[] { data, client, server };
        object o = mi.Invoke(controller, parameters);
        if (o == null || string.IsNullOrEmpty(o as string))
        {
            return;
        }
        server.SendResponse(client, actionCode, o as string);
    }

}
