﻿using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class TweenInteractionTrigger : MonoBehaviour {
    void OnClick () {
        TestGroupTweenByID.instance.OnButtonClick(gameObject.name);
    }
}
