﻿using Mov.Core.Models.ValueObjects.Personals;
using Mov.Core.Templates;
using System;
using System.Threading;

namespace Mov.Core.Models.Entities.Personals
{
    public class AddressDatabase : IDatabase<Address, Guid>
    {
        private static Lazy<AddressDatabase> instance = new Lazy<AddressDatabase>(() => new AddressDatabase());

        private static ThreadLocal<AddressDatabase> threadInstance = new ThreadLocal<AddressDatabase>(() => new AddressDatabase());

        public int Id { get; }

        public static AddressDatabase Instance => instance.Value;

        public static AddressDatabase ThreadInstance => threadInstance.Value;

        private AddressDatabase()
        {
            Id = Thread.CurrentThread.ManagedThreadId;
        }

        public Address Get(Guid id)
        {
            return new Address();
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