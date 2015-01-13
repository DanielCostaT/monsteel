using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using System.Collections.Generic;

public class TestGroupTweenByID : Singleton<TestGroupTweenByID> {

    List<IHOTweenComponent> currentAnimation;
    List<IHOTweenComponent> nextAnimation;
    List<IHOTweenComponent> spiderAppear;
    List<IHOTweenComponent> spiderHides;
    List<IHOTweenComponent> spiderPlays;

    GameObject Spider;
    public AudioSource SpiderMasterSFX;
    public AudioClip SpiderAppearSFX;
    public AudioClip SpiderHideSFX;

    enum SpiderState {
        Hidden,
        Idle,
        Scared
    }
    SpiderState currentSpiderState;

	// Use this for initialization
    void Start () {
        SetupSpider();
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
        if (Input.GetKeyDown(KeyCode.A)) {
            StartSpider();
        }
	}

    void StartPage1 () {
        nextAnimation.ForEach(i => i.Rewind());
        currentAnimation.ForEach(i => i.Rewind());
        nextAnimation.ForEach(i => i.Play());
        currentAnimation.ForEach(i => i.Play());
    }

    void SetupSpider () {
        spiderAppear = HOTween.GetTweensById("SpiderAppear", true);
        spiderHides = HOTween.GetTweensById("SpiderHides", true);
        spiderPlays = HOTween.GetTweensById("SpiderPlays", true);
        Spider = GameObject.Find("SpiderWeb");
        Spider.SetActive(false);
        currentSpiderState = SpiderState.Hidden;
    }

    void StartSpider () {
        Invoke("TimedSpider", 5.0f);
    }

    void TimedSpider () {
        Spider.SetActive(true);
        SetSpecialAnimation(SpiderState.Hidden);
    }

    void SetSpecialAnimation (SpiderState nextState) {
        currentSpiderState = nextState;

        StartCoroutine(SpecialAnimation());
    }

    IEnumerator SpecialAnimation () {
        switch (currentSpiderState) {
            case SpiderState.Hidden:
                spiderAppear.ForEach(i => i.Rewind());
                spiderAppear.ForEach(i => i.Play());
                SpiderMasterSFX.PlayOneShot(SpiderAppearSFX);
                yield return new WaitForSeconds(3.0f);
                SetSpecialAnimation(SpiderState.Idle);
                break;
            case SpiderState.Idle:
                while (currentSpiderState == SpiderState.Idle) {
                    spiderPlays.ForEach(i => i.Rewind());
                    spiderPlays.ForEach(i => i.Play());
                    yield return new WaitForSeconds(6.0f);                
                }
                break;
            case SpiderState.Scared:
                spiderPlays.ForEach(i => i.Pause());
                spiderHides.ForEach(i => i.Rewind());
                spiderHides.ForEach(i => i.Play());
                SpiderMasterSFX.PlayOneShot(SpiderHideSFX);
                yield return new WaitForSeconds(6.0f);
                SetSpecialAnimation(SpiderState.Hidden);
                break;
        }
    }

    void PauseNextTweens () {
        nextAnimation.ForEach(i => i.Pause());
    }

    public void OnButtonClick (string button) {
        switch (button) {
		    case "SmokeFXInteraction":
				nextAnimation.ForEach(i => i.Play());
				currentAnimation.ForEach(i => i.Play());
                break;
            case "SpiderBody":
                if (currentSpiderState == SpiderState.Idle) {
                    SetSpecialAnimation(SpiderState.Scared);
                }
                break;
            default:
                break;
        }
    }
}
