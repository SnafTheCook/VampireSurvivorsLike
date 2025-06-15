using UnityEngine;
using System.Collections.Generic;

public class TimerSystem : MonoBehaviour //in some editors class needs to be set in Script Execution Order before other scripts
{
    public static TimerSystem Instance;
    private List<TimerItem> subscribers = new List<TimerItem>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(Instance);
            Instance = this;
        }
    }
    void FixedUpdate()
    {
        foreach (var timerable in subscribers)
        {
            if (timerable.timeCurrent > 0f)
                timerable.timeCurrent -= Time.fixedDeltaTime;
            else
            {
                timerable.timeCurrent = timerable.timeMax;
                if (timerable.timerable != null)
                    timerable.timerable.Execute();
                else
                    subscribers.Remove(timerable);
            }
        }
    }

    public TimerItem Subscribe(ITimerable timerable, float iterationsPerSecond)
    {
        TimerItem newTimerItem = new TimerItem(1 / iterationsPerSecond, timerable);
        subscribers.Add(newTimerItem);

        return newTimerItem;
    }

    public void Unsubscribe(TimerItem timerItem)
    {
        subscribers.Remove(timerItem);
    }
}

public class TimerItem
{
    public float timeMax;
    public float timeCurrent;
    public ITimerable timerable;

    public TimerItem(float time, ITimerable timerable)
    {
        this.timeMax = time;
        this.timeCurrent = time;
        this.timerable = timerable;
    }
}

