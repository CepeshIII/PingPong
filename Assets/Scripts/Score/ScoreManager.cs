using UnityEngine;

public class ScoreManager : MonoBehaviour, ICollisionListener
{
    [SerializeField] private int score = 0;
    [SerializeField] private ScoreShower shower;

    public Border border;

    public int Score => score;

    public void IncreaseScore(int amount)
    {
        score += amount;
        shower.Show(score);
    }

    public void OnCollisionEvent(CollisionContext context)
    {
        IncreaseScore(1);
    }

    public void OnEnable()
    {
        border.ConnectListener(this);
    }

    public void OnDisable()
    {
        border.DisconnectListener(this);
    }


}
