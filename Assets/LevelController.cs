using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController current;
    public int coins=0,fruits=0;
    public bool[] diamonds = new bool[3];
    public bool isMushroomActivated;
    public Rabbit rabbit;
    Vector3 startingPosition;
    private bool isCoroutineExecuting = false;
    public MushroomTimer mTimer;
    IEnumerator ExecuteAfterTime(float time,Rabbit rabbit)
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);

        // Code to execute after the delay

        isCoroutineExecuting = false;
        rabbit.transform.position = this.startingPosition;
        rabbit.GetComponent<Animator>().SetBool("death", false);
        rabbit.myBody.velocity = new Vector2(0, 0);
        
    }

    void Awake()
    {
        current = this;
        isMushroomActivated = false;
}

    public void setStartPosition(Vector3 pos)
    {
        this.startingPosition = pos;
    }

    public void onRabbitDeath(Rabbit rabbit)
    {
        rabbit.GetComponent<Animator>().SetBool("death", true);

        //        При        смерті    кролика    повертаємо    на    початкову    позицію    
        StartCoroutine(ExecuteAfterTime(1,rabbit));
        
    }
    public void addCoins(int amount) {
        coins += amount;
    }

    public void addFruits(int amount) {
        fruits += amount;
    }

    public void addDiamond(int n)
    {
        diamonds[n] = true;
    }

    public void mushroomPickUpAction(Rabbit rabbit)
    {
        if (!current.isMushroomActivated)
        {
            rabbit.gameObject.transform.localScale += new Vector3(1, 1, 0);
        }
        current.isMushroomActivated = true;
        mTimer.beginNewLoop(rabbit);

    }

    public void bombPickUpAction(Rabbit rabbit)
    {
        if (!current.isMushroomActivated) {
            onRabbitDeath(rabbit);
        }
        else
        {
            rabbit.gameObject.transform.localScale -= new Vector3(1, 1, 0);
            LevelController.current.isMushroomActivated = false;
            mTimer.enabled = false;
        }
    }

  

}
