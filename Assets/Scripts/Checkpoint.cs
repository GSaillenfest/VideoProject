using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] int startFrame;
    [SerializeField] int endFrame;
    [SerializeField] int cpIndex;

    int count = 0;
    VideoManager videoManager;

    float chrono;
    float coolDown = 0.4f;


    // Start is called before the first frame update
    void Start()
    {
        videoManager = FindObjectOfType<VideoManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > chrono) count = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        chrono = Time.time + coolDown;
        if (cpIndex == videoManager.currentCpIndex) count++;
        if (count > 20)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
            videoManager.PlayVideoPart(startFrame, endFrame);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
