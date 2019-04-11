using SwinGameSDK;

/// <summary>

/// ''' The EndingGameController is responsible for managing the interactions at the end

/// ''' of a game.

/// ''' </summary>
/// 

static class EndingGameController
{

    /// <summary>
    ///     ''' Draw the end of the game screen, shows the win/lose state
    ///     ''' </summary>
    public static void DrawEndOfGame()
    {
        Rectangle toDraw = null;
        string whatShouldIPrint;

        DrawField(ComputerPlayer.PlayerGrid, ComputerPlayer, true);
        DrawSmallField(HumanPlayer.PlayerGrid, HumanPlayer);

        toDraw.X = 0;
        toDraw.Y = 250;
        toDraw.Width = SwinGame.ScreenWidth();
        toDraw.Height = SwinGame.ScreenHeight();

        if (HumanPlayer.IsDestroyed)
            whatShouldIPrint = "YOU LOSE!";
        else
            whatShouldIPrint = "-- WINNER --";

        //SwinGame.DrawTextLines(whatShouldIPrint, Color.White, Color.Transparent, GameResources.GameFont("ArialLarge"), FontAlignment.AlignCenter, toDraw); // OG VB code
        SwinGame.DrawText(whatShouldIPrint, Color.White, Color.Transparent, GameResources.GameFont("ArialLarge"), FontAlignment.AlignCenter, toDraw); // made to replace above line
    }

    /// <summary>
    ///     ''' Handle the input during the end of the game. Any interaction
    ///     ''' will result in it reading in the highsSwinGame.
    ///     ''' </summary>
    public static void HandleEndOfGameInput()
    {
        if (SwinGame.MouseClicked(MouseButton.LeftButton) || SwinGame.KeyTyped(KeyCode.ReturnKey) || SwinGame.KeyTyped(KeyCode.EscapeKey))
        {
            ReadHighScore(HumanPlayer.Score);
            EndCurrentState();
        }
    }
}



