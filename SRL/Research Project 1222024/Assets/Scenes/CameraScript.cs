using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    //public InputActionReference toggleUpReference = null;

    //public InputActionReference toggleDownReference = null;

    public int currentCamIndex = 0;

    public int amountOfCameras = 1;

    WebCamTexture tex;

    public RawImage display;


    // Start is called before the first frame update
    void Start()
    {
        currentCamIndex = 0;
        
        WebCamDevice[] devices = WebCamTexture.devices;
        WebCamDevice device = devices[currentCamIndex];
        tex = new WebCamTexture(device.name);
        display.texture = tex;
        tex.Play();
    }
    
    
    public void updateCameraUp(InputAction.CallbackContext context){
        if(context.started){
            Debug.Log("Camera up activated.");
        
            if(currentCamIndex < amountOfCameras - 1){
                display.texture = null;
                tex.Stop();
                tex = null;
                Debug.Log("Camera indexed up!");
                currentCamIndex = currentCamIndex + 1;
                WebCamDevice device = WebCamTexture.devices[currentCamIndex];
                tex = new WebCamTexture(device.name);
                display.texture = tex;
                tex.Play();
            }
        }
    }

    public void updateCameraDown(InputAction.CallbackContext context){
        if(context.started){
        Debug.Log("Camera down activated.");
        if(currentCamIndex > 0){
                display.texture = null;
                tex.Stop();
                tex = null;
                Debug.Log("Camera index moved down!");
                currentCamIndex = currentCamIndex - 1;
                WebCamDevice device = WebCamTexture.devices[currentCamIndex];
                tex = new WebCamTexture(device.name);
                display.texture = tex;
                tex.Play();
            }
        }
    }
}
