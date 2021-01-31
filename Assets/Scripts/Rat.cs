using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public AudioSource ratSource;
    public float squeakingFrequency = 2.0f;

    private float[] RatSpeeds = {-5.0f, -6.0f, -7.0f};

    private Rigidbody m_RatRB;
    private float m_CurrentSqueakTime = 0;


    void Start()
    {
        m_RatRB = gameObject.GetComponent<Rigidbody>();
        Destroy(gameObject, 25.0f);
    }

    void Update()
    {

        squeakingFrequency = Random.Range(2, 8);

        if(m_CurrentSqueakTime > squeakingFrequency)
        {
            ratSource.Play();
            m_CurrentSqueakTime = 0.0f;
        }
        m_CurrentSqueakTime += Time.deltaTime;

        m_RatRB.velocity = new Vector3(RatSpeeds[Random.Range(0, RatSpeeds.Length - 1)] * 100.0f * Time.deltaTime, 0.0f, 0.0f);
    }
}
