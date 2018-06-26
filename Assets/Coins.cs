using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Collectable
{
    protected override void OnRabbitHit(Rabbit rabbit) {
        LevelController.current.addCoins(1);
        this.CollectedHide();
    }
}
