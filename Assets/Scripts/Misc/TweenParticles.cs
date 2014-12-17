using UnityEngine;
using System.Collections;

public class TweenParticles : MonoBehaviour {

    ParticleSystem mySource;
    ParticleSystem MySource {
        get {
            if (mySource == null) {
                mySource = GetComponent<ParticleSystem>();
            }
            return mySource;
        }
    }


    public void Play () {
        Debug.Log("Playing particle system...");
        MySource.Play();
    }
}
