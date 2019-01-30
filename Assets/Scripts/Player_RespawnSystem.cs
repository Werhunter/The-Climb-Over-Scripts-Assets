using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_RespawnSystem : MonoBehaviour
{
    public bool Game_Is_Cooperative = false;

    [SerializeField] private float PlayerRespawnTime = 10f;
    [SerializeField] private WinTracker wintrack;

    public bool P1_IsPlaying = false;
    [SerializeField] private GameObject player_1;
    private float P1_DeathTimer = 0f;
    private bool P1_DeathTimeActivator = false;

    public bool P2_IsPlaying = false;
    [SerializeField] private GameObject player_2;
    private float P2_DeathTimer = 0f;
    private bool P2_DeathTimeActivator = false;

    public bool P3_IsPlaying = false;
    [SerializeField] private GameObject player_3;
    private float P3_DeathTimer = 0f;
    private bool P3_DeathTimeActivator = false;

    public bool P4_IsPlaying = false;
    [SerializeField] private GameObject player_4;
    private float P4_DeathTimer = 0f;
    private bool P4_DeathTimeActivator = false;

    private void Update()
    {
        if (Game_Is_Cooperative == true)
        {
            Cooperative();
        }

        print("p1 = " + P1_IsPlaying);
        print("p2 = " + P2_IsPlaying);
        print("p3 = " + P3_IsPlaying);
        print("p4 = " + P4_IsPlaying);
    }

    private void Cooperative()
    {
        //this is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //this is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // player 1

        if (P1_IsPlaying == true)
        {
            if (player_1.activeSelf == false)
            {
                P1_DeathTimeActivator = true;
            }

            if (P1_DeathTimeActivator == true)
            {
                P1_DeathTimer += Time.deltaTime;
                print("P1 Death timer =" + P1_DeathTimer);
            }

            if (P1_DeathTimer >= PlayerRespawnTime)
            {
                player_1.SetActive(true);
                wintrack.DeathCount -= 1;
                player_1.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
                P1_DeathTimeActivator = false;
                P1_DeathTimer = 0f;
            }
        }

        // player 2
        if (P2_IsPlaying == true)
        {
            if (player_2.activeSelf == false)
            {
                P2_DeathTimeActivator = true;
            }

            if (P2_DeathTimeActivator == true)
            {
                P2_DeathTimer += Time.deltaTime;
            }

            if (P2_DeathTimer >= PlayerRespawnTime)
            {
                player_2.SetActive(true);
                player_2.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
                P2_DeathTimeActivator = false;
                P2_DeathTimer = 0f;
            }
        }
        // player 3
        if (P3_IsPlaying == true)
        {
            if (player_3.activeSelf == false)
            {
                P3_DeathTimeActivator = true;
            }

            if (P3_DeathTimeActivator == true)
            {
                P3_DeathTimer += Time.deltaTime;
            }

            if (P3_DeathTimer >= PlayerRespawnTime)
            {
                player_3.SetActive(true);
                player_3.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
                P3_DeathTimeActivator = false;
                P3_DeathTimer = 0f;
            }
        }
        // player 4
        if (P4_IsPlaying == true)
        {
            if (player_4.activeSelf == false)
            {
                P4_DeathTimeActivator = true;
            }

            if (P4_DeathTimeActivator == true)
            {
                P4_DeathTimer += Time.deltaTime;
            }

            if (P4_DeathTimer >= PlayerRespawnTime)
            {
                player_4.SetActive(true);
                player_4.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
                P4_DeathTimeActivator = false;
                P4_DeathTimer = 0f;
            }
        }
    }
}