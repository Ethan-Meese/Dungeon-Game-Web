using System.Net;
using backend.Core.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
namespace backend.Core;

public class GameEngine
{

    /* 
    TODO
    make attack option give 3 attack options and make message = the attack damages and their costs.
    impliment showing Level and stats - make a button to display message of player stats
    fix scaling
    organize some code - make functions to clean up
    Make more attacks for the player
    multiple messages. (make a list instead of just a single string)
    
    */

    private GameState _state = new();
    private Random random = new();

    // Starts the game with the inital setup
    public GameState StartGame()
    {
        _state = new GameState
        {
            Player = new Player(),
            DungeonLevel = 0,
            CurrentRoom = new Room
            {
                Name = "Dungeon Entrance",
                Description = "You stand in a dark empty cavern, your furture remains unknown.",
                Enemies = [],
            },
            Options = ["Enter Dungeon"],
            Message = "Welcome, Adventurer. You're Destiny Awaits..."
        };
        return _state;
    }

    public GameState ProcessAction(string action)
    {
        switch (action)
        {
            case "Enter Dungeon":
                EnterDungeon();
                break;
            case "Continue Ahead":
                ContinueAhead();
                break;
            case "Attack":
                Attack();
                break;
            /*case "Run":
                Run();
                break;
            case "Look Around":
                LookAround();
                break; */
            case "Rest":
                Rest();
                break;
            case "Restart":
                StartGame();
                break;
            default:
                _state.Message = "Invalid Action.";
                break;
        }
        // returns updated state to the front end after an action
        return _state;

    }

    private void GenerateRoom()
    {
        string[] roomDescriptions =
        {
            "This room is dark and damp, the stone walls are covered in moss. There is a single tree in the middle of the room that gives off a faint glow, it's roots are growing through the stone floor and the branches are reaching up to the ceiling above...",
            "This room is filled with the sound of running water, the walls are covered in a thick layer of slime and the air is thick giving off a foul smell. Groans can be heard in the distance, the sound of the undead echo through the halls of the dungeon...",
            "This room is filled with the remains of the fallen warriors that came beore you. Skulls and bones fill the floor, everystep leads to an echoing crunch beneith your feet. Pillers surround you in every direction; fading into the darkness that lies ahead...",
            "This room is filled with water up to your knees. You can hear the sound of water dripping from the ceiling, torches faintly line the narrow stone walls leading you down the one and only way out...",
            "The room is a black void, the only thing you can see is the light from the torch you hold in your hand. The sound of your footsteps echo through the room, the sound of your own breathing is the only thing that keeps you company...",
            "The room is filled with the sound of the wind, the walls are covered in a thick layer of dust and cobwebs. The air is dry and the sound of your footsteps echo through the room. The only thing that can be seen is the light from the torch you hold in your hand...",
            "The room is a dark void with an old ruined castle like structure in the middle thats dimly light. The room seems to be endless in all directions, the only way seems to be through the castle like structure in the middle of the room...",
            $"The room is filled with old stone statues, their gaze seems fixated on you at all times. Your footsteps echo throughout. There is a single jailcell, the door is wide open, etched at the top of the door is your name... {_state.Player.Name}",
            "Peace, Calm, and Serenity. The room is filled with the sound of birds chirping and the smell of fresh flowers. The room is filled with a bright light... As you take your first step into the room, the door behind you slams shut and the room turns dark...",
            "You enter a narrow corridor, the walls adorned with faded tapestries depicting long-forgotten battles. The air is heavy with the scent of dampness and old parchment. The corridor twists and turns, leaving you uncertain of what lies around the next corner...",
            "The room is filled with the haunting melodies of a distant harpsichord. Tattered curtains sway in an unseen breeze, revealing glimpses of a moonlit courtyard. Shadows dance along the walls, and the air is thick with an eerie stillness...",
            "A dense fog blankets the floor of this room, making it difficult to see more than a few feet ahead. Muffled footsteps and ghostly whispers echo, creating an unsettling atmosphere. As the fog swirls, shapes of long-forgotten furniture come into view...",
            "You find yourself in an ancient library, shelves towering high with dusty tomes. Flickering candlelight casts long shadows, and the air is filled with the scent of aged leather and parchment. A lone desk sits in the center, a quill and inkwell awaiting use...",
            "The room is adorned with faded banners bearing the insignia of a noble house. Broken armor and shattered weapons litter the floor, remnants of a forgotten conflict. A faint draft carries the distant sound of howling wolves, adding to the ominous ambiance...",
            "This room is an underground crypt, lined with sarcophagi that seem to go on endlessly. Cobwebs drape across stone slabs, and the air is thick with the musty odor of decay. Faint whispers and rattling chains echo, as if the spirits of the entombed linger...",
            "The room is bathed in an otherworldly glow emanating from a mystical portal. Ancient runes adorn the walls, pulsating with an ethereal energy. Shadows dance and shift, creating illusions that play tricks on the mind. The air crackles with a sense of arcane power...",
        };
        string randomRoomDescription = roomDescriptions[random.Next(roomDescriptions.Length)];

        _state.DungeonLevel += 1;
        int enemyCount = random.Next(0, 3 + _state.DungeonLevel);

        _state.CurrentRoom = new Room
        {
            Name = $"Dungeon Room: {_state.DungeonLevel}",
            Description = randomRoomDescription,
            Enemies = []
        };

        for (int i = 0; i < enemyCount; i++)
        {
            _state.CurrentRoom.Enemies.Add(EnemyFactory.CreateRandomEnemy(_state.DungeonLevel));
        }

        if (_state.CurrentRoom.Enemies.Count > 0)
        {
            _state.Message = $"You encounter {enemyCount} {(enemyCount > 1 ? "enemies" : "enemy")}!";
            _state.Options = ["Attack", "Run"];
        }
        else
        {
            _state.Message = "The room is eerily quiet...";
            _state.Options = ["Continue Forward", "Rest", "Look Around"];
        }

    }

    private void ContinueAhead()
    {
        // Maybe add a eerie message as you go deeper into the dungeon
        GenerateRoom();
    }

    private void EnterDungeon()
    {
        // Maybe add a eerie message as you go deeper into the dungeon
        GenerateRoom();
    }

    public void Attack()
    {
        // do the attack stuff
        if (_state.Player.IsAlive && _state.CurrentRoom.Enemies.Count > 2)
        {
            for (int i = 0; i < 3; i++)
            {
                _state.CurrentRoom.Enemies[i].Health -= _state.Player.AttackDamage;
            }
        }
        else if (_state.CurrentRoom.Enemies.Count == 2)
        {
            for (int i = 0; i < 2; i++)
            {
                _state.CurrentRoom.Enemies[i].Health -= _state.Player.AttackDamage;
            }
        }
        else if (_state.CurrentRoom.Enemies.Count == 1)
        {
            _state.CurrentRoom.Enemies[0].Health -= _state.Player.AttackDamage;
        }

        _state.Message = $"You delt {_state.Player.AttackDamage}. \n You took {_state.CurrentRoom.Enemies[0].AttackDamage}";    
        _state.Player.Health -= _state.CurrentRoom.Enemies[0].AttackDamage;
        _state.CurrentRoom.Enemies.RemoveAll(e => e.Health <= 0);


        if (_state.Player.IsAlive && _state.CurrentRoom.Enemies.Count == 0)
        {
            _state.Player.AddXP(25 + _state.DungeonLevel * 2);
            _state.Message = $"The room is Cleared! You gained {25 + _state.DungeonLevel * 2} XP";
            _state.Options = ["Continue Ahead", "Rest"];
            return;
        }
        
        if (_state.Player.IsAlive == false)
        {
            _state.Message = "Game Over you died.";
            _state.IsGameOver = true;
            _state.Options = ["Restart"];
        }
    }
    private void Rest()
    {
        if (_state.Player.Health != _state.Player.MaxHealth)
        {
            int healthHealed = random.Next(6, 30);
            _state.Player.AddHealth(healthHealed);
            _state.Message = $"You feel rejuvinated, you healed {(_state.Player.Health == _state.Player.MaxHealth ? "to max health" : healthHealed)}";
        }
        else
        {
            _state.Message = "You surprisingly feel well rested. Only you wish you had a cup of joe to feel more at home. -10 Mental Stability";
        }

        _state.Options = ["Continue Ahead"];
    }
    
    /* Maybe add later
    public void Run()
    {
        // harder to run if many eneimes

    }
    */

    // gets current gamestate
    public GameState GetState() => _state;
}
