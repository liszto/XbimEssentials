﻿using System;
using System.ComponentModel;
using Xbim.Common.Metadata;

namespace Xbim.Common
{
    public abstract class PersistEntity: IPersistEntity, INotifyPropertyChanged
    {
        protected PersistEntity(IModel model, int label, bool activated)
        { 
			Model = model;
            EntityLabel = label;
            ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated;
        }

        #region IPersistEntity
        public int EntityLabel { get; private set; }

        public IModel Model { get; private set; }

        /// <summary>
        /// This property is deprecated and likely to be removed. Use just 'Model' instead.
        /// </summary>
        [Obsolete("This property is deprecated and likely to be removed. Use just 'Model' instead.")]
        public IModel ModelOf { get { return Model; } }

        ActivationStatus IPersistEntity.ActivationStatus { get { return ActivationStatus; } }

        protected ActivationStatus ActivationStatus { get; set; }

        void IPersistEntity.Activate(bool write)
        {
            switch (ActivationStatus)
            {
                case ActivationStatus.ActivatedReadWrite:
                    return;
                case ActivationStatus.NotActivated:
                    lock (this)
                    {
                        //check again in the lock
                        if (ActivationStatus == ActivationStatus.NotActivated)
                        {
                            if (Model.Activate(this, write))
                            {
                                ActivationStatus = write
                                    ? ActivationStatus.ActivatedReadWrite
                                    : ActivationStatus.ActivatedRead;
                            }
                        }
                    }
                    break;
                case ActivationStatus.ActivatedRead:
                    if (!write) return;
                    if (Model.Activate(this, true))
                        ActivationStatus = ActivationStatus.ActivatedReadWrite;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        void IPersistEntity.Activate(Action activation)
        {
            if (ActivationStatus != ActivationStatus.NotActivated) return; //activation can only happen once in a lifetime of the object

            activation();
            ActivationStatus = ActivationStatus.ActivatedRead;
        }

        ExpressType IPersistEntity.ExpressType { get { return Model.Metadata.ExpressType(this); } }
        #endregion

        #region IPersist
        public abstract void Parse(int propIndex, IPropertyValue value, int[] nested);
        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Transactional property setting

        protected void SetValue<TProperty>(Action<TProperty> setter, TProperty oldValue, TProperty newValue, string notifyPropertyName, int propertyOrder)
        {
            //activate for write if it is not activated yet
            if (ActivationStatus != ActivationStatus.ActivatedReadWrite)
                ((IPersistEntity)this).Activate(true);

            //just set the value if the model is marked as non-transactional
            if (!Model.IsTransactional)
            {
                setter(newValue);
                NotifyPropertyChanged(notifyPropertyName);
                return;
            }

            //check there is a transaction
            var txn = Model.CurrentTransaction;
            if (txn == null) throw new Exception("Operation out of transaction.");

            Action doAction = () =>
            {
                setter(newValue);
                NotifyPropertyChanged(notifyPropertyName);
            };
            Action undoAction = () =>
            {
                setter(oldValue);
                NotifyPropertyChanged(notifyPropertyName);
            };
            doAction();

            //do action and THAN add to transaction so that it gets the object in new state
            txn.AddReversibleAction(doAction, undoAction, this, ChangeType.Modified, propertyOrder);
        }

        #endregion

        #region Equals & GetHashCode
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
                return true;

            var entity = obj as IPersistEntity;
            if (entity == null) return false;

            return EntityLabel.Equals(entity.EntityLabel) && Model.Equals(entity.Model);
        }
        public override int GetHashCode()
        {
            //good enough as most entities will be in collections of  only one model, equals distinguishes for model
            return EntityLabel.GetHashCode();
        }
        #endregion

        #region Equality operators
        public static bool operator ==(PersistEntity left, object right)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(left, right))
                return true;

            // If one is null, but not both, return false.
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            var entity = right as IPersistEntity;
            if (ReferenceEquals(entity, null))
                return false;

            return (left.EntityLabel == entity.EntityLabel) && left.Model.Equals(entity.Model);

        }

        public static bool operator !=(PersistEntity left, object right)
        {
            return !(left == right);
        }
        #endregion
    }
}