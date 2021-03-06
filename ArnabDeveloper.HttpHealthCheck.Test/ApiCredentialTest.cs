using Xunit;

namespace ArnabDeveloper.HttpHealthCheck.Test;

public class ApiCredentialTest
{
    [Fact]
    public void ProductApiCredentialSuccessTest()
    {
        ApiCredential apiCredential = new("u1", "p1");

        Assert.Equal("u1", apiCredential.UserName);
        Assert.Equal("p1", apiCredential.Password);
    }
}