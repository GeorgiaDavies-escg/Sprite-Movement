using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class RaycastScript : MonoBehaviour
{

    LayerMask playerLayerMask;
    LayerMask groundLayerMask;
    Rigidbody2D rb;
    Vector2 vel;
    

    void Start()
    {
        groundLayerMask = LayerMask.GetMask("Ground");
        rb = GetComponent<Rigidbody2D>();

        vel.x = 1;

    }

    private void Update()
    {

        if (vel.x > 0.5f)
        {
            if (ExtendedRayCollisionCheck(0.3f, 0) == false)
            {
                vel.x = -1;
            }
        }
        else
        {
            if (vel.x < -0.5f )
            {
                if (ExtendedRayCollisionCheck(-0.3f, 0) == false)
                {
                    vel.x = 1;
                }
            }
        }



        rb.linearVelocity = vel;

    }

    public bool ExtendedRayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.5f; // length of raycast
        bool hitSomething = false;

        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downward 
        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position + offset, -Vector2.up, rayLength, groundLayerMask);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.green;
            hitSomething = true;
        }
        // draw a debug ray to show ray position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position + offset, -Vector3.up * rayLength, hitColor);

        return hitSomething;

    }

    public bool PlayerCollision (float xoffs, float yoffs)
    {
        float rayLength = 0.5f; // length of raycast
        bool hitPlayer = false;

        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(0, 1, 0);

        //cast a ray downward 
        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position + offset, Vector3.up, rayLength, playerLayerMask);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.green;
            hitPlayer = true;
        }
        // draw a debug ray to show ray position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position + offset, Vector3.up * rayLength, hitColor);

        return hitPlayer;

    }

}



