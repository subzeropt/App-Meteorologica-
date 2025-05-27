namespace LabApp.Services
{
    public class AuthService : IAuthService
    {
        public bool Authenticate(string username, string password)
        {
            // Exemplo simples: autenticação fixa
            return username == "admin" && password == "password";
        }
    }
}
