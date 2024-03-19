using GameStore.Dto;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGamesRouteName = "GetGames";

List<GameDto> games = [
    new (
        1,
        "The Witcher 3: Wild Hunt",
        "RPG",
        29.99m,
        new DateOnly(2015, 5, 19)),
    new (2,
        "Grand Theft Auto V",
        "Action",
        19.99m,
        new DateOnly(2013, 9, 17)),
    new (3,
        "The Elder Scrolls V: Skyrim",
         "RPG",
         39.99m,
         new DateOnly(2011, 11, 11))
    ];

// GET /games
 app.MapGet("/games", () => games);

// GET /games/{id}
app.MapGet("/games/{id}", (int id) => games.Find(game => game.Id == id))
    .WithName(GetGamesRouteName);

// POST /games
app.MapPost("/games", (CreateGameDto newGame) =>
{
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
        );

    games.Add(game);

    return Results.CreatedAtRoute(GetGamesRouteName, new {id = game.Id   }, game);
});

app.Run();
