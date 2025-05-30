using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    public Light flashlight;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }
}
