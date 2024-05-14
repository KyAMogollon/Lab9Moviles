using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml.Linq;
using Unity.Notifications.Android;
using Unity.VisualScripting;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/Message")]
public class HandleMessage : ScriptableObject
{
    public event Action<string,int, string, string> PutValues;
    public event Action ActionGeneral;
    public event Action<string, string, Importance, string> Channel;

    public void CallEventCreateChannel(string id, string name, Importance import, string description)
    {
        Channel?.Invoke(id, name, import, description);
    }
    public void CallEventPutValues(string title, int fireTimeInHours, string smallIcon, string largeIcon)
    {
        PutValues?.Invoke(title, fireTimeInHours, smallIcon, largeIcon);
    }

    public void CallEventRequest()
    {
        ActionGeneral?.Invoke();
    }
}
