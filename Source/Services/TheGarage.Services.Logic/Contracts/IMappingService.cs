﻿using TheGarage.Services.Common;

namespace TheGarage.Services.Logic.Contracts
{

    public interface IMappingService
    {
        T Map<T>(object source);

        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
