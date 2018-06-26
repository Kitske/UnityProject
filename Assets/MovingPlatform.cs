using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovingPlatform : MonoBehaviour
{
    public Vector3 MoveBy;
    public float time_to_reach=1;
    public float time_to_wait;
    float saved_time_to_wait; 
    Vector3 pointA;
    Vector3 pointB;
    bool going_to_a=false;
    Rigidbody2D rb2D;

    void Start()
    {
        this.pointA = this.transform.position;
        this.pointB = this.pointA + MoveBy;
        this.saved_time_to_wait = time_to_wait;
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(MoveBy.x / time_to_reach, MoveBy.y / time_to_reach);
    }

    void Update()
    {
        Vector3 my_pos = this.transform.position;
        Vector3 target=going_to_a ? target = this.pointA:target = this.pointB;
        if (isArrived(my_pos, target))
        {
            rb2D.velocity = new Vector2(0, 0);
            time_to_wait -= Time.deltaTime;
            if (time_to_wait <= 0)
            {
                time_to_wait = saved_time_to_wait;
                if (going_to_a)
                {
                    going_to_a = false;
                    target = this.pointB;

                }
                else
                {
                    going_to_a = true;
                    target = this.pointA;
                }

                Vector3 destination = target - my_pos;
                destination.z = 0;
                rb2D.velocity = new Vector2(destination.x / time_to_reach, destination.y / time_to_reach);
            }
        }
    }

    bool isArrived(Vector3 pos,Vector3 target){
        pos.z =0;
        target.z=0;
        return Vector3.Distance(pos,target)<0.02f;
    }

    }
