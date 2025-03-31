using Unity.VisualScripting;
using UnityEngine;

public class BallCollisionController: MonoBehaviour, ICollisionListener
{
    ICollisionHandler collisionHandler;
    BallMovementLogic ballMovementLogic;

    private void OnEnable()
    {
        collisionHandler = GetComponent<ICollisionHandler>();
        ballMovementLogic = GetComponent<BallMovementLogic>();

        collisionHandler?.ConnectListener(this);
    }

    public void OnCollisionEvent(CollisionContext context)
    {
        if (context.Type == CollisionEventType.Collision)
        {
            if (context.AnotherObject.CompareTag("Platform"))
                BounceFromRacket(context);
            else
                BounceFromWall(context);
        }
    }

    public void BounceFromWall(CollisionContext context)
    {
        var position = transform.position;

        var directionAfterCollision = CollisionMath.CalculateDirectionAfterCollision(-context.Collision.relativeVelocity, context.Normal);

        ballMovementLogic.Move(directionAfterCollision);
    }

    public void BounceFromRacket(CollisionContext context)
    {
        var position = transform.position;

        var racket = context.AnotherObject;
        var racketPosition = racket.transform.position;
        var racketHight = racket.GetComponent<BoxCollider2D>().bounds.size.y;

        var directionAfterCollision = CollisionMath.CalculateDirectionAfterCollision(-context.Collision.relativeVelocity, context.Normal);
        var newDirection = directionAfterCollision;

        newDirection.y = ( racketPosition.y - position.y) / racketHight;

        ballMovementLogic.IncreaseHitCounter();
        ballMovementLogic.Move(newDirection);
    }

    private void OnDisable()
    {
        collisionHandler?.DisconnectListener(this);
    }

}
