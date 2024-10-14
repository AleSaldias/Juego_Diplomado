using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : Bullet
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
    // cambia el metodo de movimiento de las balas 
    
    public override void Movement()

    {
        //use sin to move the bullet in a wave pattern
        transform.Translate (direction * new Vector3(Mathf.Sin(Time.time* 1.5f), 1, 0)* speed * Time.deltaTime);
    }

}
