using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameText;
    [SerializeField] private TMP_Text bestScoreText;

    void Start()
    {
        SaveFile saveFile = SaveDataManager.instance.LoadData();

        bestScoreText.text = "Best score : " + saveFile.playerName + " : " + saveFile.score;
    }

    public void StartGame()
    {
        SaveDataManager.instance.playerName = playerNameText.text;
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
