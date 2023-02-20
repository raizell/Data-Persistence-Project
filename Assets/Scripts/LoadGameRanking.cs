using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class LoadGameRanking : MonoBehaviour
{
     //Fields for display the user info

    public TextMeshProUGUI BestUserName;


    //Static variables for holding the best user data
    public static int BestScore;
    public static string BestUser;

    private void Awake()
    {
        LoadGameRank();
    }




    private void SetBestUser()
    {
        if (BestUser == null && BestScore == 0)
        {
            BestUserName.text = "";
        }
        else
        {
            BestUserName.text = $"Best Score - {BestUser}: {BestScore}";
        }

    }

    public void LoadGameRank()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestUser = data.TheBestUser;
            BestScore = data.HighestScore;
            SetBestUser();
        }
    }
    
    [System.Serializable]
    class SaveData
    {
        public int HighestScore;
        public string TheBestUser;
    }

}

