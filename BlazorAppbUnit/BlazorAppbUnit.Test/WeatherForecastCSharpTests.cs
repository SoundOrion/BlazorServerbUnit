using BlazorAppbUnit.Pages;
using BlazorAppbUnit.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazorAppbUnit.Test.Mock;

namespace BlazorAppbUnit.Test;

/// <summary>
/// These tests are written entirely in C#.
/// Learn more at https://bunit.dev/docs/getting-started/writing-tests.html#creating-basic-tests-in-cs-files
/// </summary>
public class WeatherForecastCSharpTests : TestContext
{
    [Fact]
    public void WeatherForecastExistsDataCase()
    {
        // set dummy record mock
        var forecasts = new List<WeatherForecast>();
        forecasts.Add(new WeatherForecast() { Date = new DateTime(2020, 5, 1), TemperatureC = 20, Summary = "Sunny" });
        forecasts.Add(new WeatherForecast() { Date = new DateTime(2020, 5, 2), TemperatureC = 10, Summary = "Rainy" });
        forecasts.Add(new WeatherForecast() { Date = new DateTime(2020, 5, 3), TemperatureC = 14, Summary = "Cloudy" });

        var mockService = new MockWeatherService();
        mockService.Task.SetResult(forecasts.ToArray());
        Services.AddSingleton<WeatherForecastService>(mockService);

        var fetchData = RenderComponent<FetchData>();

        // wait until table rendered
        fetchData.WaitForState(() => fetchData.FindAll(".table").Count > 0);

        var expectedHtml = @"<table class=""table"">
                                    <thead>
                                        <tr>
                                            <th>Date</th>
                                            <th>Temp. (C) </th>
                                            <th>Temp. (F) </th>
                                            <th>Summary </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                    <tr>
                                        <td>2020/05/01</td>
                                        <td>20</td>
                                        <td>67</td>
                                        <td>Sunny</td>
                                    </tr>
                                    <tr>
                                        <td>2020/05/02</td>
                                        <td>10</td>
                                        <td>49</td>
                                        <td>Rainy</td>
                                    </tr>
                                    <tr>
                                        <td>2020/05/03</td>
                                        <td>14</td>
                                        <td>57</td>
                                        <td>Cloudy</td>
                                    </tr>
                            </tbody>";
        fetchData.Find("table").MarkupMatches(expectedHtml);
    }
}


