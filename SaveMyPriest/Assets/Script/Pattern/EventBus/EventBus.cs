using UnityEngine;
using System;
using System.Collections.Generic;
public static class EventBus
{
    private static Dictionary<Type,Delegate> _assignedActions = new();
    public static void Publish<T>(T eventType) where T : GameEvent
    {
        var type = typeof(T);
        if(!_assignedActions.TryGetValue(type, out var del)) return;
        if(del is Action<T> action)
        {
            action.Invoke(eventType);
        }
    }

    public static void Subscribe<T>(Action<T> action) where T : GameEvent
    {
        var type = typeof(T);
        if(_assignedActions.TryGetValue(type, out var existingAction))
            _assignedActions[type] = Delegate.Combine(existingAction, action);
        else
            _assignedActions[type] = action;
    }

    public static void Unsubscribe<T>(Action<T> action) where T : GameEvent
    {
        var type = typeof(T);
        if(!_assignedActions.TryGetValue(type, out var existingAction)) return;
        var current = Delegate.Remove(existingAction, action);
        if(current == null)
            _assignedActions.Remove(type);
        else
            _assignedActions[type] = current;
    }

    public static void Clear() => _assignedActions.Clear();
}
