using backend.Core.Models;
namespace backend.Core;

public class GameEngine
{
    private GameState _state = new();

    // Starts the game with the inital setup
    public GameState StartGame()
    {
        _state = new GameState
        {
            Player = new Player(),
            CurrentRoom = new Room
            {
                Name = "Dungeon Entrance",
                Description = "You stand in a dark empty cavern, your furture remains unknown.",
                Enemies = [],
                Options = ["Enter Dungeon", "Check Inventory", "Rest"]
            },
            Message = "Welcome, Adventurer. You're Destiny Awaits..."
        };
        return _state;
    }

    public GameState ProcessAction(string action)
    {
        // makes a choice and sends it to the front end
        return _state;

    }

    public void HandleAttack()
    {
        // do the attack stuff
    }


    // updates current gamestate
    public GameState GetState() => _state;
}
