using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using System.Collections.Generic;

public class TestGroupTweenByID : MonoBehaviour {

    List<IHOTweenComponent> currentAnimation;
    List<IHOTweenComponent> nextAnimation;
    List<IHOTweenComponent> allAnimation;

	// Use this for initialization
    void Start () {
        allAnimation = HOTween.GetAllTweens();
        currentAnimation = HOTween.GetTweensById("P1Q1", true);
        nextAnimation = HOTween.GetTweensById("P1Q2", true);

        StartPage1();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 2) {
            if (Input.GetTouch(2).phase == TouchPhase.Began) {
                StartPage1();
            }
        }
	}

    void StartPage1 () {
        nextAnimation.ForEach(i => i.Rewind());
        currentAnimation.ForEach(i => i.Rewind());
        nextAnimation.ForEach(i => i.Play());
        currentAnimation.ForEach(i => i.Play());
    }

    void PauseNextTweens () {
        nextAnimation.ForEach(i => i.Pause());
    }
}
