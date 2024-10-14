using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Bullet
{

    public Vector2 direction;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    //sobreescribimos el metodo de movimiento de la bala 
    public override void Movement()
    {
        transform.Translate(direction * speed *  Time.deltaTime);
    }

}
