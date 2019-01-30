using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlokSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Prefab_Blok; //this is our star prefab
    [SerializeField] private int MaxBlocks = 1; //the maximum number of stars

    [SerializeField] private GameObject Prefab_X_Blok; //this is our star prefab
    [SerializeField] private int Max_X_Blocks = 1; //the maximum number of stars

    [SerializeField] private GameObject Prefab_T_Blok; //this is our star prefab
    [SerializeField] private int Max_T_Blocks = 1; //the maximum number of stars

    [SerializeField] private GameObject Prefab_Driehoek_Blok; //this is our star prefab
    [SerializeField] private int Max_Prefab_Driehoek_Blocks = 1; //the maximum number of stars

    private Color[] blokcolors =
   {
        new Color (0.5f, 0.5f, 1f),  //blue
        new Color (0, 1f, 1f),       //green
        new Color (1f, 1f, 0),       //yellow
        new Color (1f, 0, 0),        //red
        new Color (255f, 0, 51)      //crimson red/purple
    };

    private void Start()
    {
        //this is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //this is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        MaxBlocks = Random.Range(3, 10);
        Max_X_Blocks = Random.Range(3, 6);
        Max_T_Blocks = Random.Range(3, 6);
        Max_Prefab_Driehoek_Blocks = Random.Range(3, 6);

        //loop to create the stars
        for (int i = 0; i < MaxBlocks; ++i)
        {
            GameObject blok = (GameObject)Instantiate(Prefab_Blok);

            //set the star color
            blok.GetComponent<SpriteRenderer>().color = blokcolors[i % blokcolors.Length];

            //set the position of the star (random x and random y)
            blok.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            //set a random speed for the star
            //blok.GetComponent<Blok>().BlokMovementSpeed = -(1f * Random.value + 0.5f);

            //make the star a child of the Star_Generator
            blok.transform.parent = transform;
        }

        for (int i = 0; i < Max_X_Blocks; ++i)
        {
            GameObject x_blok = (GameObject)Instantiate(Prefab_X_Blok);

            //set the star color
            x_blok.GetComponent<SpriteRenderer>().color = blokcolors[i % blokcolors.Length];

            //set the position of the star (random x and random y)
            x_blok.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            //set a random speed for the star
            //x_blok.GetComponent<Blok>().BlokMovementSpeed = -(1f * Random.value + 0.5f);

            //make the star a child of the Star_Generator
            x_blok.transform.parent = transform;
        }

        for (int i = 0; i < Max_Prefab_Driehoek_Blocks; ++i)
        {
            GameObject t_blok = (GameObject)Instantiate(Prefab_T_Blok);

            //set the star color
            t_blok.GetComponent<SpriteRenderer>().color = blokcolors[i % blokcolors.Length];

            //set the position of the star (random x and random y)
            t_blok.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            //set a random speed for the star
            //t_blok.GetComponent<Blok>().BlokMovementSpeed = -(1f * Random.value + 0.5f);

            //make the star a child of the Star_Generator
            t_blok.transform.parent = transform;
        }

        for (int i = 0; i < Max_T_Blocks; ++i)
        {
            GameObject driehoek_blok = (GameObject)Instantiate(Prefab_Driehoek_Blok);

            //set the star color
            driehoek_blok.GetComponent<SpriteRenderer>().color = blokcolors[i % blokcolors.Length];

            //set the position of the star (random x and random y)
            driehoek_blok.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            //set a random speed for the star
            //driehoek_blok.GetComponent<Blok>().BlokMovementSpeed = -(1f * Random.value + 0.5f);

            //make the star a child of the Star_Generator
            driehoek_blok.transform.parent = transform;
        }
    }
}