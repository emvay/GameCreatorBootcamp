using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera[] cameras;

    private void Start()
    {
        // Disable all cameras at the start
        foreach (Camera cam in cameras)
        {
            cam.enabled = false;
        }

        // Enable the first camera by default
        if (cameras.Length > 0)
        {
            cameras[3].enabled = true;
        }
    }

    private void Update()
    {
        // Check if a key is pressed ingame so the below for doesn't work in every frame
        if (Input.anyKeyDown)
        {
            // This is for not having multiple ifs and handling dynamic number of cameras based on the pressed key
            for (int i = 0; i < cameras.Length; i++)
            {
                if (Input.GetKeyDown((KeyCode)(KeyCode.Alpha1 + i))) // Converts i to string (1, 2, 3...)
                {
                    SwitchCamera(i);
                }
            }
        }
    }

    private void SwitchCamera(int index)
    {
        // Disable all cameras
        foreach (Camera cam in cameras)
        {
            cam.enabled = false;
        }

        // Enable the selected camera
        cameras[index].enabled = true;
    }
}
