namespace BikeStore.Common.Enums.Bike
{
    using System;

    [Flags]
    public enum BikeType
    {
        Road = 1,
        Track = 2,
        BMX = 4,
        Commuting = 8,
        CrossCountry = 16,
        Trail = 32,
        Enduro = 64,
        Downhill = 128,
        Electric = 256
    }
}
