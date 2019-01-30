using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerChecker : MonoBehaviour
{
    [SerializeField] private GameObject Player_1;
    [SerializeField] private GameObject Player_2;
    [SerializeField] private GameObject Player_3;
    [SerializeField] private GameObject Player_4;

    [SerializeField] private XboxController playerNumber_1;
    [SerializeField] private XboxController playerNumber_2;
    [SerializeField] private XboxController playerNumber_3;
    [SerializeField] private XboxController playerNumber_4;

    [SerializeField] private GameObject Player_1_Text;
    [SerializeField] private GameObject Player_1_Start_Symbol;

    [SerializeField] private GameObject Player_2_Text;
    [SerializeField] private GameObject Player_2_Start_Symbol;

    [SerializeField] private GameObject Player_3_Text;
    [SerializeField] private GameObject Player_3_Start_Symbol;

    [SerializeField] private GameObject Player_4_Text;
    [SerializeField] private GameObject Player_4_Start_Symbol;

    [SerializeField] private Player_RespawnSystem P_Respawn;

    public int HowmanyPlayers = 0;
    private bool Player_1_checked_in, Player_2_checked_in, Player_3_checked_in, Player_4_checked_in;

    private void Update()
    {
        // voor player 1

        if (XCI.GetButtonDown(XboxButton.Start, playerNumber_1) && playerNumber_1 == XboxCtrlrInput.XboxController.First && Player_1_checked_in == false || Input.GetKeyDown(KeyCode.A) && playerNumber_1 == XboxCtrlrInput.XboxController.First && Player_1_checked_in == false)
        {
            Player_1.SetActive(true);
            HowmanyPlayers += 1;
            Player_1_checked_in = true;
            Player_1_Start_Symbol.SetActive(false);
            Player_1_Text.SetActive(false);
            P_Respawn.GetComponent<Player_RespawnSystem>().P1_IsPlaying = true;
        }

        // voor player 2

        if (XCI.GetButtonDown(XboxButton.Start, playerNumber_2) && playerNumber_2 == XboxCtrlrInput.XboxController.Second && Player_2_checked_in == false || Input.GetKeyDown(KeyCode.S) && playerNumber_2 == XboxCtrlrInput.XboxController.Second && Player_2_checked_in == false)
        {
            Player_2.SetActive(true);
            HowmanyPlayers += 1;
            Player_2_checked_in = true;
            Player_2_Start_Symbol.SetActive(false);
            Player_2_Text.SetActive(false);
            P_Respawn.GetComponent<Player_RespawnSystem>().P2_IsPlaying = true;
        }

        // voor player 3

        if (XCI.GetButtonDown(XboxButton.Start, playerNumber_3) && playerNumber_3 == XboxCtrlrInput.XboxController.Third && Player_3_checked_in == false || Input.GetKeyDown(KeyCode.D) && playerNumber_3 == XboxCtrlrInput.XboxController.Third && Player_3_checked_in == false)
        {
            Player_3.SetActive(true);
            HowmanyPlayers += 1;
            Player_3_checked_in = true;
            Player_3_Start_Symbol.SetActive(false);
            Player_3_Text.SetActive(false);
            P_Respawn.GetComponent<Player_RespawnSystem>().P3_IsPlaying = true;
        }

        // voor player 4

        if (XCI.GetButtonDown(XboxButton.Start, playerNumber_4) && playerNumber_4 == XboxCtrlrInput.XboxController.Fourth && Player_4_checked_in == false || Input.GetKeyDown(KeyCode.W) && playerNumber_4 == XboxCtrlrInput.XboxController.Fourth && Player_4_checked_in == false)
        {
            Player_4.SetActive(true);
            HowmanyPlayers += 1;
            Player_4_checked_in = true;
            Player_4_Start_Symbol.SetActive(false);
            Player_4_Text.SetActive(false);
            P_Respawn.GetComponent<Player_RespawnSystem>().P4_IsPlaying = true;
        }
    }
}