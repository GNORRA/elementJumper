using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{
    public static GameMenuManager gameMenuManager; //instance creation
    public GameObject GameMenu,ReviveImageButton,EndGameImageButton;

    public GameObject ScoreImage, ScoreValueText;
    public  int gameMenuState;
    public Animator animatorMenu, animatorRevive,animatorEndGame,animatorNoAds;
    public bool canReviveGame, canEndGame, canNoAds;
    public Animator specialPanelBoxAnim;
    public GameObject specialPanelRating;


    private void Start()
    {
     
    }


    void Awake()
    {
        gameMenuManager = this;
    }

   
    void Update()
    {

        if(gameMenuState== 1)
        {
            GameMenu.SetActive(true);
            animatorMenu.SetBool("menuAnim", true);
            ScoreImage.SetActive(false);
            ScoreValueText.SetActive(false);

            if (canReviveGame)
            {
                StartCoroutine(ReviveAnim());
               

            }
            if (canEndGame)
            {
                StartCoroutine(EndGameAnim());
            }
            if (canNoAds)
            {
                StartCoroutine(NoAdsAnim());
            }
        }
    }


    public void ReviveGameAction()
    {
        canReviveGame = true;
        GameObject.FindWithTag("BackgroundAmbianceSound").GetComponent<AudioSource>().Stop();
      

    }


    public void DisplaySpecialRating()
    {
        specialPanelRating.SetActive(true);
        specialPanelBoxAnim.SetTrigger("PlaySpecialRatingAnim");

    }

    public void HideSpecialRating()
    {
        specialPanelRating.SetActive(false);
        SphereRotation.sphereRotation.canNextStep = true;
    }

    private IEnumerator ReviveAnim()
    {
        animatorRevive.SetTrigger("revive");
        yield return new WaitForSeconds(.5f);
        canReviveGame = false;

        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }

    private IEnumerator EndGameAnim()
    {
        animatorEndGame.SetTrigger("endGame");
        yield return new WaitForSeconds(.5f);
        animatorEndGame.SetBool("endGame", false);
        canEndGame = false;
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }

    public void EndGameAction()
    {

        canEndGame = true;
       
    }

    private IEnumerator NoAdsAnim()
    {
        animatorNoAds.SetTrigger("noAds");
        yield return new WaitForSeconds(.5f);
        animatorNoAds.SetBool("noAds", false);
        canNoAds = false;

    }

    public void NoAds()
    {
        canNoAds = true;
    }


}
