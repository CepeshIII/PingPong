using UnityEngine;

public class AIController : MonoBehaviour
{
    IMovable movementLogic;
    [SerializeField] GameObject sphere;

    [SerializeField]  float verticalDistanceThreshold = 0.5f;

    private void OnEnable()
    {
        movementLogic = GetComponent<IMovable>();
    }

    private void FixedUpdate()
    {
        var verticalDirection = sphere.transform.position.y - transform.position.y;
        if(Mathf.Abs(verticalDirection) > verticalDistanceThreshold)
            movementLogic.Move(Vector3.up * verticalDirection);
    }
}
