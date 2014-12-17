// Class to trigger audios through HOTween

using UnityEngine;
using System.Collections;

[RequireComponent(typeof (AudioSource))]
public class TweenAudio : MonoBehaviour {
    
    AudioSource mySource;
    AudioSource MySource {
        get {
            if (mySource == null) {
                mySource = GetComponent<AudioSource>();
            }
            return mySource;
        }
    }

    public void Play () {
        Debug.Log("Playing audio...");
        MySource.Play();
    }

    void Stop () {
        MySource.Stop();
    }
}
