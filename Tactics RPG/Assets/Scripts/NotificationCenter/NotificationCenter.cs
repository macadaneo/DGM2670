using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SenderTable = System.Collections.Generic.Dictionary<System.Object, System.Collections.Generic.List<System.EventHandler>>;

public class NotificationCenter 
{
    #region Singleton Pattern

    public static readonly NotificationCenter instance = new NotificationCenter();

    private NotificationCenter()
    {
        
    }

    private Dictionary<string, SenderTable> _table = new Dictionary<string, SenderTable>();

    private SenderTable GetSenderTable(string notificationName)
    {
        if (!_table.ContainsKey(notificationName))
        {
            _table.Add(notificationName, new SenderTable());
        }
        return _table[notificationName];
    }

    private List<EventHandler> GetObservers(SenderTable subTable, System.Object sender)
    {
        if (!subTable.ContainsKey(sender))
        {
            subTable.Add(sender, new List<EventHandler>());
        }
        return subTable[sender];
    }

    public void AddObserver(EventHandler handler, string notificationName)
    {
        AddObserver(handler, notificationName, null);
    }

    public void AddObserver(EventHandler handler, string notificationName, System.Object sender)
    {
        if (handler == null)
        {
            Debug.LogError("Can't add a null event handler for notification, " + notificationName);
            return;
        }

        if (string.IsNullOrEmpty(notificationName))
        {
            Debug.LogError("Can't observe an unnamed notification");
            return;
        }

        SenderTable subTable = GetSenderTable(notificationName);
        System.Object key = (sender != null) ? sender : this;
        List<EventHandler> list = GetObservers(subTable, key);
        if (!list.Contains(handler))
        {
            list.Add(handler);
        }
    }

    #endregion
}
