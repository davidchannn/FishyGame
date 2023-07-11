using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FishSpawn : MonoBehaviour
{
    public int fishType;
    public int numFish = 3;
    public int destroyTimer;
    public float enemySize;

    public float spawnMaxHeight = 4.0f;
    public float spawnMinHeight = -4.0f;
    public float currHeight;
    public float timeToSpawn;
    public float currentTimeToSpawn;

    public GameObject[] fishList;
    public GameObject currFish;

    public GameHandler gameHandler;

    // Start is called before the first frame update
    void Start()
    {
        currentTimeToSpawn = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimeToSpawn > 0)
        {
            currentTimeToSpawn -= Time.deltaTime;
        }
        else {
            SpawnObject();
            currentTimeToSpawn = timeToSpawn;
        }
    }

    public void SpawnObject() {
        fishType = Random.Range(0, numFish);
        switch (fishType) {
            case 1:
                enemySize = 0.25f;
                break;
            case 2:
                enemySize = 0.5f;
                break;
            case 3:
                enemySize = 1f;
                break;
            default:
                break;
        }
        currHeight = Random.Range(spawnMinHeight, spawnMaxHeight);
        currFish = Instantiate(fishList[fishType], transform.position + new Vector3(0, currHeight, 0), transform.rotation);
        Destroy(currFish, destroyTimer);
    }
}
