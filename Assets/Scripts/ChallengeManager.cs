using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChallengeManager : MonoBehaviour
{

    public static bool classic;
    public static bool freezy;
    public static bool lucky;

    public Animator btnBackAnim;

    // Start is called before the first frame update
    void Start()
    {
        classic = false;
        freezy = false;
        lucky = false;
        btnBackAnim.SetTrigger("backAnim");

    }

    // Update is called once per frame
    void Update()
    {

    }

   public void onClassic()
    {
       //classic = true;
        PlayerPrefs.SetString("classic","true");
        PlayerPrefs.SetString("freezy", "false");
        PlayerPrefs.SetString("lucky", "false");
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);

    }

    public void onFreezy()
    {
        // freezy = true;
        PlayerPrefs.SetString("freezy", "true");
        PlayerPrefs.SetString("classic", "false");
        PlayerPrefs.SetString("lucky", "false");
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);

    }

    public void onLucky()
    {
        // lucky = false;
        PlayerPrefs.SetString("lucky", "true");
        PlayerPrefs.SetString("freezy", "false");
        PlayerPrefs.SetString("classic", "false");
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);

    }
}
