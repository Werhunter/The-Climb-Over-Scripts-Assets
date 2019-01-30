using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;

public class Load_Scene : MonoBehaviour
{
    [SerializeField] private string scene;
    [SerializeField] private XboxController playerNumber;

    private void Update()
    {
        if (XCI.GetButtonDown(XboxButton.DPadUp, playerNumber)) //start coop
        {
            GameStart_OnButtonClick();
        }
    }

    public void GameStart_OnButtonClick()
    {
        SceneManager.LoadScene(scene);
    }
}