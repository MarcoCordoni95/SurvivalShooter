using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public float speed = 6f;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;

    void Awake(){
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){ // usato per spostare oggetti fisici con un rigidbody
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);
    }

    void Move(float h, float v){
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime; // moltiplico per deltaTime per eveitare che si muova a quella velocità ad ogni frame, sarebbe velocissimo
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning(){
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if(Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)){ // se ha colpito qualcosa, out significa che abbiamo preso l'informazione da fuori di questa funzione
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animating(float h, float v){
        bool walking = h != 0f || v != 0f; // walking è a True quando o si sta camminando in verticalo o si sta camminando in orizzontale
        anim.SetBool("IsWalking", walking);
    }
}
