using eHealthcare.Entities;

public interface IHubClient
{
    Task BroadcaastMessage(Notification notification);
}