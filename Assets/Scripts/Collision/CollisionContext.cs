using UnityEngine;

public enum CollisionEventType
{
    Trigger,
    Collision
}

public class CollisionContext
{

    public CollisionEventType Type { get; }
    public Collision2D Collision { get { return _collision; } }

    Collision2D _collision;
    Collider2D _collider2D;

    public GameObject AnotherObject
    {
        get
        {
            if (Type == CollisionEventType.Collision)
                return _collision.collider.gameObject;
            else
                return _collider2D.gameObject;
        }
    }

    public Vector3 Normal => _collision.contacts[0].normal;

    public CollisionContext(Collision2D collision)
    {
        _collision = collision;
        Type = CollisionEventType.Collision;
    }

    public CollisionContext(Collider2D collider2D)
    {
        _collider2D = collider2D;
        Type = CollisionEventType.Trigger;
    }
}