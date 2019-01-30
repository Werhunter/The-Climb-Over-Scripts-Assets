using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit_Game : MonoBehaviour
{
    public void OnButtonClick()
    {
#if UNITY_EDITOR
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
#endif

        Application.Quit();
    }
}