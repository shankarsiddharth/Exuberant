using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenHandler : MonoBehaviour
{
    public GameObject gameName;
    public GameObject startButton;
    public GameObject introText, tutorialPanel;
    public GameObject grabbableObject, bench;

    private void Start()
    {
        startButton.SetActive(true);
        tutorialPanel.SetActive(false);
        introText.SetActive(false);
        gameName.GetComponent<Animator>().enabled = false;
        introText.GetComponent<Animator>().enabled = false;
        grabbableObject.SetActive(false);
        bench.SetActive(false);
    }
    public void PlayPressed()
    {
        Debug.Log("play pressed....");
        introText.SetActive(true);
        gameName.GetComponent<Animator>().enabled = true;
        introText.GetComponent<Animator>().enabled = true;
        startButton.SetActive(false);
    }

    public void StartPressed()
    {
        Debug.Log("start pressed....");
        introText.SetActive(false);
        startButton.SetActive(false);    
        grabbableObject.SetActive(true);
        bench.SetActive(true);
        tutorialPanel.SetActive(true);
    }

    private void Update()
    {
        if(OVRInput.Get(OVRInput.Button.One))
        {       
                PlayPressed();
           
        }

        if (OVRInput.Get(OVRInput.Button.Three))
        {
            StartPressed();
        }


    }
}
