using System;
using TMPro;
using UnityEngine;

internal class GameManager : MonoBehaviour, ICollisionListener
{
    [SerializeField] Border leftBorder;
    [SerializeField] Border rightBorder;

    [SerializeField] ScoreManager LeftScoreManager;
    [SerializeField] ScoreManager RightScoreManager;

    [SerializeField] Ball ball;
    [SerializeField] int scoreForWinn;
    [SerializeField] SceneLoader sceneLoader;

    [SerializeField] MessageWindow messageWindow;

    public SceneLoader GetSceneLoader()
    {
        if (sceneLoader == null)
            sceneLoader = FindAnyObjectByType<SceneLoader>();
        return sceneLoader;
    }

    public void OnCollisionEvent(CollisionContext context)
    {
        Goal(context);
    }

    public void OnEnable() 
    {
        leftBorder.ConnectListener(this);
        rightBorder.ConnectListener(this);
        sceneLoader = FindAnyObjectByType<SceneLoader>();
    }

    public void OnDisable()
    {
        leftBorder.DisconnectListener(this);
        rightBorder.DisconnectListener(this);
    }

    public void CheckIfGameOver()
    {
        var nameOfLosePlayer = string.Empty;
        if (scoreForWinn <= LeftScoreManager.Score)
            nameOfLosePlayer = "Left Player";
        else if (scoreForWinn <= LeftScoreManager.Score)
            nameOfLosePlayer = "Right Player";
        else
            return;

        GameOver(nameOfLosePlayer);
    }

    public void GameOver(string nameOfLosePlayer)
    {
        ball.gameObject.SetActive(false);
        leftBorder.gameObject.SetActive(false);
        rightBorder.gameObject.SetActive(false);

        var window = Instantiate(messageWindow);
        var message = new Message()
        {
            header = $"{nameOfLosePlayer} Lose",
            text = "Don't worry and try again",
            buttonText = "Back to Main menu"
        };

        window.ShowMessage(message, GetSceneLoader().LoadMainMenu);
        //window.ShowMessage(message);

    }

    public void Goal(CollisionContext context)
    {
        CheckIfGameOver();

        var isLeftPlayerMiss = context.Collision.otherCollider.gameObject == leftBorder.gameObject;
        ball.ResetBall(isLeftPlayerMiss);

    }

}
