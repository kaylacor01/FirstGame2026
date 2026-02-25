using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovements : MonoBehaviour
{

    [SerializeField] private float speed;

    //for running animation
    [SerializeField] private Animator animator;

    private Rigidbody2D body;
 
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        GameSettings.Load();
        speed = GameSettings.PlayerSpeed;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
 
        //Flip player when facing left/right.
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(0.45f, 0.45f, 1f);

        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-0.45f, 0.45f, 1f);

        //Jump 
         if (Input.GetKey(KeyCode.Space))
            body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
        

        //Run
        if (horizontalInput != 0) {
            animator.SetBool("isRunning", true);
        }
        else {
            animator.SetBool("isRunning", false);

        }
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player hit by: " + collision.gameObject.name);
        
        if(collision.gameObject.CompareTag("Object"))
        {
            // Stop the spawner safely
            RockMov spawner = FindFirstObjectByType<RockMov>();
            if(spawner != null) spawner.CancelInvoke("Fall");

            FindFirstObjectByType<StopWatch>().Stop();
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");

            //FindFirstObjectByType<RockMov>().CancelInvoke("Fall");
            //FindFirstObjectByType<StopWatch>().Stop();
            //Destroy(this.gameObject);
        }
    }
}
