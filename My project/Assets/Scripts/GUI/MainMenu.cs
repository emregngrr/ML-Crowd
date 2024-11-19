using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject primaryMenu;
    public GameObject levelSelect;
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void tryagain1()
    {
        SceneManager.LoadScene("First Level");
    }
    public void tryagain2()
    {
        SceneManager.LoadScene("Second Level");
    }
    public void tryagain3()
    {
        SceneManager.LoadScene("Third Level");
    }
    public void levelselect()
    {
        primaryMenu.SetActive(false);
        levelSelect.SetActive(true);
    }
    public void backMenu()
    {
        levelSelect.SetActive(false);
        primaryMenu.SetActive(true);
    }
}
