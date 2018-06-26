using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCollectable : Collectable
{
    public int diamondNumber;
    protected override void OnRabbitHit(Rabbit rabbit)
    {
        LevelController.current.addDiamond(diamondNumber);
        this.CollectedHide();
    }
}