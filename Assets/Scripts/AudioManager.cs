using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AudioManager : MonoBehaviour
{
    public AudioClip[] songs;
    private AudioSource audioManagerSource;

    //Variable que guarda la canço que sona
    private int playingSong;

    //Variable per accedir al text
    public TextMeshProUGUI songTitle;
    //Array per tenir els noms de les cançons
    public string[] nameSong;

    
    void Start()
    {
        audioManagerSource = GetComponent<AudioSource>();
        audioManagerSource.PlayOneShot(songs[playingSong]);
    }

    void Update()
    {
        //feim que el titól de la canço que sona surti
        songTitle.text = nameSong[playingSong];
    }

    //Funció per pausar la canço
    public void pauseSong()
    {
        audioManagerSource.Pause();
    }

    //Funció per reaunadar la canço
    public void playSong()
    {
        audioManagerSource.UnPause();
    }

    //Funció per passar de canço
    public void nextSong()
    {
        //Sona la seguent
        playingSong++;
        //Si ens passam torna al principi
        if (playingSong >= songs.Length)
        {
            playingSong = 0;
        }
        //Aturam la canço que sona
        audioManagerSource.Stop();
        //Feim que soni la canço que toca
        audioManagerSource.PlayOneShot(songs[playingSong], 1f);
    }

    //Funció per anar una canço enrrera
    public void previousSong()
    {
        //Sona la anterior
        playingSong--;
        //Si ens passam torna al final
        if (playingSong < songs.Length)
        {
            playingSong = songs.Length - 1;
        }
        //Aturam la canço que sona
        audioManagerSource.Stop();
        //Feim que soni la canço que toca
        audioManagerSource.PlayOneShot(songs[playingSong]);
    }


    //Funció per anar una canço aleatoria
    public void randomSong()
    {
        //Aturam la canço que sona
        audioManagerSource.Stop();
        //Triam una canço random
        playingSong = Random.Range(0, songs.Length);
        //Feim que soni la canço que toca
        audioManagerSource.PlayOneShot(songs[playingSong]);
    }

}

   
