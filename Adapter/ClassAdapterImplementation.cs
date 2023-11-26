using System;
namespace ClassAdapter
{
    public class CityFromExternalSystem
    {
        public string Name { get; private set; }
        public string Nickname { get; private set; }
        public int Inhabitants { get; private set; }

        public CityFromExternalSystem(string name, string nickname, int inhabitants)
        {
            Name = name;
            Nickname = nickname;
            Inhabitants = inhabitants;
        }
    }

    /// <summary>
    /// Adaptee
    /// </summary>
    public class ExternalSystem
    {
        public CityFromExternalSystem GetCity()
        {
            return new CityFromExternalSystem("Beograd", "Bege", 100);
        }
    }

    public class City
    {
        public string FullName { get; private set; }
        public long Inhabitants { get; private set; }

        public City(string fullname, long inhabitants)
        {
            FullName = fullname;
            Inhabitants = inhabitants;
        }
    }

    /// <summary>
    /// Target
    /// </summary>
    public interface ICityAdapter
    {
        City GetCity();
    }

    /// <summary>
    /// Adapter
    /// </summary>
    public class CityAdapter : ExternalSystem,ICityAdapter
    {
        public City GetCity()
        {
            //call to external system
            var cityFromExternalSystem = base.GetCity();

            //adapt the external city to a city
            return new City($"{cityFromExternalSystem.Name} - {cityFromExternalSystem.Nickname}"
                , cityFromExternalSystem.Inhabitants);
        }
    }
}

