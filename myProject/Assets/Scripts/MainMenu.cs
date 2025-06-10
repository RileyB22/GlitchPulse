
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu: MonoBehaviour
{
    /// <summary>
    /// load new scene when called
    /// </summary>
    /// <param name="levelName"> name of level we want to go to</param>

    public TextMeshProUGUI highScoreText;
    public GameObject controlPanel;
    public GameObject optionsPanel;

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void OpenOptionsMenu()
    {
        optionsPanel.SetActive(true);
    }
    public void CloseOptionsMenu()
    {
        optionsPanel.SetActive(false);
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("score", 0);
        GetAndDisplayScore();
    }

    public void Start()
    {
        // unpaul in needed
        Time.timeScale = 1;
        //check hs 
        GetAndDisplayScore();
        //slide 
       // SlideMenuIn(controlPanel);
    }

    private void GetAndDisplayScore()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("score").ToString();
    }

    ///<summary>
    /// left to center move
    /// </summary>
    /// <param name="obj">The UI element we would like to 
    /// move</param>
    public void SlideMenuIn(GameObject obj)
    {
        obj.SetActive(true);
        var rt = obj.GetComponent<RectTransform>();
        if (rt)
        {
            /* Set the object's position offscreen */
            var pos = rt.position;
            pos.x = -Screen.width / 2;
            rt.position = pos;
            /* Move the object to the center of the screen(x of 0 is centered) */

            //var tween = LeanTween.moveX(rt, 0, 1.5f);
           // tween.setEase(LeanTweenType.easeInOutExpo);
            //tween.setIgnoreTimeScale(true);

           // LeanTween.moveX(rt, 0, 1.5f).setEase(LeanTweenType.easeInOutExpo);
        }
    }

    /// <summary>
    /// right off screen move
    /// </summary>
    /// <param name="obj">The UI element we would like to 
    /// move </param>
    public void SlideMenuOut(GameObject obj)
    {
        var rt = obj.GetComponent<RectTransform>();
        if (rt)
        {
            //var tween = LeanTween.moveX(rt, Screen.width / 2, 0.5f);
            //tween.setEase(LeanTweenType.easeOutQuad);
            //tween.setIgnoreTimeScale(true);
           /* tween.setOnComplete(() =>
            {
                obj.SetActive(false);
            });*/
        }
    }
}
