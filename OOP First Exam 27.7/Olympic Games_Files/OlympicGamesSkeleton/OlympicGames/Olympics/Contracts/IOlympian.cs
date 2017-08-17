namespace OlympicGames.Olympics.Contracts
{
    public interface IOlympian : ICountry
    {
        string FirstName { get; }

        string LastName { get; }
    }
}
