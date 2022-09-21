using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;

namespace API.Services.Firebase
{
    public class FirebaseInit
    {
        private readonly IWebHostEnvironment _env = null!;
        public FirebaseAuth Auth { get; private set; } = null!;
        public FirebaseInit(IWebHostEnvironment env)
        {
            _env = env;
            InitializeFirebaseApp();

        }

        public void InitializeFirebaseApp()
        {
            var defaultApp = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(Path.Combine(_env.WebRootPath, "fast-billing-775f5-firebase-adminsdk-tceqx-6c1d0bac1f.json"))
            });

            Auth = FirebaseAuth.GetAuth(defaultApp);
        }
    }
}