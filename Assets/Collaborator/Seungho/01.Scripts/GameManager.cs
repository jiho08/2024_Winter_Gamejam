using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int mission = 0; // 0 : 모든 적 처치, 1 : 탈출 지점 도달
    private TextAction text;
    public static float timer;
    public Transform enemys;
    [SerializeField] private GameObject noise;
    [SerializeField] private GameObject UI;
    public static float enemyCount;
    public PlayerMove player;

    Coroutine coroutine;

    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        timer = 0;
        text = FindAnyObjectByType<TextAction>();
        player = FindAnyObjectByType<PlayerMove>();
        enemyCount = enemys.GetComponentsInChildren<Enemy>().Length;
    }
    public void Start()
    {
        
        StageStart();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if(mission == 0 && enemyCount <= 0)
        {
            
            if(coroutine == null )
                coroutine = StartCoroutine(StageClear("클리어"));
        }
    }

    public void StageStart()
    {
        
        switch (mission)
        {
            case 0:
                text.ShowText("모든 적 처치");
                break;

            case 1:
                text.ShowText("탈출 지점 도달");
                break;
        }
    }

    public IEnumerator StageClear(string message)
    {
        player.inputAction.Player.Disable();
        text.ShowText(message);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Noise());
        yield return new WaitForSeconds(0.2f);
        
        StageUI.ClearStage(StageUI._currentStage);
        if(StageUI._currentStage != SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(++StageUI._currentStage);
        }
        else
        {
            SceneManager.LoadScene(0);

        }



    }

    public IEnumerator Noise()
    {

        Time.timeScale = 1.0f;
        noise.SetActive(true);
        yield return null;
    }
}
