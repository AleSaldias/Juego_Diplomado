using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour


{
public enum ShipState
{
    FullHealth,
    SlightlyDamaged,
    Damaged,
    HeavilyDamaged,
    Destroyed
}

//activar escudo

private void Start()
{
    shield.SetActive(false);
}

    private const int V = 2;


    //variables 
    public float speed = 5.0f;
public  float fireRate = 0.25f;
public int lives = 3;
public int shields = 3;
public float canFire = 0.0f;
public float shieldDuration = 5.0f;
public GameObject Bulletpref; 
public List<Bullet> bullets;
public GameObject shield;
public int shieldsAmount = 3;
public ShipState shipState;
public List<Sprite> shipSprites= new List<Sprite>();
public int actualWeapon = 0;


// para usar audio
public AudioManager audioManager;
public AudioSource actualAudio;

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        Movement();
        CheckBoundarie();
        Fire();
        ChangeWeapon();
        UseShields();
        ChangeWeapon();
        
    }
    //Character Movement, use WASD Keys to move the Player 
    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * VerticalInput * Time.deltaTime);
}
    void CheckBoundarie()
    {
        var cam = Camera.main;
        float xMax = cam.orthographicSize * cam.aspect;
        float yMax = cam.orthographicSize;
        if (transform.position.x > xMax)
        {
            transform.position = new Vector3(-xMax,transform.position.y,0);
        }
        else if (transform.position.x < -xMax)
        {
            transform.position = new Vector3(xMax,transform.position.y,0);
        }
        if (transform.position.y > yMax)
        {
          transform.position = new Vector3(transform.position.x, -yMax, 0);  
        }
        else if (transform.position.y < -yMax)
        {
          transform.position = new Vector3(transform.position.x, yMax, 0); 
        }
    }
    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& Time.time > canFire)
        {
            actualAudio.pitch = Random.Range(0.8f, 1.5f);
                //cambio el metodo de disparo 
            switch (Bulletpref.name)
            {
                case "Bullet":// iniciar bala el centro 
                    Instantiate(Bulletpref, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
                    canFire = Time.time + fireRate;
                    //activar sonido 
                    actualAudio.Play();

                    break;
                case "Missile": // crea 3 balas
                            
                    //bala central
                    var bullet1 = Instantiate(Bulletpref, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
                    bullet1.GetComponent<Missile>().direction = Vector2.up;

                    //bala derecha
                    var bullet2 = Instantiate(Bulletpref, transform.position + new Vector3(0.5f, 0.8f, 0), Quaternion.identity);
                    bullet2.GetComponent<Missile>().direction = new Vector2(0.5f, 1);

                    //bala izquierda
                    var bullet3 = Instantiate(Bulletpref, transform.position + new Vector3(-0.5f, 0.8f, 0), Quaternion.identity);
                    bullet3.GetComponent<Missile>().direction = new Vector2(-0.5f, 1);
                    canFire = Time.time + fireRate;
                    //activar sonido 
                    actualAudio.Play();
                    break;

                case "EnergyBall": // bala lateral 

                    Instantiate(Bulletpref, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
                    canFire = Time.time + fireRate;
                    //activar sonido 
                    actualAudio.Play();
                    break ; 
                    
                case "Rayo": // bala lateral 

                    Instantiate(Bulletpref, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
                    canFire = Time.time + fireRate;
                    //activar sonido 
                    actualAudio.Play();
                    break ; 
            }
        }
        
}

public void ChangeWeapon()
{
    // para cambiar armar usa lo numeros 1,2,3

if (Input.GetKeyDown(KeyCode.Alpha1))
{
    Bulletpref = bullets[0].gameObject;
        actualWeapon = 0;
}
else if (Input.GetKeyDown(KeyCode.Alpha2))
{
    Bulletpref = bullets[1].gameObject;
        actualWeapon = 1;
}
else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Bulletpref = bullets[2].gameObject;
                actualWeapon = 2;
}
else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Bulletpref = bullets[3].gameObject;
        }
        actualWeapon = 3;
    }

void OnCollisionEnter2D(Collision2D collision)
{
    if (collision != null)
    {
        if ( collision.gameObject.CompareTag("Enemy"))
        {
            //destruir al enemigo
            Destroy(collision.gameObject);
            ChangeShipState();
            //destruir al jugador
            if (lives > 1)
            {
                lives--;
                Debug.Log("Lives:"+ lives);
            }
            else
            {
                lives--;
                Destroy(this.gameObject);
            }
            Debug.Log("Collisione");
        }
    }
}
void UseShields()
{
    if (Input.GetKeyDown(KeyCode.LeftAlt)&& shieldsAmount > 0)
    {
        // usa escudos para destruir a todos los enemigos en pantalla
        shieldsAmount--;
        shield.SetActive(true);
        // desactivar colision del jugador
        gameObject.GetComponent<BoxCollider2D>().enabled= false;    
    }
    if (shield.activeSelf)
    {
        shieldDuration-=Time.deltaTime;
        if ( shieldDuration < 0)
        {
            shield.SetActive(false);
            shieldDuration = 5.0f;
            gameObject.GetComponent<BoxCollider2D>().enabled=true;
        }
    }
}
//cambiar estado de nave por daño
void ChangeShipState()
{
    var currentState = shipState;
    Debug.Log(currentState);

    //buscar por nombre
    var newSprite = shipSprites.Find(x => x.name==currentState.ToString());

    //buscar por id
    //var newSprite = shipSprites.[(int)currentState];

    var spriteRenderer=GetComponent<SpriteRenderer>();
    spriteRenderer.sprite=newSprite;
    switch( currentState)
    {
        case ShipState.FullHealth:
            shipState=ShipState.SlightlyDamaged;
            break;
        case ShipState.SlightlyDamaged:
            shipState= ShipState.Damaged;
            break;
        case ShipState.Damaged:
            shipState=ShipState.HeavilyDamaged;
            break;
        case ShipState.HeavilyDamaged:
            shipState= ShipState.Destroyed;
            break;
        case ShipState.Destroyed:
        break;
    }
}
}