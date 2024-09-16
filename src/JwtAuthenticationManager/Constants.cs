namespace JwtAuthenticationManager;

public static class Constants
{
    // For demo only, store sensitive values in Azure Key Vault
    public const string JWT_SECURITY_KEY = "cd92f55f54396d488fef008fd960984cedce79b5c82feb4999e4de0978b5657b";

    public const int JWT_TOKEN_VALIDITY_MINS = 20;
}
