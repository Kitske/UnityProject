using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomTimer : Timer {
    public float savedTime;
   

    private void Start()
    {
        enabled = false;
    }

    public override void action()
    {
        //make rabbit smaller
        rabbit.gameObject.transform.localScale -= new Vector3(1, 1, 0);
        LevelController.current.isMushroomActivated = false;
        enabled = false;
    }

    public void beginNewLoop(Rabbit rabbit)
    {
        this.rabbit = rabbit;
        this.timeLeft = savedTime;
        enabled = true;
    }
    
}
