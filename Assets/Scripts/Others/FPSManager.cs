using System;
using UnityEngine;
using TMPro;

public class FPSManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fpsText;

    private void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass androidVersion = new AndroidJavaClass("android.os.Build$VERSION");
            int sdkInt = androidVersion.GetStatic<int>("SDK_INT");
            
            if (sdkInt >= 28)
            {
                Application.targetFrameRate = 60;
            }
            else 
            {
                Application.targetFrameRate = 30;
            }
        }
        else
        {
            Application.targetFrameRate = 60;
        }
    }

    private void Update()
    {
        float fps = 1f / Time.deltaTime;
        
        if (fpsText != null)
        {
            fpsText.text = "FPS: " + Mathf.Round(fps);
        }
    }
}