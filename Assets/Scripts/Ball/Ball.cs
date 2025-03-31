using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] BallMovementLogic m_Logic;

    private void OnEnable()
    {
        m_Logic = GetComponent<BallMovementLogic>();
    }

    public void ResetBall(bool IsLeftPlayerStarting = true)
    {
        m_Logic.ResetBall(IsLeftPlayerStarting);
    }

}
