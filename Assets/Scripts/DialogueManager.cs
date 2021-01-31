using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public AudioSource          docSource;
    public AudioClip[]          doctorDialogues;
    public PlayerResponses[]    playerResponses;

    [Header("GUI references")]
    public Button               choice1;
    public Button               choice2;
    public TextMeshProUGUI      singleResponse;

    private bool                m_IsDocSpeaking = false;
    private int                 m_DialogueCount = 0;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Dialog count is :" + m_DialogueCount);

        if (m_DialogueCount >= 7)
        {
            // Load the next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        docSource.clip = doctorDialogues[m_DialogueCount];
        if (!m_IsDocSpeaking)
        {
            docSource.Play();
            m_IsDocSpeaking = true;

            // Clear everything while the doc is speaking
            choice1.GetComponentInChildren<TextMeshProUGUI>().text = "";
            choice2.GetComponentInChildren<TextMeshProUGUI>().text = "";
            singleResponse.text = "";
        }

        if (!docSource.isPlaying)
        {
            // Wait for the players response only if he doesn't have single response
            if (!playerResponses[m_DialogueCount].isSingleResponse)
            {
                choice1.GetComponentInChildren<TextMeshProUGUI>().text = playerResponses[m_DialogueCount].Choice1;
                choice2.GetComponentInChildren<TextMeshProUGUI>().text = playerResponses[m_DialogueCount].choice2;
            }
            else
            {
                choice1.GetComponentInChildren<TextMeshProUGUI>().text = "";
                choice2.GetComponentInChildren<TextMeshProUGUI>().text = "";
                singleResponse.text = playerResponses[m_DialogueCount].Choice1;

                StartCoroutine("NextDialogue");
            }
        }

    }
    
    public void Choice1Selected()
    {
        if (!docSource.isPlaying)
        { 
            m_IsDocSpeaking = false;
            m_DialogueCount++;
        }
    }

    public void Choice2Selected()
    {
        if (!docSource.isPlaying)
        {
            m_IsDocSpeaking = false;
            m_DialogueCount++;
        }
    }

    IEnumerator NextDialogue()
    {
        yield return new WaitForSeconds(3.0f);
        m_IsDocSpeaking = false;
        m_DialogueCount++;
    }

}
