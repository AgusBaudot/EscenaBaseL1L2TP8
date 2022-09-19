using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public CameraManager camManager;

    public void ActivateCamera()
    {
        camManager.CameraActivation();
    }
}
