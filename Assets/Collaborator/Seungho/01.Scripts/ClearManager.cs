using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearManager : MonoBehaviour
{
    public int mission = 0; // 0 : 모든 적 처치, 1 : 탈출 지점 도달
    private TextAction text;
    public float timer;
    public Transform enemys;
    private float enemyCount;



    private void Awake()
    {
        text = FindAnyObjectByType<TextAction>();
    }
    public void Start()
    {
        enemyCount = enemys.GetComponentsInChildren<Enemy>().Length;
        StageStart();
    }
    private void Update()
    {
        timer += Time.deltaTime;
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
        text.ShowText(message);
        yield return new WaitForSecondsRealtime(1f);
        
    }
}
