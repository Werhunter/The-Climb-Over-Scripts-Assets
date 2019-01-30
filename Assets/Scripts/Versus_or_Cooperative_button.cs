using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Versus_or_Cooperative_button : MonoBehaviour
{
    [SerializeField] private XboxController playerNumber;
    [SerializeField] private Player_RespawnSystem RespawnSystem;
    [SerializeField] private WinTracker wintrack;
    [SerializeField] private PlayerChecker playercheck;

    [SerializeField] private GameObject Timer;
    [SerializeField] private GameObject Cooperative_Button;
    [SerializeField] private GameObject Versus_Button;
    [SerializeField] private GameObject StartGame;
    [SerializeField] private GameObject Temporary_Floor_Script;

    [SerializeField] private GameObject NotEnoughPlayersText;

    [SerializeField] private GameObject Player_1_Text;
    [SerializeField] private GameObject Player_1_Start_Symbol;

    [SerializeField] private GameObject Player_2_Text;
    [SerializeField] private GameObject Player_2_Start_Symbol;

    [SerializeField] private GameObject Player_3_Text;
    [SerializeField] private GameObject Player_3_Start_Symbol;

    [SerializeField] private GameObject Player_4_Text;
    [SerializeField] private GameObject Player_4_Start_Symbol;

    [SerializeField] private GameObject player_checker;

    private void Update()
    {
        if (XCI.GetButtonDown(XboxButton.DPadRight, playerNumber)) //start coop
        {
            Game_Is_Cooperative();
        }

        if (XCI.GetButtonDown(XboxButton.DPadLeft, playerNumber)) //start versus
        {
            Game_Is_Versus();
        }
    }

    public void Game_Is_Cooperative()
    {
        if (playercheck.HowmanyPlayers >= 1)
        {
            NotEnoughPlayersText.SetActive(false);
            wintrack.Game_Is_Cooperative = true;
            RespawnSystem.Game_Is_Cooperative = true;
            Cooperative_Button.SetActive(false);
            Versus_Button.SetActive(false);
            StartGame.SetActive(true);
            Timer.SetActive(true);
            Temporary_Floor_Script.SetActive(true);
            player_checker.SetActive(false);

            Player_1_Text.SetActive(false);
            Player_1_Start_Symbol.SetActive(false);
            Player_2_Text.SetActive(false);
            Player_2_Start_Symbol.SetActive(false);
            Player_3_Text.SetActive(false);
            Player_3_Start_Symbol.SetActive(false);
            Player_4_Text.SetActive(false);
            Player_4_Start_Symbol.SetActive(false);
        }
        else
        {
            NotEnoughPlayersText.SetActive(true);
        }
    }

    public void Game_Is_Versus()
    {
        if (playercheck.HowmanyPlayers >= 2)
        {
            NotEnoughPlayersText.SetActive(false);
            wintrack.Game_Is_Versus = true;
            Cooperative_Button.SetActive(false);
            Versus_Button.SetActive(false);
            StartGame.SetActive(true);
            Timer.SetActive(true);
            Temporary_Floor_Script.SetActive(true);
            player_checker.SetActive(false);

            Player_1_Text.SetActive(false);
            Player_1_Start_Symbol.SetActive(false);
            Player_2_Text.SetActive(false);
            Player_2_Start_Symbol.SetActive(false);
            Player_3_Text.SetActive(false);
            Player_3_Start_Symbol.SetActive(false);
            Player_4_Text.SetActive(false);
            Player_4_Start_Symbol.SetActive(false);
        }
        else
        {
            NotEnoughPlayersText.SetActive(true);
        }
    }
}