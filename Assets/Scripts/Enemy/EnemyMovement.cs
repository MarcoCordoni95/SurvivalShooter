using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player; // non public perchè i nemici non sono presenti all'avvio del gioco ma spawnnano dopo
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;


    void Awake (){
        player = GameObject.FindGameObjectWithTag ("Player").transform; // per trovare il player, .transform per ottenere le info dal player
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> (); // referenzia un componente dell'editor
    }


    void Update (){ // usiamo update e on fixedUpdate, non ci interessa la fisica
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0){
            nav.SetDestination (player.position); // per mandarlo alla posizione del player
        }
        else{
            nav.enabled = false;
        }
    }
}
