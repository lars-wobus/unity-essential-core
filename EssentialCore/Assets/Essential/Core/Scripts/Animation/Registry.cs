using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Essential.Core.Animation;
using JetBrains.Annotations;
using UnityEngine;

public class Registry<T> where T : class/*, IObserver*/{
    private List<T> Subscribers { get; set; }

    public Registry()
    {
        Subscribers = new List<T>();
    }
    
    public void Subscribe([NotNull] T observer)
    {
        if (Subscribers.Any(element => element.Equals(observer)))
        {
            return;
        }
			
        Subscribers.Add(observer);
    }

    public void Unsubscribe(T observer)
    {
        Subscribers.Remove(observer);
    }
    
    public void NotifyObservers()
    {
        foreach (var element in Subscribers)
        {
            //element.Update();
        }
    }
}
