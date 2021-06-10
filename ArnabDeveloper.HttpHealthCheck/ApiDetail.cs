namespace ArnabDeveloper.HttpHealthCheck
{
    /// <summary>
    /// Api details model.
    /// </summary>
    public record ApiDetail(string Name, string Url, ApiCredential? ApiCredential, bool IsEnable);
}
