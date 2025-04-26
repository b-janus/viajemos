namespace viajemos.Data.Models.TripProposition;

public class TripProposition
{
    public int Id { get; init; }

    public string Name { get; init; } = "";

    public string Description { get; init; } = "";

    public string ImageUrl { get; init; } = "";

    public required IList<TripPropositionPlace> Places { get; init; }
    
    public DateTime StartDate { get; init; }
    
    public DateTime EndDate { get; init; }
    
    public int BudgetMax { get; init; }
    
    public int ParticipantsMin { get; init; }
    
    public int ParticipantsMax { get; init; }

    public required string OwnerId { get; init; }
    public required ApplicationUser Owner { get; init; }
}