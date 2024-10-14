using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameManager gameManager;
    public float speed = 10f;
  
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    public virtual void Movement()
    {
        transform.Translate(Vector3.up * 5.0f * Time.deltaTime);
    }
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
if ( collision.gameObject.CompareTag("Enemy"))
       {
            gameManager.Addscore(10);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
