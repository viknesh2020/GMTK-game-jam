
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ObjectPooler
{
    public int amountToPool;
    public GameObject objectToPool;
    public bool shouldExpand;
}
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    public UIManager uIManager;

    [Header("Obstracle Setting")]
    // Object Pooling of obstracles
    public List<ObjectPooler> objectsToPool;
    List<GameObject> pooledObjects;

    public Transform spawnPoint;
    float itemSpawnTime;
    bool pickupSpawnFlag = true;
    StringBuilder itemName;
    public float minSpawnTime;
    public float maxSpawnTime;


    public bool startGame;

    float minGameSpeed = 3f;
    float maxGameSpeed = 15f;
    float time;
    [Header("GamePlay Setting")]
    public float speedProgress;
    public float gameSpeed;

    public PlaneController playerController;
    public Vector3 initialPlayerPos;

    public  Image healthBar;
    public static float healthValue;

    void Start()
    {
        initialPlayerPos = playerController.transform.position;
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            if (pickupSpawnFlag)
            {
                pickupSpawnFlag = false;

                itemSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);

                StartCoroutine(SpawnItem());
            }
            PlayerSpeedControl();
            HealthControl();


            
        }
    }
    public void Initialize()
    {
        time = 0f;
        gameSpeed = 0f;
        healthValue = 1f;

        startGame = false;
        //  playerController.animator.SetBool(1, false);

        pooledObjects = new List<GameObject>();
        foreach (ObjectPooler obj in objectsToPool)
        {
            for (int i = 0; i < obj.amountToPool; i++)
            {
                GameObject gO = (GameObject)Instantiate(obj.objectToPool);
                gO.SetActive(false);
                pooledObjects.Add(gO);
            }
        }

    }

    IEnumerator SpawnItem()
    {
        yield return new WaitForSeconds(itemSpawnTime);

        int randomValue = Random.Range(0, objectsToPool.Count);
        itemName = new StringBuilder("Item", 6);
        itemName.Append(randomValue);
        var newSpawnPoint = spawnPoint.position + new Vector3(Random.Range(-30f, 30f), Random.Range(-9f, 9f), 0);

        GameObject pickupitemToSpawn = GetPooledObject(itemName.ToString());
        if (pickupitemToSpawn != null)
        {
            pickupitemToSpawn.transform.position = newSpawnPoint;
            pickupitemToSpawn.SetActive(true);
        }     pickupSpawnFlag = true;
        
    }

    public GameObject GetPooledObject(string tag)
    {

        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
                return pooledObjects[i];
        }
        foreach (ObjectPooler obj in objectsToPool)
        {
            if (obj.objectToPool.tag == tag)
            {
                if (obj.shouldExpand)
                {
                    GameObject gO = (GameObject)Instantiate(obj.objectToPool);
                    gO.SetActive(false);
                    pooledObjects.Add(gO);
                    return gO;
                }
                
            }
        }
        return null;
    }

    void PlayerSpeedControl()
    {
        gameSpeed = Mathf.SmoothStep(minGameSpeed, maxGameSpeed, time * speedProgress);
        time += Time.deltaTime;
    }

    public void OnGameStart()
    {
        time = 0;
        gameSpeed = 0f;

        startGame = true;
        //   playerController.animator.SetBool("Run", true);
        playerController.transform.position = initialPlayerPos;

        if (pooledObjects.Count > 0)
        {
            foreach (GameObject obj in pooledObjects)
            {
                obj.SetActive(false);
            }
        }
    }

    public void GameOver()
    {
        uIManager.GameOverScreen();
        Debug.Log("Game Over");
    }

    public void HealthControl()
    {
        healthBar.fillAmount = healthValue;
        if (healthValue <= 0)
        {
            GameOver();
        }
    }

}