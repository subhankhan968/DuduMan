using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    public int milk, money, maxMilk;

    [SerializeField]
    internal PlayerManager pManager;

    [SerializeField]
    internal GameObject[] environmentObjsR;
    [SerializeField]
    internal GameObject[] environmentObjsL;
    [SerializeField]
    internal GameObject[] Obstacles;

    private void Awake()
    {
        instance = this;

        for (int j = 0; j < 3 * 500; j+=500)
        {
            int i = Random.Range(0, environmentObjsR.Length);
            Instantiate(environmentObjsR[i], new Vector3(0, 0, j), environmentObjsR[i].transform.rotation);
            i = Random.Range(0, environmentObjsL.Length);
            Instantiate(environmentObjsL[i], new Vector3(0, 0, j), environmentObjsL[i].transform.rotation);
            i = Random.Range(0, Obstacles.Length);
            Instantiate(Obstacles[i], new Vector3(0, 0, j), Obstacles[i].transform.rotation);
        }
    }

    private void Start()
    {
        milk = 0;
        money = 0;
        maxMilk = 0;
    }

    private void FixedUpdate()
    {
        if (pManager.finished)
        {
            StartCoroutine(levelComplete());
        }
        else if (pManager.failed)
        {
            StartCoroutine(levelFailed());
        }
    }

    IEnumerator levelComplete()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("Level Pass");
    }

    IEnumerator levelFailed()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("Level Fail");
    }
}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class gameManager : MonoBehaviour
//{
//    public static gameManager instance;
//    public gameState state;
//    public static event Action<gameState> onGameStateChanged;

//    public int milk, money, maxMilk;

//    [SerializeField]
//    GameObject pressToPlayObjects;
//    [SerializeField]
//    GameObject gamePlayObjects;
//    [SerializeField]
//    GameObject levelCompleteObjects;
//    [SerializeField]
//    GameObject levelFailObjects;

//    [SerializeField]
//    internal PlayerManager pManager;

//    private void Awake()
//    {
//        instance = this;
//    }

//    private void Start()
//    {
//        updateGameState(gameState.pressToPlay);
//        milk = 0;
//        money = 0;
//        maxMilk = 0;
//    }

//    private void FixedUpdate()
//    {

//    }

//    public void updateGameState(gameState newState)
//    {
//        state = newState;

//        switch (newState)
//        {
//            case gameState.pressToPlay:
//                break;
//            case gameState.gamePlay:
//                Debug.Log("game started");
//                break;
//            case gameState.levelComplete:
//                break;
//            case gameState.levelFail:
//                break;
//            default:
//                break;
//        }

//        onGameStateChanged?.Invoke(newState);
//    }

//    void handlePressToPlay()
//    {
//        pressToPlayObjects.SetActive(true);
//        gamePlayObjects.SetActive(false);
//        levelCompleteObjects.SetActive(false);
//        levelFailObjects.SetActive(false);
//    }
//    void handleGamePlay()
//    {
//        pressToPlayObjects.SetActive(false);
//        gamePlayObjects.SetActive(true);
//        levelCompleteObjects.SetActive(false);
//        levelFailObjects.SetActive(false);
//    }
//    void handleLevelComplete()
//    {
//        pressToPlayObjects.SetActive(false);
//        gamePlayObjects.SetActive(false);
//        levelCompleteObjects.SetActive(true);
//        levelFailObjects.SetActive(false);

//    }
//    void hadleLevelFail()
//    {
//        pressToPlayObjects.SetActive(false);
//        gamePlayObjects.SetActive(false);
//        levelCompleteObjects.SetActive(false);
//        levelFailObjects.SetActive(true);

//    }
//}

//public enum gameState
//{
//    pressToPlay,
//    gamePlay,
//    levelComplete,
//    levelFail
//}
