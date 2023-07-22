using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float MoveSpeed = 2f;
    public bool HorizontalPlatform;
    public bool VerticalPlatform;
    public bool MoveRight = true;
    public bool MoveUp = true;


    // Update is called once per frame
    void Update()
    {
        if (HorizontalPlatform)
        {
            if (transform.position.x > -5)
            {
                MoveRight = false;
            }
            else if (transform.position.x < -8)
            {
                MoveRight = true;
            }

            if (MoveRight)
            {
                transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.right * -MoveSpeed * Time.deltaTime);
            }
        }

        if (VerticalPlatform)
        {
            if (transform.position.y > 3)
            {
                MoveUp = false;
            }
            else if (transform.position.y < -1.64f)
            {
                MoveUp = true;
            }

            if (MoveUp)
            {
                transform.Translate(Vector2.up * MoveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.up * -MoveSpeed * Time.deltaTime);
            }
        }
    }   
}
