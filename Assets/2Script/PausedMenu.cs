using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PausedMenu : MonoBehaviour
{
    public GameObject ui;
    public Text SpeedText;

    public string menuSceneName = "MainMenu";
    public SceneFader sceneFader;
    bool IsDoubleSpeed;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }
    public void Toggle()
    {
        Time.timeScale = 1f;
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            //게임 속도 조절  Time.timeScale =2f; 두배속
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void DoubleSpeed()
    {
        if (IsDoubleSpeed)
        {
            IsDoubleSpeed = false;
            Time.timeScale = 2f;
            SpeedText.text = "Normal Speed";
        }

        else
        {
            IsDoubleSpeed = true;
            Time.timeScale = 1f;
            SpeedText.text = "Double Speed";
        }


    }


    public void Retry()
    {
        WaveSpawner.EnemiesAlives = 0;
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        WaveSpawner.EnemiesAlives = 0;
        Toggle();
        sceneFader.FadeTo(menuSceneName);
    }
}
