using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;
#if UNITY_ANDROID
using Unity.Notifications.Android;
using UnityEngine.Android;
#endif

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/Notification", order = 3)]
public class NotificationDataSO : ScriptableObject
{
    public string IDChannel;
    public string NameChannel;
    public Importance importance;
    public string Description;
    public string title;
    public int fireTimeInHours;
    public string smallIcon;
    public string largeIcon;

}
