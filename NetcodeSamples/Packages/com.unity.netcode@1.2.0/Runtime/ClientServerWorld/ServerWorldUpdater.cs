using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Entities;
using UnityEngine;

public class ServerWorldUpdater : MonoBehaviour
{
    public static World ServerWorld;

    private Thread _thread;
    
    void Update()
    {
        if (ServerWorld == null)
            return;

        if (_thread != null)
        {
            _thread.Join();
        }
        
        ServerWorld.UpdateInit();

        _thread = new Thread(() =>
        {
            ServerWorld.UpdateSimulation();
        });
        
        _thread.Start();
    }
}
