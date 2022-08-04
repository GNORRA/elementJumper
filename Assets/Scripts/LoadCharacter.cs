using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{

    public static bool classic;
    public static bool freezy;
    public static bool lucky;

    public GameObject[] characterPrefabs;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        string isClassic = PlayerPrefs.GetString("classic");
        string isFreezy = PlayerPrefs.GetString("freezy");
        string isLucky = PlayerPrefs.GetString("lucky");
        // classic = false;
        // freezy = false;
        // lucky = false;

      

             if (isClassic == "true")
        {
            classic = true;
            int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
            GameObject prefab = characterPrefabs[selectedCharacter];
            GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

        }

        //     if(isFreezy == "true")
        //{
        //    freezy = true;
        //    int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        //    GameObject prefab = characterPrefabs[selectedCharacter];
        //    GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        //}

        //     if(isLucky == "true")
        //{
        //    lucky = true;
        //    int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        //    GameObject prefab = characterPrefabs[selectedCharacter];
        //    GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

        //}



    }

   
}
