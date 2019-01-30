using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapping : MonoBehaviour
{
    private void Update()
    {
        //this is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //this is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        ////deze is van boven naar onder
        //if (transform.position.y > max.y)
        //{
        //    transform.position = new Vector2(transform.position.x, min.y);
        //}

        ////deze is van onder naar boven
        //if (transform.position.y < min.y)
        //{
        //    transform.position = new Vector2(transform.position.x, max.y);
        //}

        //deze is van rechts naar links
        if (transform.position.x > max.x)
        {
            transform.position = new Vector2(min.x, transform.position.y);
        }

        //deze is van links naar rechts
        if (transform.position.x < min.x)
        {
            transform.position = new Vector2(max.x, transform.position.y);
        }
    }
}