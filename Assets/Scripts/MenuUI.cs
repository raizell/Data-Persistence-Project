using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public TextMeshProUGUI UserNameText;
    public TextMeshProUGUI BestScore;
    private void Start() 
    {
        BestScore.text = $"Best Score: {LoadGameRanking.BestUser} : {LoadGameRanking.BestScore}";
    }
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }
    
    public void GetUserName()
    {
        DataManager.Instance.UserName = UserNameText.text;
    }
}
