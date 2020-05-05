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
        bCanMove = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //If heavy can move, move ship forward by speed, which keeps ship at top of screen
        if (bCanMove)
        {
            transform.Translate(Vector3.up * fSpeed * Time.deltaTime, Space.World);
        }
    }
}
