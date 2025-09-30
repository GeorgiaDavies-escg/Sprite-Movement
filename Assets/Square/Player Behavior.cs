using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float xpos = transform.position.x;
        float ypos = transform.position.y;

        //On the press of WASD Move Sprite

        if (Input.GetKey("w")==true)
        {
            ypos += 0.1f;
            print(xpos);
            print(ypos);
        }

        if (Input.GetKey("d") == true)
        {
            xpos += 0.1f;
            print(xpos);
            print(ypos);
        }

        if (Input.GetKey("s") == true)
        {
            ypos -= 0.1f;
            print(xpos);
            print(ypos);
        }

        if (Input.GetKey("a") == true)
        {
            xpos -= 0.1f;
            print(xpos);
            print(ypos);
        }

        //Setting Boundaries of where the sprite can move

        if (xpos > 1.5f)
        {
            xpos = 1.5f;
        }

        if (xpos < -1.5f)
        {
            xpos = -1.5f;
        }

        if (ypos < -1f)
        {
            ypos = -1f;
        }

        if (ypos > 1f)
        {
            ypos = 1f;
        }

        transform.position = new Vector3(xpos, ypos, 0);

        //Quit game script using Q

        if (Input.GetKey("q") == true)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }

    }
}
