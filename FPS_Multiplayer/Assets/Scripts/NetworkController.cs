using UnityEngine;
using Mirror;
using UnityStandardAssets.Characters.FirstPerson;

public class NetworkController : NetworkBehaviour
{
    public FirstPersonController fpsController;
    public Camera playerCam;
   
    void Start()
    {
        fpsController = GetComponent<FirstPersonController>();
        if (!isLocalPlayer)
        {
            fpsController.enabled = false;
            playerCam.enabled = false;
            playerCam.GetComponent<AudioListener>().enabled = false;
        }
    }
}
