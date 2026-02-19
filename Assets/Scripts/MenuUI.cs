using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUI : MonoBehaviour
{
    public TMP_InputField inputField;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    public void StartGame()
    {
        Debug.Log("InputField is: " + inputField);
        Debug.Log("GameData Instance is: " + GameData.Instance);
        GameData.Instance.PlayerName = inputField.text;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        if (Application.isEditor)
        {
            // if we are in the editor, stop playing
            UnityEditor.EditorApplication.ExitPlaymode();
        }
        else
        {
            // if we are in a build, quit the application
            Application.Quit();
        }
    }
}
