using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class TaskTwo : MonoBehaviour
{
    Rigidbody2D rb;
    public bool isFacingRight;
    public Animator anim;
    public LayerMask groundLayer;
    bool isGrounded;
    
    // Checks If Sprite is Touching a Box Collider

    void Start()
    {
        isFacingRight = true;
        rb = GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        float xvel, yvel;

        xvel = rb.linearVelocity.x;
        yvel = rb.linearVelocity.y;

        if (Input.GetKey("a"))                  //Increases velocity to move Left
        {
            xvel = -3;
        }

        if (Input.GetKey("d"))                  //Increases velocity to move Right
        {
            xvel = 3;
        }

        if (xvel > 0)
        {
            gameObject.transform.localScale = new Vector3((float)1, (float)1, (float)1);
        }

        if (xvel < 0)
        {
            gameObject.transform.localScale = new Vector3((float)-1, (float)1, (float)1);
        }

        if ( ((Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown("w")) )))              //Increases velocity to move upward (Jump) if sprite is touching a box collider
        {
            if (isGrounded)
            {
                yvel = 5;
            }
        }

        if (xvel >= 0.1f || xvel <= -0.1f)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }


        if (yvel <= 0.1f)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }


        rb.linearVelocity = new Vector3(xvel, yvel, 0);


        GroundCheck();

        print("gc=" + isGrounded);

        }
    
        void GroundCheck()
        {
        isGrounded = DoRayCollisionCheck();
      
        }

        public bool DoRayCollisionCheck()
        {
            float rayLength = 0.5f;


            RaycastHit2D hit;

            hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);

            Color hitColor = Color.white;


            if (hit.collider != null)
            {
                print("Player has collided with Ground layer");
                hitColor = Color.green;
            }

            Debug.DrawRay(transform.position, Vector2.down * rayLength, hitColor);
            return hit.collider;


        }

}
