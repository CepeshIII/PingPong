using UnityEngine;

public class PlayerController : MonoBehaviour
{
    IMovable movementLogic;

    private void OnEnable()
    {
        movementLogic = GetComponent<IMovable>();
    }

    private void FixedUpdate()
    {
        var y = Input.GetAxisRaw("Vertical");
        movementLogic.Move(Vector3.up * y);
    }
}
