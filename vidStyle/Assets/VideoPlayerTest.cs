using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerTest : MonoBehaviour
{
    public VideoClip[] videoClip;
    private VideoPlayer vp;
    private int currentClipIndex = 0;

    private void Start()
    {
        //vp = GetComponent<VideoPlayer>();
        //vp.loopPointReached += OnMovieFinished;
        vp.clip = videoClip[currentClipIndex];

        vp.playOnAwake = false;
        vp.isLooping = false;

        vp.Pause();
    }

    private void Update()
    {
        Debug.Log(vp.targetCameraAlpha);

    }
}
