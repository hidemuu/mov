﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public class ModificationEventPublisher<T> : IDelete<T>, ISave<T>
    {
        private readonly IDelete<T> deleter;
        private readonly ISave<T> saver;
        private readonly IEventPublisher eventPublisher;

        public ModificationEventPublisher(IDelete<T> deleter, ISave<T> saver, IEventPublisher eventPublisher)
        {
            this.deleter = deleter;
            this.saver = saver;
            this.eventPublisher = eventPublisher;
        }

        public void Delete(T entity)
        {
            deleter.Delete(entity);
            var entityDeleted = new DeletedEvent<T>(entity);
            eventPublisher.Publish(entityDeleted);
        }

        public void Save(T entity)
        {
            saver.Save(entity);
            var entitySaved = new SavedEvent<T>(entity);
            eventPublisher.Publish(entitySaved);
        }

    }
}