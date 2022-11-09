using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Event(EventIdType.UpdateCompetitions)]
class TestEventSystem : AEvent
{
    public override void Run(string args)
    {
        Debug.Log("TestSystem");
    }
}
