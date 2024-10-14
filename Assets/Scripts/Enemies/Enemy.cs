using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Variables//
public float speed = 10f;
public int health = 1;
private GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    public virtual void Movement()
    {
        transform.Translate(new Vector3(Mathf.Sin(Time.time * 1.5f), -1, 0) * speed * Time.deltaTime);
    }
     // Método para aplicar daño al enemigo
    public void TakeDamage(int damage)
    {
        // Se resta el daño recibido a la salud del enemigo
        health -= damage;
        
        // Si la salud llega a 0 o menos, el enemigo muere
        if (health <= 0)
        {
            Die();
        }
    }

    // Método que maneja la muerte del enemigo
    protected void Die()
    {
        // Si se ha asignado un prefab de explosión, lo instancia en la posición del enemigo
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        
        
        // Destruye el objeto enemigo
        Destroy(gameObject);
        }
    }

}
