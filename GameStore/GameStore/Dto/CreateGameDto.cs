namespace GameStore.Dto
{
    public record class CreateGameDto(
        int id,
        string Name,
        decimal Price,
        string Genre,
        DateOnly ReleaseDate);
    
}
