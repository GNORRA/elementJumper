using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutInRandomAnimScript : MonoBehaviour
{

    [Header("Obstacle gameObject")]
    public GameObject[] obstacleList;

    // Start is called before the first frame update
    void Start()
    {

       // StartCoroutine(ObstacleManager());

    }

    // Update is called once per frame
    void Update()
    {
 
    }

    IEnumerator ObstacleManager()
    {
       
        for (int i = 0; i < obstacleList.Length*2; i++)
        {
            int rnd = Random.Range(0, obstacleList.Length);

            yield return new WaitForSeconds(2f);

            if (!obstacleList[rnd].activeSelf) obstacleList[rnd].SetActive(true);
      
            yield return new WaitForSeconds(2f);

            if (obstacleList[rnd].activeSelf) obstacleList[rnd].SetActive(false);

        }
      


    }
}
