using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    private void Update()
    {
        Movement();
        if (isLocalPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Sending HELLO TO Server...");
            Hello();
        }
        //if (isLocalPlayer && Input.GetKeyDown(KeyCode.A))
        //   // Not a good idea :/
        //{
        //    Debug.Log("Called from Server, but running on all Clients :)");
        //    ClientRPC();
        //}
    }

    public void Movement()
    {
        float speed = 0.5f;
        if (isLocalPlayer)
        {
            float verticalMovement = Input.GetAxis("Vertical");
            float horizontalMovement = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0);
            transform.position = transform.position + movement * speed;
        }
    }

    public override void OnStartServer()
    {
        Debug.Log("Player has been spawned on the Server!");
    }

    // Command is used for communication from Client to Server.
    // Called from a Client and executed on a Server.
    [Command]
    public void Hello()
    {
        Debug.Log("Received HELLO from Client...");
        ReplyHello();
    }

    // Called from Server, but running on a Target Client.(gameobj the component is attached to...etc)
    [TargetRpc]
    public void ReplyHello()
    {
        Debug.Log("Received HELLO from Server...");
    }

    [ClientRpc]
    public void ClientRPC()
    {
        Debug.Log("Hello from Clients ;)");
    }

    [SyncVar]
    int helloCount = 0;
    //SyncVars are properties of classes that inherit from NetworkBehaviour, which are synchronized from the server to clients.
    //When a game object is spawned, or a new player joins a game in progress, 
    //they are sent the latest state of all SyncVars on networked objects that are visible to them.
    //Use the SyncVar custom attribute to specify which variables in your script you want to synchronize.
}
