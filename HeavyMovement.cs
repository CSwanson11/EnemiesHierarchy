using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyMovement : EnemiesBase
{
    public bool bCanMove;//tracks whether heavy ship is allowed to move or not
    public float fSpeed;//Speed for movement

    // Start is called before the first frame update
    public new void Start()
    {
        base.Start();
        bCanMove = false;//Start move begins at false
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //If heavy can move, move ship forward by speed
        if (bCanMove)
        {
            transform.Translate(Vector3.up * fSpeed * Time.deltaTime, Space.World);
        }
    }

    //public void OnTriggerEnter2DMid(Collider2D col)
    //{
    //    OnTriggerEnter2DBase(col);
    //    //If heavy collides with stop barrier, set can move to true
    //    if (col.name == "Stop")
    //    {
    //        bCanMove = true;
    //    }
    //}
}
