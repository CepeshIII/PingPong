using System.Collections;
using UnityEngine;

public class BallMovementLogic : MonoBehaviour, IMovable
{
    [SerializeField] private float startSpeed = 5;
    [SerializeField] private float maxSpeed = 20;
    [SerializeField] private float extraSpeedPerHit = 0.001f;
    [SerializeField] int hitCounter = 0;
    [SerializeField] Vector3 startPosition = Vector3.zero;

    [SerializeField] private Rigidbody2D rigidbody2D;

    ICollisionHandler collisionHandler;


    private void OnEnable()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        ResetBall();
    }

    IEnumerator StartBall(bool IsLeftPlayerStarting = true)
    {
        rigidbody2D.simulated = false;
        transform.position = startPosition;
        ResetHitCounter();

        yield return new WaitForSeconds(1f);

        rigidbody2D.simulated = true;

        if(IsLeftPlayerStarting)
            Move(Vector3.right);
        else
            Move(Vector3.left);
    }

    public void Move(Vector3 direction)
    {
        var newSpeed = startSpeed + hitCounter * extraSpeedPerHit;
        rigidbody2D.linearVelocity = Mathf.Clamp(newSpeed, startSpeed, maxSpeed) * direction.normalized;
    }

    public void ResetBall(bool IsLeftPlayerStarting = true)
    {
        StartCoroutine(StartBall(IsLeftPlayerStarting));
    }

    public void IncreaseHitCounter()
    {
        hitCounter++;
    }

    public void ResetHitCounter()
    {
        hitCounter = 0;
    }


}
