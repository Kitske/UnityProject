using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCollectable : Collectable
{
    protected override void OnRabbitHit(Rabbit rabbit)
    {
        LevelController.current.bombPickUpAction(rabbit);
        this.CollectedHide();
    }
}