using UnityEngine;

public class Border : MonoBehaviour, ICollisionHandler
{
    public delegate void BorderEvent(CollisionContext context);
    BorderEvent triggerEnter;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        triggerEnter?.Invoke(new CollisionContext(collider));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        triggerEnter?.Invoke(new CollisionContext(collision));
    }

    public void DisconnectListener(ICollisionListener triggerListener)
    {
        if(triggerEnter != null) 
            triggerEnter -= triggerListener.OnCollisionEvent;
    }

    public void ConnectListener(ICollisionListener triggerListener)
    {
        triggerEnter += triggerListener.OnCollisionEvent;
    }
}
