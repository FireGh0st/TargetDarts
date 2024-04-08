using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPanel : MonoBehaviour
{
    public GameObject scoreboard;
    public GameObject target;
    private ScoreboardHandler sbh;
    private TargetHandler th;
    void Start()
    {
        th = target.GetComponent<TargetHandler>();
        sbh = scoreboard.GetComponent<ScoreboardHandler>();
        //scoreboard.SetActive(false);
    }

    public void ResetScoreSignal() 
    {
        sbh.ResetScore();
    }

    public void ToggleKeepScore() 
    {
        sbh.keep_score = !sbh.keep_score;
    }

    public void ToggleMovingTarget() 
    {
        Debug.Log("Toggling moving target");
        th.should_move = !th.should_move;
    }

    public void ResetTargetPosition() 
    {
        target.transform.position = target.GetComponent<TargetHandler>().default_target_position;
    }
}
