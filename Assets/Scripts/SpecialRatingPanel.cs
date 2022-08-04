using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialRatingPanel : MonoBehaviour
{

    public static SpecialRatingPanel specialRatingPanel;
    // Start is called before the first frame update
    void Start()
    {
        specialRatingPanel = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onGotIt()
    {
        GameMenuManager.gameMenuManager.HideSpecialRating();

    }
}
