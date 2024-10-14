using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy2 : Enemy
{
        void Update()
    {
        Movement();
    }
public override void Movement()
    {
        transform.Translate(new Vector3(Mathf.Sin(Time.time * 1.0f), -2, 0) * speed * Time.deltaTime);
    }
  
}
