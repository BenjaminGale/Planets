namespace Planets.Domain
{
    public class Planet
    {
        public static readonly Planet Mercury = new("Mercury", 4_879, 57_900_000, 0.330f, PlanetType.Rocky);
        public static readonly Planet Venus = new("Venus", 12_104, 108_200_000, 4.87f, PlanetType.Rocky);
        public static readonly Planet Earth = new("Earth", 12_756, 149_600_000, 5.97f, PlanetType.Rocky);
        public static readonly Planet Mars = new("Mars", 6_792, 227_900_000, 0.642f, PlanetType.Rocky);
        public static readonly Planet Jupiter = new("Jupiter", 142_984, 778_600_000, 1898f, PlanetType.GasGiant);
        public static readonly Planet Saturn = new("Saturn", 120_536, 1_433_500_000, 568f, PlanetType.GasGiant);
        public static readonly Planet Uranus = new("Uranus", 51_118, 2_872_500_000, 86.8f, PlanetType.IceGiant);
        public static readonly Planet Neptune = new("Neptune", 49_528, 4_495_100_000, 102f, PlanetType.IceGiant);

        private Planet(
            string name,
            float diameterKm,
            float distanceFromSunKm,
            float massKg,
            PlanetType type)
        {
            Name = name;
            DiameterKm = diameterKm;
            DistanceFromSunKm = distanceFromSunKm;
            MassKg = massKg;
            Type = type;
        }

        public string Name { get; }

        public float DiameterKm { get; }

        public float DistanceFromSunKm { get; }

        public float MassKg { get; }

        public PlanetType Type { get; }
    }
}
