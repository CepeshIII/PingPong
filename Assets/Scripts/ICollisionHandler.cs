public interface ICollisionHandler
{
    public void DisconnectListener(ICollisionListener triggerListener);
    public void ConnectListener(ICollisionListener triggerListener);
}