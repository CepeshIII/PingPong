using UnityEngine;

public static class CollisionMath
{
    public static Vector3 CalculateDirectionAfterCollision(Vector3 direction, Vector3 collisionNormal)
    {
        direction = direction.normalized;
        collisionNormal = collisionNormal.normalized;

        Vector3.Dot(direction, collisionNormal);

        return direction - 2f * Vector3.Dot(direction, collisionNormal) * collisionNormal;
    }
}
