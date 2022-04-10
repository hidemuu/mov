using Mov.Configurator.Repository;
using Mov.Designer.Repository.Xml;
using Mov.Utilities;
using System;
using System.IO;

namespace Mov
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Mov!");
            RepositoryHelper repositoryHelper = new RepositoryHelper();
            repositoryHelper.WriteAll();

            Console.ReadKey();
        }
    }
}
