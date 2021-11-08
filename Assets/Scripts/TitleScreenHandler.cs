using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenHandler : MonoBehaviour
{
    public GameObject gameName;
    public GameObject playButton, startButton;
    public GameObject introText, tutorialPanel;
    public GameObject grabbableObject, bench;

    private void Start()
    {
        startButton.SetActive(false);
        tutorialPanel.SetActive(false);
        introText.SetActive(false);
        gameName.GetComponent<Animator>().enabled = false;
        introText.GetComponent<Animator>().enabled = false;
        grabbableObject.SetActive(false);
        bench.SetActive(false);
    }
    public void PlayPressed()
    {
        introText.SetActive(true);
        gameName.GetComponent<Animator>().enabled = true;
        introText.GetComponent<Animator>().enabled = true;
        playButton.SetActive(false);
        startButton.SetActive(true);
    }

    public void StartPressed()
    {
        introText.SetActive(false);
        startButton.SetActive(false);    
        grabbableObject.SetActive(true);
        bench.SetActive(true);
        tutorialPanel.SetActive(true);
    }

    IEnumerator StartExperience()
    {
        

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene(1);
    }
}
