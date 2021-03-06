﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	private  class TimedEvent
    {
        public float timeToExecute;
        public Callback method;
    }

    public delegate void Callback();
    private List<TimedEvent> events;


    private void Awake()
    {
        events = new List<TimedEvent>();
    }

    public void Add(Callback method, float inSeconds)
    {
        events.Add(new TimedEvent
        {
            method = method,
            timeToExecute = Time.time + inSeconds
        }
        );
    }

    public void Update()
    {
        if (events.Count == 0)
            return;
        for(int i = 0; i < events.Count; i++)
        {
            var timedEvent = events[i];
            if(timedEvent.timeToExecute <= Time.time)
            {
                timedEvent.method();
                events.Remove(timedEvent);
            }
        }
    }
}
