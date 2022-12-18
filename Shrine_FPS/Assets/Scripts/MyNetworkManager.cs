using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    public override void OnStartServer()
    {
        Debug.Log("Server Started!");
    }

    public override void OnStopServer()
    {
        Debug.Log("Server has Stopped!");
    }

    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        Debug.Log("Client has connected to the Server!");
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        Debug.Log("Client has disconnected from the Server!");
    }
}
