using System;

namespace ServerPart.Contracts.DbContracts
{
    public interface IDbModel<T>
    {
        public Guid Id { get; }
    }
}
