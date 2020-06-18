using System;
using System.Collections.Generic;
using System.Text;

namespace ASAN.Entities.BaseClases
{
    public abstract class BaseEntity : Interfaces.IAuditableEntity ,Interfaces.IKey64
    {
        #region Constructor

        public BaseEntity()
        {
        }

        #endregion Constructor

        #region Properties

        public Int64 Id { get; set; }

        #endregion Properties
    }
}