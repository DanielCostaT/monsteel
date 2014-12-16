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
        currentAnimation =  HOTween.GetTweensById("P1Q1", true);
        nextAnimation = HOTween.GetTweensById("P1Q2", true);

        nextAnimation.ForEach(i => i.Play());
        currentAnimation.ForEach(i => i.Play());
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A)) {
            currentAnimation.ForEach(i => i.Play());

        }
	}

    void PauseNextTweens () {
        nextAnimation.ForEach(i => i.Pause());
    }
}
