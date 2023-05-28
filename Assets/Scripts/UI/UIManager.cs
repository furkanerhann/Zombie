using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public bool isPaused = false;
    [SerializeField] private GameObject hudCanvas = null;
    [SerializeField] private GameObject endCanvas = null;
    [SerializeField] private GameObject pauseCanvas = null;
    private PlayerStats stats;
    private void Start()
    {
        GetReferences();
        SetActiveHud(true);
    }
    private void Update()
    {
        if (!stats.IsDead())
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
            {
                SetActivePause(true);
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
            {
                SetActivePause(false);
            }
        }
    }
    public void SetActiveHud(bool state)
    {
        hudCanvas.SetActive(state);
        endCanvas.SetActive(!state);
        if (!stats.IsDead())
            pauseCanvas.SetActive(!state);
    }
    public void SetActivePause(bool state)
    {
        pauseCanvas.SetActive(state);
        hudCanvas.SetActive(!state);

        Time.timeScale = state ? 0 : 1;
        isPaused = state;
    }
    public void ReStart()
    {
        SceneManager.LoadScene(2);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
    private void GetReferences()
    {
        stats = GetComponentInParent<PlayerStats>();
    }
}
