using System.Linq;
using FMS.API.Minimal.Repositories;
using NUnit.Framework;

namespace FMS.API.Tests;

public class CityServiceTests
{
    [TestCase("Raleigh, NC", true)]
    [TestCase("typo", false)]
    [TestCase("", false)]
    public void IsValidCity_GetCity_ReturnsTrue(string name, bool expected)
    {
        // arrange
        CityRepository repo = new();
        var list = repo.GetAll().ToList();

        // act
        bool result = list.Contains(name); 

        // assert
        Assert.AreEqual(expected, result);
    }

    [TestCase(4, true)]
    [TestCase(5, false)]
    [TestCase(0, false)]
    public void IsValidCount_GetCity_ReturnsTrue(int count, bool expected)
    {
        // arrange
        CityRepository repo = new();
        var list = repo.GetAll().ToList();

        // act
        bool result = list.Count() == count;

        // assert
        Assert.AreEqual(expected, result);
    }
}