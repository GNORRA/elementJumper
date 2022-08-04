using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{



    public GameObject[] characters;
    public int selectedCharacter = 0;

    public GameObject characterSelectBackgroundPlane, characterSelectGroundPlane,defaultGroundPlane;

    public GameObject LeftArrow;

    [SerializeField]
    public GameObject[] planeEffect;


    public Material[] characterBackgroundPlaneMaterial;

    public ParticleSystem[] characterParticleSystem;

    public AudioSource[] characterAudioSource;



    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);

        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        //selectedCharacter = (selectedCharacter + 1) % characterBackgroundPlaneMaterial.Length;

        characterSelectBackgroundPlane.GetComponent<Renderer>().material = characterBackgroundPlaneMaterial[selectedCharacter];
        characterSelectGroundPlane.GetComponent<Renderer>().material = characterBackgroundPlaneMaterial[selectedCharacter];
        characters[selectedCharacter].SetActive(true);
        if(selectedCharacter == 0)
        {
            planeEffect[0].SetActive(false);
            planeEffect[1].SetActive(false);
            defaultGroundPlane.SetActive(true);
            characterAudioSource[0].Stop();
        }
        else if (selectedCharacter == 1)
        {
            planeEffect[0].SetActive(true);
            planeEffect[1].SetActive(false);
            defaultGroundPlane.SetActive(true);
            characterAudioSource[0].PlayDelayed(.5f);
        }
        else if (selectedCharacter == 2)
        {
            planeEffect[0].SetActive(false);
            planeEffect[1].SetActive(true);
            defaultGroundPlane.SetActive(true);
            characterAudioSource[0].Stop();
        }
    }


    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        characterSelectBackgroundPlane.GetComponent<Renderer>().material = characterBackgroundPlaneMaterial[selectedCharacter];
        characterSelectGroundPlane.GetComponent<Renderer>().material = characterBackgroundPlaneMaterial[selectedCharacter];
        if (selectedCharacter < 0)
        {

            selectedCharacter += characters.Length;
            // selectedCharacter += characterBackgroundPlaneMaterial.Length;
        }
        if (selectedCharacter == 0)
        {
           planeEffect[0].SetActive(false);
           planeEffect[1].SetActive(false);
           defaultGroundPlane.SetActive(true);
           characterAudioSource[0].Stop();
        }
        else if (selectedCharacter == 1)
        {
           planeEffect[0].SetActive(true);
           planeEffect[1].SetActive(false);
           defaultGroundPlane.SetActive(true);
           characterAudioSource[0].PlayDelayed(.5f);
        }
        else if (selectedCharacter == 2)
        {
           planeEffect[0].SetActive(false);
           planeEffect[1].SetActive(true);
           defaultGroundPlane.SetActive(true);
           characterAudioSource[0].Stop();
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void StartGame()
    {

        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene(2, LoadSceneMode.Single);

    }

    private void Start()
    {
       

        Debug.Log("Selected Character " + selectedCharacter);
        characterSelectBackgroundPlane.GetComponent<Renderer>().material = characterBackgroundPlaneMaterial[selectedCharacter];
        characterSelectGroundPlane.GetComponent<Renderer>().material = characterBackgroundPlaneMaterial[selectedCharacter];
       // characterParticleSystem[selectedCharacter].Play();
    }

    private void Update()
    {
        if (selectedCharacter == 0)
        {
            LeftArrow.SetActive(false);
        }
        if (selectedCharacter > 0)
        {
            LeftArrow.SetActive(true);
        }
    }

}
