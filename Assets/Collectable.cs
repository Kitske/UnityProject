using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Collectable : MonoBehaviour
{
    public bool hideAnimation;

    protected virtual void OnRabbitHit(Rabbit rabbit) { }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!this.hideAnimation)
        {
            Rabbit rabbit = collider.GetComponent<Rabbit>();
            if (rabbit != null)
            {
                this.OnRabbitHit(rabbit);
            }
        }
    }

    public void CollectedHide() {
        Destroy(this.gameObject);
    }
}
