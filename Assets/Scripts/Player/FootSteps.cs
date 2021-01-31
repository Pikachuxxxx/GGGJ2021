using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public float stepRate = 0.5f;
    public float stepCoolDown;
    public AudioClip[] footSteps;


    // Update is called once per frame
    void Update()
    {
        stepCoolDown -= Time.deltaTime;
        if ((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && stepCoolDown < 0f)
        {
            GetComponent<AudioSource>().pitch = 1f + Random.Range(-0.2f, 0.2f);
            GetComponent<AudioSource>().PlayOneShot(footSteps[Random.Range(0, footSteps.Length)], 0.9f);
            stepCoolDown = stepRate;
        }
    }
}
