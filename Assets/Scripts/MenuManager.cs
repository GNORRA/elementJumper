using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{


    public static MenuManager menuManager;

    public GameObject gameStat;
    public Animator playAnim;
    public AudioSource playButtonLoadingSound;
    public GameObject buttonPlay;
    
  



    private void Awake()
    {
        menuManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameStat = FindObjectOfType<GameObject>();

      


        playAnim.SetTrigger("PlayButtonAnim");

        playButtonLoadingSound.PlayDelayed(1.5f);
      
    }

    // Update is called once per frame
    void Update()
    {

      

    }



    public void onPlayClick()
    {
        SceneManager.LoadSceneAsync(1,LoadSceneMode.Single);
        DontDestroyOnLoad(gameStat);
        
    }
    public void onTutorialClick()
    {
        SceneManager.LoadScene("");
    }
    public void onShopClick()
    {
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
    }
    public void onConfigClick()
    {
        SceneManager.LoadScene("");
    }
    public void onExitClick()
    {
        Application.Quit();
    }

  
}
