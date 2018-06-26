using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Timer : MonoBehaviour
{
    protected float timeLeft;
    protected Rabbit rabbit;

    private void Start()
    {
        enabled = false;
    }


    public void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0.0f)
        {
            //action        
            action();
            enabled = false;
        }
        else
        {

        }
    }

    public abstract void action();
}