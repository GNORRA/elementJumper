using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToChallengeMenu : MonoBehaviour
{

    public Animator backButtonAnim;

    // Start is called before the first frame update
    void Start()
    {
        backButtonAnim.SetTrigger("backAnim");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void onClickToMenuChallenge()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
