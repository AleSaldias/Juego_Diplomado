using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayo : Bullet
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
    public override void Movement()
    {
        transform.Translate(direction * new Vector3(Mathf.Sin(Time.time* 1.5f), 2, 0) * speed *  Time.deltaTime);
}

}
