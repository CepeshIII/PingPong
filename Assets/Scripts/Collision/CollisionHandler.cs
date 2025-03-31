using UnityEngine;

public class CollisionHandler : MonoBehaviour, ICollisionHandler
{
    public delegate void CollisionHandlerEvent(CollisionContext context);
    CollisionHandlerEvent OnCollisionEvent;

    public void ConnectListener(ICollisionListener triggerListener)
    {
        OnCollisionEvent += triggerListener.OnCollisionEvent;
    }

    public void DisconnectListener(ICollisionListener triggerListener)
    {
        OnCollisionEvent -= triggerListener.OnCollisionEvent;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollisionEvent?.Invoke(new CollisionContext(collision));
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        OnCollisionEvent?.Invoke(new CollisionContext(collider));
    }

}
