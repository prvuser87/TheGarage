namespace TheGarage.Services.Logic.Contracts
{
    using System;

    using TheGarage.Services.Common;

    public interface IObjectFactory
    {
        T GetInstance<T>();

        object GetInstance(Type type);

        T TryGetInstance<T>();

        object TryGetInstance(Type type);
    }
}
