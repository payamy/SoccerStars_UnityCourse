using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Dropdown gameWinDropdown;
    public Dropdown playerCountDropdown;

    public void PlayGame()
    {
        LoadGameRuleContainer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void LoadGameRuleContainer()
    {
        if (gameWinDropdown.value == 0)
        {
            GameRuleContainer.Instance.gameWinRule = new MaxPointWinRule();
        } else
        {
            GameRuleContainer.Instance.gameWinRule = new TimeWinRule();
        }

        if (playerCountDropdown.value == 0)
        {
            GameRuleContainer.Instance.playerNumberContainer = new ThreePlayerNumberContainer();
        } else
        {
            GameRuleContainer.Instance.playerNumberContainer = new FourPlayerNumberContainer();
        }
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
