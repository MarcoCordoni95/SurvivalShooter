using UnityEngine;

public class EnemyManager : MonoBehaviour{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;


    void Start (){
        InvokeRepeating ("Spawn", spawnTime, spawnTime); // esegue la funzione Spawn dopo spawnTime secondi e la ripete dopo ogni spawnTime secondi
    }


    void Spawn (){
        if(playerHealth.currentHealth <= 0f){
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length); // sceglia a caso una posizione in spawnPoints

        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation); // spawna un nemico enemy nella posizione spawnPoints[spawnPointIndex].position, ruotato verso spawnPoints[spawnPointIndex].rotation
    }
}