using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityStandardAssets.Characters.FirstPerson;

public class NetworkController : NetworkBehaviour
{
    public FirstPersonController fpsController;
    public Camera playerCam;
    //public GameObject _playerCameraRoot;
   
    void Start()
    {
        fpsController = GetComponent<FirstPersonController>();
        if (!isLocalPlayer)
        {
            fpsController.enabled = false;
            playerCam.enabled = false;
        }
    }

    void Update()
    {
    }
}
