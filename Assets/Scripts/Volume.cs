using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    [SerializeField] Material onMaterial;
    [SerializeField] Material offMaterial;
    //[SerializeField] float volChangeSpeed;
    //[SerializeField] float coolDown = 5f;

    Renderer[] volumeBars;
    //AudioSource source;
    float currentVolume;
    //bool volUp = false;
    //float volDownTime;

    VideoManager videoManager;

    // Start is called before the first frame update
    void Start()
    {
        //source = GetComponent<AudioSource>();
        volumeBars = GetComponentsInChildren<Renderer>();
        videoManager = FindObjectOfType<VideoManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gère l'affichage des barres de volumes en fonction du volume de la vidéo
        currentVolume = Mathf.Floor(videoManager.player.GetDirectAudioVolume(0) * volumeBars.Length);

        for (int i = 0; i < volumeBars.Length; i++)
        {
            if (i < currentVolume) volumeBars[i].material = onMaterial;
            else volumeBars[i].material = offMaterial;
        }

        //if (!volUp) audioManager.VolUpVideoPlayer(-volChangeSpeed * Time.deltaTime);//source.volume -= volChangeSpeed * Time.deltaTime;
        //else if (volUp) audioManager.VolUpVideoPlayer(volChangeSpeed * Time.deltaTime);//source.volume += volChangeSpeed * Time.deltaTime;

        //if (Time.time >= volDownTime)
        //{
        //    volUp = false;
        //}
    }

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    volUp = true;
    //    volDownTime = Time.time + coolDown;
    //}

}
