using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int mission = 0; // 0 : ��� �� óġ, 1 : Ż�� ���� ����
    private TextAction text;
    public static float timer;
    public Transform enemys;
    [SerializeField] private GameObject noise;
    public static float enemyCount;

    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        timer = 0;
        text = FindAnyObjectByType<TextAction>();
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
            Debug.Log("a");
            StageClear("�� ġ�פ���");
        }
    }

    public void StageStart()
    {
        
        switch (mission)
        {
            case 0:
                text.ShowText("��� �� óġ");
                break;

            case 1:
                text.ShowText("Ż�� ���� ����");
                break;
        }
    }

    public IEnumerator StageClear(string message)
    {
        text.ShowText(message);
        yield return new WaitForSecondsRealtime(1f);
        StartCoroutine(Noise());
        yield return new WaitForSecondsRealtime(0.5f);
        StageUI.ClearStage(SceneManager.sceneCount);

        
    }

    public IEnumerator Noise()
    {

        Time.timeScale = 1.0f;
        noise.SetActive(true);
        yield return null;
    }
}
