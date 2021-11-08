using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenHandler : MonoBehaviour
{
    public GameObject gameName;
    public GameObject playButton, startButton;
    public GameObject introText, readyText;
    public GameObject grabbableObject, bench;

    private void Start()
    {
        startButton.SetActive(false);
        readyText.SetActive(false);
        gameName.GetComponent<Animator>().enabled = false;
        introText.GetComponent<Animator>().enabled = false;
        grabbableObject.SetActive(false);
        bench.SetActive(false);
    }
    public void PlayPressed()
    {
        gameName.GetComponent<Animator>().enabled = true;
        introText.GetComponent<Animator>().enabled = true;
        playButton.SetActive(false);
        startButton.SetActive(true);
    }

    public void StartPressed()
    {
        gameName.GetComponent<Animator>().enabled = false;
        introText.GetComponent<Animator>().enabled = false;
        grabbableObject.SetActive(true);
        bench.SetActive(true);
    }

    IEnumerator StartExperience()
    {
        readyText.SetActive(true);

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene(1);
    }
}
