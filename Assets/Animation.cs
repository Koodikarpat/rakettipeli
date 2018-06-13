using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour {

    public void OnAnimationEnd()
    {
        transform.Find("BossActivation").GetComponent<BossActivate>().OnAnimationEnd();
    }
}
