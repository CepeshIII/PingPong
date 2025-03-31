using UnityEngine;

public class BorderGoalListener : MonoBehaviour, ICollisionListener
{
    public delegate void BorderGoalListenerEvents();
    public BorderGoalListenerEvents OnGoalEvent;

    public Border border;

    public void OnCollisionEvent(CollisionContext context)
    {
        OnGoalEvent.Invoke();
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
