﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    

    private void Awake()
    {
        int numberOfMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

        if (numberOfMusicPlayers > 1)
        {

            Destroy(gameObject);

        }
        else
        {
            DontDestroyOnLoad(this);


        }
    }

    // Update is called once per frame
   
}
