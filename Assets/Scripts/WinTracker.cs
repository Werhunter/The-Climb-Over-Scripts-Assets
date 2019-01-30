using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTracker : MonoBehaviour
{
    public bool Game_Is_Cooperative = false;
    public bool Game_Is_Versus = false;

    [SerializeField] private GameObject Player_1;
    [SerializeField] private GameObject Player_2;
    [SerializeField] private GameObject Player_3;
    [SerializeField] private GameObject Player_4;

    [SerializeField] private GameObject Player_RespawnSystem;
    [SerializeField] private GameObject Lose_Text;
    [SerializeField] private Timer timer;
    [SerializeField] private GameObject Main_Camera_Movement_Script;

    [SerializeField] private GameObject RestartButton;

    [SerializeField] private GameObject Player_1_Has_Won_Text;
    [SerializeField] private GameObject Player_2_Has_Won_Text;
    [SerializeField] private GameObject Player_3_Has_Won_Text;
    [SerializeField] private GameObject Player_4_Has_Won_Text;

    [SerializeField] private PlayerChecker Player_checker;

    public int DeathCount = 0;
    private int DeathAmmount = 0;
    private int current_Coop_Player_Ammount = 2;

    private void Start()
    {
        DeathCount = 0;
    }

    private void Update()
    {
        if (Game_Is_Cooperative == true)
        {
            if (Player_checker.HowmanyPlayers == 1)
            {
                DeathAmmount = 0;
                Cooperative();
            }

            if (Player_checker.HowmanyPlayers > 2)
            {
                DeathAmmount = 1;
                Cooperative();
            }
        }

        if (Game_Is_Versus == true)
        {
            Versus();
        }
    }

    private void Cooperative()
    {
        if (DeathCount >= Player_checker.HowmanyPlayers - DeathAmmount)
        {
            timer.TimerIsactive = false;
            Player_RespawnSystem.SetActive(false);
            Lose_Text.SetActive(true);
            Main_Camera_Movement_Script.SetActive(false);
            RestartButton.SetActive(true);
            // de game is over en je stopt de score timer met tellen
        }
    }

    private void Versus()
    {
        print(Player_checker.HowmanyPlayers);

        if (DeathCount > Player_checker.HowmanyPlayers - 2)
        {
            if (Player_1.activeSelf == true)
            {
                Player_1_Has_Won_Text.SetActive(true);
                timer.TimerIsactive = false;
                Main_Camera_Movement_Script.SetActive(false);
                RestartButton.SetActive(true);
            }

            if (Player_2.activeSelf == true)
            {
                Player_2_Has_Won_Text.SetActive(true);
                timer.TimerIsactive = false;
                RestartButton.SetActive(true);
                Main_Camera_Movement_Script.SetActive(false);
            }

            if (Player_3.activeSelf == true)
            {
                Player_3_Has_Won_Text.SetActive(true);
                Main_Camera_Movement_Script.SetActive(false);
                timer.TimerIsactive = false;
                RestartButton.SetActive(true);
            }

            if (Player_4.activeSelf == true)
            {
                Player_4_Has_Won_Text.SetActive(true);
                Main_Camera_Movement_Script.SetActive(false);
                timer.TimerIsactive = false;
                RestartButton.SetActive(true);
            }
        }
    }
}