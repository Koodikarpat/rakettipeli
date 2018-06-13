using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vihollinen : MonoBehaviour
{
    public GameObject ammus;
    public Transform ammusLahtee;
    float aika;

    private void Update()
    {
        /*aika = aika + Time.deltaTime;
        if (aika > 1f)
        {
            Ammu();
            aika = 0f;
        }*/
    }

    public void Ammu()
    {
        Instantiate(ammus, ammusLahtee.position, ammusLahtee.rotation);
    }
}
