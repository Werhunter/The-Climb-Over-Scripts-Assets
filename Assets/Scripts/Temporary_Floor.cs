using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporary_Floor : MonoBehaviour
{
    private float timer = 0f;
    private bool starttimer = false;

    [SerializeField] private GameObject Temp_Floor;
    [SerializeField] private float DeathTime = 5f;

    private void Start()
    {
        starttimer = true;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= DeathTime)
        {
            Temp_Floor.gameObject.SetActive(false);
        }
    }
}