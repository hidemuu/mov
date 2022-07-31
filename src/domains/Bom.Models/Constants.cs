using Mov.Utilities;
using System;

namespace Bom.Models
{
    /// <summary>
    /// Contains constant values you'll need to insert before running the sample. 
    /// Note: this file is provided for convenience only. In a production app,
    /// never store sensitive information in code or share server-side keys with
    /// the client.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// ルートパス（絶対パス）
        /// </summary>
        public static readonly string RootPath = PathHelper.GetCurrentRootPath("Stocker");
        /// <summary>
        /// アプリケーションAPI用ローカルデータベースコネクション文字列
        /// </summary>
        public static readonly string SqlLocalConnectionStringForSqlite = @"Data Source=" + RootPath + @"assets\db.sqlite";
        /// <summary>
        /// Base URL for the app's API service. A live test service is provided for convenience; 
        /// however, you cannot modify any data on the server or deploy your own updates. 
        /// To see the full functionality, deploy ContosoService using your own Azure account.
        /// </summary>
        public const string ApiUrl = @"http://sulu-api-dev.azurewebsites.net/api/";

        /// <summary>
        /// The Azure Active Directory (AAD) client id.
        /// </summary>
        public const string AccountClientId = "<TODO: Insert Azure client Id>";

        /// <summary>
        /// Connection string for the database.
        /// </summary>
        public const string DatabaseConnectionString = "<TODO: Insert connection string>";
    }
}
