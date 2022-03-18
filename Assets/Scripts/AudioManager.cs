using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AudioManager : MonoBehaviour
{
    public AudioClip[] songs;
    private AudioSource audioManagerSource;

    //Variable que guarda la can�o que sona
    private int playingSong;

    //Variable per accedir al text
    public TextMeshProUGUI songTitle;
    //Array per tenir els noms de les can�ons
    public string[] nameSong;

    
    void Start()
    {
        audioManagerSource = GetComponent<AudioSource>();
        audioManagerSource.PlayOneShot(songs[playingSong]);
    }

    void Update()
    {
        //feim que el tit�l de la can�o que sona surti
        songTitle.text = nameSong[playingSong];
    }

    //Funci� per pausar la can�o
    public void pauseSong()
    {
        audioManagerSource.Pause();
    }

    //Funci� per reaunadar la can�o
    public void playSong()
    {
        audioManagerSource.UnPause();
    }

    //Funci� per passar de can�o
    public void nextSong()
    {
        //Sona la seguent
        playingSong++;
        //Si ens passam torna al principi
        if (playingSong >= songs.Length)
        {
            playingSong = 0;
        }
        //Aturam la can�o que sona
        audioManagerSource.Stop();
        //Feim que soni la can�o que toca
        audioManagerSource.PlayOneShot(songs[playingSong], 1f);
    }

    //Funci� per anar una can�o enrrera
    public void previousSong()
    {
        //Sona la anterior
        playingSong--;
        //Si ens passam torna al final
        if (playingSong < songs.Length)
        {
            playingSong = songs.Length - 1;
        }
        //Aturam la can�o que sona
        audioManagerSource.Stop();
        //Feim que soni la can�o que toca
        audioManagerSource.PlayOneShot(songs[playingSong]);
    }


    //Funci� per anar una can�o aleatoria
    public void randomSong()
    {
        //Aturam la can�o que sona
        audioManagerSource.Stop();
        //Triam una can�o random
        playingSong = Random.Range(0, songs.Length);
        //Feim que soni la can�o que toca
        audioManagerSource.PlayOneShot(songs[playingSong]);
    }

}

   
