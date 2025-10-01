using UnityEditor;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Rigidbody2D rb;
    HelperScript helper;
    public TaskTwo playerScript;

    void Start()
    {
        helper = gameObject.AddComponent<HelperScript>();
    }

    void Update()
    {
        // print("Enemy says: The player has " + playerScript.lives + " lives");

        float xvel;

        xvel = rb.linearVelocity.x;

        if (xvel > 0)
        {
            helper.DoFlipObject(true);
        }

        if (xvel < 0)
        {
            helper.DoFlipObject(true);
        }
    }
}
