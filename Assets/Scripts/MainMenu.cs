using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public bool isStarted = false;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject pause;

    public void StartGame()
    {
        isStarted = true;
        gameObject.SetActive(false);
        pause.SetActive(true);
        player.GetComponent<PlayerController>().SetisStarted(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
