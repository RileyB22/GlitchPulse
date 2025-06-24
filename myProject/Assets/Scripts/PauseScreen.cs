using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; // SceneManager
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    /// <summary>
    /// If our game is currently paused
    /// </summary>
    /// 


    public static bool paused;


    [Tooltip("Reference to the pause menu object to turn on/off")]
    public GameObject pauseMenu;

    [Tooltip("Reference to the on screen controls menu")]
   // public GameObject onScreenControls;

    /// <summary>
    /// Reloads our current level, effectively "restarting" the game
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    /// <summary>
    /// Will turn our pause menu on or off
    /// </summary>
    /// <param name="isPaused">is the game currently paused</param>
    public void SetPauseMenu(bool isPaused)
    {
        paused = isPaused;

        /* If the game is paused, timeScale is 0, otherwise 1 */
        Time.timeScale = (paused) ? 0 : 1;

        pauseMenu.SetActive(paused);

        /*if (paused)
        {
              SlideMenuIn(pauseMenu);
        }
          else
          {
              SlideMenuOut(pauseMenu);
          }
          onScreenControls.SetActive(!paused);*/
    }

    /// <summary>
    /// load new scene when called
    /// </summary>
    /// <param name="levelName"> name of level we want to go to</param>
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    void Start()
    {
        /* Must be reset in Start or else game will be paused upon
         * restart */
        SetPauseMenu(false);
        paused = false;
    }
}
