using Mov.Framework.Services;

namespace Mov.UseCase
{
    public static class UseCaseConstants
    {
        /// <summary>
        /// ルートパス（絶対パス）
        /// </summary>
        public static readonly string RootPath = PathCreator.GetSolutionPath();
        /// <summary>
        /// リソースパス（絶対パス）
        /// </summary>
        public static readonly string ResourcePath = PathCreator.GetResourcePath();
        /// <summary>
        /// アプリケーションAPI用ローカルデータベースコネクション文字列
        /// </summary>
        public static readonly string SqlLocalConnectionStringForSqlite = @"Data Source=" + RootPath + @"assets\api\db.sqlite";
        /// <summary>
        /// アプリケーションAPI用ローカルデータベースコネクション文字列
        /// </summary>
        public static readonly string SqlLocalConnectionStringForPostgreSql = @"Host=localhost;Port=5432;User Id=postgres;Password=5285;Database=MobileLinks_db";
        /// <summary>
        /// アプリケーションAPI用ローカルデータベースコネクション文字列
        /// </summary>
        public static readonly string SqlLocalConnectionStringForSqlServer = @"data source=(LocalDb)\MSSQLLocalDB; initial catalog=MobileLinks.Repository.Sql.MobileLinksDbContext; integrated security=True; MultipleActiveResultSets=True; App=EntityFramework";
        /// <summary>
        /// Covid19 API用ローカルデータベースコネクション文字列
        /// </summary>
        public static readonly string SqlCovidConnectionString = RootPath + @"assets\covid\covid.sqlite";
        /// <summary>
        /// ローカルサーバー用パス（XAMPPを使用する場合のみ）
        /// </summary>
        public static readonly string ServerPath = @"C:\xampp\htdocs\covid_reader\csharp\";
        /// <summary>
        /// ローカルサーバーURL（XAMPPを使用する場合のみ）
        /// </summary>
        public static readonly string ServerUrl = @"http://localhost:81/covid_reader/csharp/";
    }
}