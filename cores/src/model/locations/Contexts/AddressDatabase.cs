﻿using Mov.Core.DesignPatterns;
using Mov.Core.Locations.Models;
using Mov.Core.Models;
using System;
using System.Threading;

namespace Mov.Core.Locations.Contexts
{
    public class AddressDatabase : IDatabase<Address, Guid>
    {
        private static Lazy<AddressDatabase> instance = new Lazy<AddressDatabase>(() => new AddressDatabase());

        private static ThreadLocal<AddressDatabase> threadInstance = new ThreadLocal<AddressDatabase>(() => new AddressDatabase());

        public Identifier<int> Id { get; }

        public static AddressDatabase Instance => instance.Value;

        public static AddressDatabase ThreadInstance => threadInstance.Value;

        private AddressDatabase()
        {
            Id = new Identifier<int>(Thread.CurrentThread.ManagedThreadId);
        }

        public Address Get(Guid id)
        {
            return Address.Empty;
        }

        public void Post(Address address)
        {

        }

        public void Put(Address value)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid key)
        {
            throw new NotImplementedException();
        }
    }
}
