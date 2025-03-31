using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float speed;

    public void Move(Vector3 direction)
    {
        var newYPosition = transform.position.y;
        if (direction.y > 0)
            newYPosition +=  speed * Time.deltaTime;
        if(direction.y < 0)
            newYPosition -=  speed * Time.deltaTime;

        var clampedY = Math.Clamp(newYPosition, minY, maxY);
        var newPosition = new Vector3(transform.position.x, clampedY, transform.position.z);

        transform.position = newPosition;
    }
}
