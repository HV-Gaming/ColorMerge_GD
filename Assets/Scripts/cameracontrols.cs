using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrols : MonoBehaviour
{

    public GameObject cinecam;
    public GameObject gamecam;
   

    public void playCinematics()
    {
        gamecam.SetActive(true);
    }

    public void endgameanim()
    {
        cinecam.SetActive(true);
    }

}
