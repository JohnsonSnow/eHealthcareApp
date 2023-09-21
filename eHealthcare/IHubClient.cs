using eHealthcare.Entities;

public interface IHubClient
{
    Task BroadcastMessage(Notification notification);
}