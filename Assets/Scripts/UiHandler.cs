using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UiHandler : MonoBehaviour
{
    public TextMeshProUGUI playerNameInput;
    public TextMeshProUGUI placeHolder;


    private void Start()
    {
        if (Persistor.Instance.playerName.Length != 0)
        {
            placeHolder.text = Persistor.Instance.playerName;
        }
    }

    public void SetName()
    {
        if (playerNameInput.text.Length != 0) Persistor.Instance.playerName = playerNameInput.text;
    }


    public void StartGame()
    {
        if (Persistor.Instance.playerName.Length <= 1) return;

        SceneManager.LoadScene(1);
    }
}
