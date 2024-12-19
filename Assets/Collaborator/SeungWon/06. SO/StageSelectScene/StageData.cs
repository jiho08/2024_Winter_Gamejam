using UnityEngine;

[CreateAssetMenu(fileName = "Stage/StageSO")]
public class StageData : ScriptableObject
{
    public int stageNum;
    public Sprite completeStageImage, unlockStageImage, lockStageImage;
    public state state = state.Lock;
}

public enum state { Lock, Unlock, Complete }
