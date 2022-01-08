using Mov.Authorizer.Repository;
using Mov.Authorizer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Mov.Accessors;

namespace Mov.Authorizer.Repository
{
    public class AuthorizerRepository : IAuthorizerRepository
    {
        public AuthorizerRepository(string path, FileType fileType, string encoding = "utf-8")
        {
            switch (fileType)
            {
                case FileType.Json:
                    Users = new UserRepository(new JsonFileHelper(Path.Combine(path, UserRepository.FILE_NAME), encoding));
                    break;
                default:
                    Users = new UserRepository(new XmlFileHelper(Path.Combine(path, UserRepository.FILE_NAME), encoding));
                    break;
            }
        }

        public IUserRepository Users { get; }
    }
}
