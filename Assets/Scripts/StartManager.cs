using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public Button startButton;

    public void OnNameValueChanged(string value)
    {
        if(value.Length > 0)
        {
            startButton.interactable = true;
        }
        else
        {
            startButton.interactable = false;
        }
        
        DataManager.Instance.SetPlayerName(value);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
