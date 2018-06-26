using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomCollectable : Collectable
{
    
    protected override void OnRabbitHit(Rabbit rabbit)
    {
        
        LevelController.current.mushroomPickUpAction(rabbit);
        this.CollectedHide();
    }
}