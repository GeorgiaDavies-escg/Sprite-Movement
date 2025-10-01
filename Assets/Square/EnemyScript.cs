using UnityEditor;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Rigidbody2D rb;
    public TaskTwo playerScript;

    void Start()
    {


    }

    void Update()
    {
        // print("Enemy says: The player has " + playerScript.lives + " lives");

        float xvel;

        xvel = rb.linearVelocity.x;

        if (xvel > 0)
        {
        }

        if (xvel < 0)
        {
        }
    }
}
