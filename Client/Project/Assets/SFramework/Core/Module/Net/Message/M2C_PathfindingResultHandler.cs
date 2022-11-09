using Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[MessageHandler]
class M2C_PathfindingResultHandler : AMHandler< OnePerson>
{
    protected override void Run(ClientManager client , OnePerson message)
    {
        Debug.Log(message);
    }
}
