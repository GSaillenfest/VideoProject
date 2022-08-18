using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class VideoManager : MonoBehaviour
{
    [SerializeField] public VideoPlayer player;
    public float remplissageFinal = 0;
    public int currentCpIndex = 0;
    public int checkpoints = 0;

    Remplissage remplissage;
    bool isPlaying = false;
    int endFrame = 0;

    //AudioSource[] audioSources;

    // Start is called before the first frame update
    void Start()
    {
        //audioSources = FindObjectsOfType<AudioSource>();
        //foreach(AudioSource source in audioSources)
        //{
        //    //source.Play();
        //}
        remplissage = FindObjectOfType<Remplissage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCpIndex > checkpoints)
        {
            remplissageFinal = remplissage.compteur / 100;
            VolUpVideoPlayer();
            if (!isPlaying)
            {
                player.frame = 45;
                player.isLooping = true;
                player.Play();
                isPlaying = true;
            }
        }
        else
        {
            if (player.frame > endFrame)
            {
                player.SetDirectAudioVolume(0, 0f);
                player.targetCameraAlpha = 0f;
                player.Stop();
                currentCpIndex++;
            }
        }
    }

    //void VolUpVideoPlayer(float volChangeSpeed)
    //{
    //    if (player.GetDirectAudioVolume(0) > 0 && volChangeSpeed < 0)
    //    {
    //        volumeVideo += volChangeSpeed * 1.5f;
    //        player.SetDirectAudioVolume(0, volumeVideo);
    //        player.targetCameraAlpha = player.GetDirectAudioVolume(0);
    //    }
    //    else if (player.GetDirectAudioVolume(0) < 1 && volChangeSpeed > 0)
    //    {
    //        volumeVideo += volChangeSpeed;
    //        player.SetDirectAudioVolume(0, volumeVideo);
    //        player.targetCameraAlpha = player.GetDirectAudioVolume(0);
    //    }

    // la video se dévoile en fonction du remplissage de la boite
    void VolUpVideoPlayer()
    {
        player.SetDirectAudioVolume(0, remplissageFinal);
        player.targetCameraAlpha = remplissageFinal;
    }

    public void PlayVideoPart(int startFrame, int newEndFrame)
    {
        endFrame = newEndFrame;
        player.SetDirectAudioVolume(0, 0.2f);
        player.targetCameraAlpha = 0.2f;
        player.frame = startFrame;
        player.Play();
    }
}
