using Plugin.Connectivity.Abstractions;

namespace UniSales.Core.Contracts.Services.General
{
    public interface IConnectionService
    {
        bool IsConnected { get; }

        event ConnectivityChangedEventHandler ConnectivityChanged;
    }
}