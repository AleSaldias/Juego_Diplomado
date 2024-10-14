using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;  // Prefab del enemigo
    public GameObject enemy2Prefab; // Prefab del enemigo 2
    public float spawnTime = 1.5f;  // Tiempo entre spawns
    private float time = 0.0f;      // Tiempo transcurrido (debería ser private para encapsular mejor)
    public float totaltime = 0.0f;
    public Player player;
    public TextMeshProUGUI liveText;
    public TextMeshProUGUI shieldText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI armaText;
    public TextMeshProUGUI timeText;
    public int score = 0;
    [Header("UI")]
    public Image bulletImage;
    public List<Sprite> bulletSprites;



    // Update is called once per frame
    void Update()
    {
        CreateEnemy();  // Llamada funcion CreateEnemy
        CreateEnemy2();
        UpdateCanvas();
        ChangeBulletImage(player.actualWeapon);
        totaltime+= Time.deltaTime;
    }

    void UpdateCanvas()
    {
        liveText.text = "vidas: " + player.lives;
        shieldText.text = "escudo: " + player.shields;
        scoreText.text = "score: " + score;
        armaText.text = "arma: "  + player.Bulletpref.name;
        timeText.text = "tiempo: " + totaltime.ToString("F0");
    }

    private void CreateEnemy()
    {
        time += Time.deltaTime;  // Aumenta el tiempo transcurrido
        if (time > spawnTime)    // Si ha pasado más tiempo que el tiempo de spawn...
        {
            // Instancia el enemigo en una posición aleatoria dentro de un rango
            Instantiate(enemyPrefab, new Vector3(Random.Range(-8.0f, 8.0f), 7.0f, 0), Quaternion.identity);
            time = 0.0f;  // Reinicia el contador de tiempo
        }
    }
    
    private void CreateEnemy2()
    {
        time += Time.deltaTime;  // Aumenta el tiempo transcurrido
        if (time > spawnTime)    // Si ha pasado más tiempo que el tiempo de spawn...
        {
            // Instancia el enemigo en una posición aleatoria dentro de un rango
            Instantiate(enemy2Prefab, new Vector3(Random.Range(-5.0f, 5.0f), 4.0f, 0), Quaternion.identity);
            time = 0.0f;  // Reinicia el contador de tiempo
        }
    }
    public void  Addscore(int value)
        {
score += value;
        }
    public void ChangeBulletImage(int index)
    {
        Debug.Log("ChangeBulletImage:"+ index);
        bulletImage.sprite = bulletSprites[index];
    }
}