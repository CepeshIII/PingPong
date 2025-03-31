using UnityEngine;

public class SoundManager : MonoBehaviour, ICollisionListener
{
    [SerializeField] private AudioClip wallCollisionSound;
    [SerializeField] private AudioClip platformCollisionSound;
    [SerializeField] private AudioSource audioSource;

    ICollisionHandler collisionHandler;

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        collisionHandler = GetComponent<ICollisionHandler>();

        collisionHandler?.ConnectListener(this);
    }

    public void OnDisable()
    {
        collisionHandler?.DisconnectListener(this);
    }

    public void OnWallCollision() 
    {
        audioSource.PlayOneShot(wallCollisionSound);
    }

    public void OnPlatformCollision()
    {
        audioSource.PlayOneShot(platformCollisionSound);
    }

    public void OnCollisionEvent(CollisionContext context)
    {
        if (context.AnotherObject.CompareTag("Platform"))
        {
            OnPlatformCollision();
        }
        else
        {
            OnWallCollision();
        }
    }
}
