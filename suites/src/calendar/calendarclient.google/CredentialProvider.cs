using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Util.Store;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Mov.Suite.CalendarClient.Google
{
    // ここからAPIを有効化し、credentialsファイルを取得する
    // https://console.developers.google.com/apis

    class CredentialProvider
    {
        // とりあえずスコープは固定
        private static readonly string[] scopes = { CalendarService.Scope.CalendarReadonly };

        private static readonly string tokenDirectory = "token.json";
        private static readonly string credentialFileName = "credentials.json";

        public static async Task<UserCredential> GetUserCredentialAsync()
        {
            var currentPath = Directory.GetParent(Process.GetCurrentProcess().MainModule.FileName);
            var credentialFullPath = Path.Combine(currentPath.FullName, credentialFileName);

            if (File.Exists(credentialFullPath) == false)
                return null;

            using (var stream = new FileStream(credentialFullPath, FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.

                var tokenPath = Path.Combine(currentPath.FullName, tokenDirectory);
                Console.WriteLine("Credential file saved to: " + tokenPath);
                return await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(tokenPath, true));
            }
        }
    }
}
