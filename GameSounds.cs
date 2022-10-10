using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSounds : MonoBehaviour
{
    public AudioSource gameMusic;
    public AudioSource endMusic;

    public bool gameSong = true;
    public bool endSong = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameMusic()
    {
        if(endMusic.isPlaying)
        gameSong = true;
        endSong = false;
        {
            endMusic.Stop();
            gameMusic.Play();
        }
        
    }

    public void EndMusic()
    {
        if (gameMusic.isPlaying)
            gameSong = false;
        {
            gameMusic.Stop();
        }
        if(!endMusic.isPlaying && endSong == false)
        {
            endMusic.Play();
            endSong = true;
        }
    }
}
