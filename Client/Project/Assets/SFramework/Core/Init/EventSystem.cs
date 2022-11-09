using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EventSystem
{
    private readonly Dictionary<string, List<IEvent>> allEvents = new Dictionary<string, List<IEvent>>();
    private readonly List<Type> types = new List<Type>();

    public EventSystem()
    {
        this.types.Clear();

        List<Type> ts = typeof(Main).Assembly.GetTypes().ToList();
        if (ts == null)
            return;

        foreach (Type type in ts)
        {
            this.types.Add(type);
        }
        this.allEvents.Clear();
        foreach (Type type in types)
        {
            object[] attrs = type.GetCustomAttributes(typeof(EventAttribute), false);

            foreach (object attr in attrs)
            {
                EventAttribute aEventAttribute = (EventAttribute)attr;
                object obj = Activator.CreateInstance(type);
                IEvent iHotFixEvent = obj as IEvent;
                if (iHotFixEvent == null)
                {
                    Debug.LogError($"{obj.GetType().Name} 没有继承IEvent");
                }
                this.RegisterEvent(aEventAttribute.Type, iHotFixEvent);
            }
        }
    }
    private void RegisterEvent(string eventId, IEvent e)
    {
        if (!this.allEvents.ContainsKey(eventId))
        {
            this.allEvents.Add(eventId, new List<IEvent>());
        }
        this.allEvents[eventId].Add(e);
    }

    List<IEvent> iEvents = null;
    public void Run(string type, string args = null)
    {
        if (!this.allEvents.ContainsKey(type))
        {
            return;
        }
        iEvents = this.allEvents[type];
        int cnt = iEvents.Count;
        for (int i = 0; i < cnt; i++)
        {
            try
            {
                iEvents[i].Args = args;
                iEvents[i]?.Handle();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}

