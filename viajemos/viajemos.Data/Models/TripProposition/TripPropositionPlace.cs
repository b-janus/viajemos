namespace viajemos.Data.Models.TripProposition;

public record TripPropositionPlace
{
    public int Id { get; init; }
    
    /// <summary>
    /// This is too general, there should be something more specific, coordinates?
    /// </summary>
    public string Name { get; init; }
}