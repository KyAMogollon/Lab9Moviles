using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;
using UnityEngine.Android;
#if UNITY_ANDROID
using Unity.Notifications.Android;
using UnityEngine.Android;
#endif

public class NotificationSystem : MonoBehaviour
{
    [SerializeField] public HandleMessage _values;
    [SerializeField] public HandleMessage _createChannel;
    [SerializeField] public HandleMessage _Request;
    private void Start()
    {
        _Request.ActionGeneral += RequestAuhtorization;
        _createChannel.Channel += RegisterNotificationChannel;
        _values.PutValues += SendValuesNotification;
    }
    public void RequestAuhtorization()
    {
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }
    public void RegisterNotificationChannel(string id, string name, Importance import,string description)
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel
        {
            Id = id,
            Name = name,
            Importance = import,
            Description = description
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }
    public void SendValuesNotification(string title, int FireTimeHours, string smallIcon, string largeIcon)
    {
        AndroidNotification notification = new AndroidNotification();
        notification.Title = title;
        notification.FireTime = DateTime.Now.AddSeconds(FireTimeHours);
        notification.SmallIcon = smallIcon;
        notification.LargeIcon = largeIcon;
        AndroidNotificationCenter.SendNotification(notification, "default_channel");
    }
}
