using System.Threading.Tasks;
using BlazorAppbUnit.Data;
using System;

namespace BlazorAppbUnit.Test.Mock
{
    internal class MockWeatherService: WeatherForecastService
    {
        public TaskCompletionSource<WeatherForecast[]> Task { get; } = new TaskCompletionSource<WeatherForecast[]>();

        public override Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            return Task.Task;
        }
    }
}