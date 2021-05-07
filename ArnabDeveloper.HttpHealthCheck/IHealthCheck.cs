namespace ArnabDeveloper.HttpHealthCheck
{
    public interface IHealthCheck
    {
        bool IsHealthy(string url, ApiCredential? credential = null);
    }
}