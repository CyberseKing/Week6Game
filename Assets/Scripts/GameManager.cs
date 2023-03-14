using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager myManager;
    public int objNum;
    public GameObject objCollect;

    public Transform leftTop;
    public Transform rightBottom;
    public int enemyNum;
    public GameObject enemyObj;
    public GameObject[] enemies;

    public List<GameObject> allCollectables = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        enemies = new GameObject[enemyNum];
        for(int i = 0; i <objNum; i++)
        {
            float newX = Random.Range(leftTop.position.x, rightBottom.position.x);
            float newZ = Random.Range(rightBottom.position.z, leftTop.position.z);
            Vector3 newPos = new Vector3(newX, transform.position.y, newZ);
            GameObject newObj = Instantiate(objCollect, newPos, Quaternion.identity);
            allCollectables.Add(newObj);
        }
        for (int i = 0; i < enemyNum; i++)
        {
            float newX = Random.Range(leftTop.position.x, rightBottom.position.x);
            float newZ = Random.Range(rightBottom.position.z, leftTop.position.z);
            Vector3 newPos = new Vector3(newX, transform.position.y, newZ);
            GameObject newObj = Instantiate(enemyObj, newPos, Quaternion.identity);
            enemies[i] = newObj;
        }
    }
    /*
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if(other.gameObject.tag == "Collect") ;
        {
            myManager.allCollectables.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
        for(int i=0;i <myManager.enemyNum; i++)
        {
            if(other.gameObject == myManager.enemies[i])
            {
                Debug.Log("hit!");
            }
        }
    }
    */
    void Update()
    {
        Debug.Log(allCollectables.Count);  
    }
}
