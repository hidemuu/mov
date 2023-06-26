using Mov.Repositories.Services.Repositories.Domains;
using Mov.Utilities;

namespace Driver.Clients.Resas
{
    public class FileResasRepository : FileDomainRepositoryBase
    {
        public override string DomainPath => "analizer";

        public FileResasRepository(string endpoint, string fileDir, string extension, string encoding = UtilityConstants.ENCODE_NAME_UTF8)
            : base(endpoint, fileDir, extension, encoding)
        {
        }
    }
}