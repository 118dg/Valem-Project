using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    private InputDevice targetDevice;

    private bool primaryButtonValue;
    private float triggerValue;
    private Vector2 primary2DAxisValue;

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if(devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonValue);
        if (primaryButtonValue)
            Debug.Log("Pressing Primary Button");

        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out triggerValue);
        if (triggerValue > 0.1f)
            Debug.Log("Trigger pressed " + triggerValue);

        targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out primary2DAxisValue);
        if (primary2DAxisValue != Vector2.zero)
            Debug.Log("Primary Touchpad " + primary2DAxisValue);
    }
}
