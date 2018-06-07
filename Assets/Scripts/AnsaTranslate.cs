using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnsaTranslate : MonoBehaviour
{
    public float moveSpeed = 50f;

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
	}
}
