namespace ArnabDeveloper.HttpHealthCheck
{
    /// <summary>
    /// Health check of HTTP endpoint.
    /// </summary>
    public interface IHealthCheck
    {
        /// <summary>
        /// Check if a HTTP endpoint is healthy or not.
        /// </summary>
        /// <param name="url">URL to be checked.</param>
        /// <param name="credential">Credential to access the endpoint (if any).</param>
        /// <returns>
        /// Returns a task object representing true if the endpoint is healthy otherwise false.
        /// </returns>
        Task<bool> IsHealthyAsync(string url, ApiCredential? credential = null);
    }
}