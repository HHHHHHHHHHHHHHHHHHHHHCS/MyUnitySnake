using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraResize : MonoBehaviour
{
    float devHeight = 1080f;
    float devWidth = 1920f;

    // Use this for initialization
    void Wwake()
    {

        float screenHeight = Screen.height;

        float orthographicSize = GetComponent<Camera>().orthographicSize;

        float aspectRatio = Screen.width * 1.0f / Screen.height;

        float cameraWidth = orthographicSize * 2 * aspectRatio;


        if (cameraWidth < devWidth)
        {
            orthographicSize = devWidth / (2 * aspectRatio);
            GetComponent<Camera>().orthographicSize = orthographicSize;
        }

    }
}
