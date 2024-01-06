# Checkers Solitaire

<P align=center><IMG src="http://www.addressof.com/assets/img/checkers_solitaire_v0.1.9.png"><BR><EM>Shown with Hints enabled. (v0.1.9)</EM></P>

An original game by designed by Cory Smith that is inspired by "[One Check](http://www.atariarchives.org/basicgames/showpage.php?page=122)" written circa 1978 by David H. Ahl.

The simplest way to get started with the code is to use [Microsoft Visual Studio 2022 Community Edition](https://visualstudio.microsoft.com/) (It's FREE!).

## Gameplay

The object of the game is to remove as many pieces as possible by diagonally jumping other pieces (as in standard checkers).  The standard game consists of a 64-square board (8 by 8) and 48 game pieces.  It's relatively easy to remove 30 to 39 pieces, extremely challenging to remove 40 to 44 and nearly impossible to remove 45 to 47.

## Features

- Complete undo history (per game). 
- View history, so you can see what moves you made. 
- Hint mode.  Shows what pieces can and can't be moved in different colors. 
- As you drag a piece, you get instant feedback as to whether you can place the piece on the board. 
- Ability to specify custom board configurations (standard game is 8 by 8 with a depth of 2; meaning 48 pieces). 
- Settings are persisted, such as window location, size, status bar being displayed, hint mode and custom board settings. 
- (0.1.6) Ability to save history to a .csv formatted file. 
- (0.1.6) Ability to load history from a .csv formatted file; allows you to watch the game being played.  Can configure the wait time between moves and press ESC to fast forward to the end of the replay. 
- (0.1.6) Can use CTRL+A to select all of the items in the history and CTRL+C to copy them into the clipboard (in .csv format). 
- (0.1.7) .csv format modified to support different size board configurations.
- (0.1.7) Allows you to not only save the history of your game, but you can now prove to your friends that you actually did get the score you say you did. ;-)
- (0.1.8) Made the move to WinForms on .NET 5!!!
- (0.1.8a) Made the move to .NET 6.
- (0.1.8b) Made the move to .NET 7.
- (0.1.9) Made the move to .NET 8; fixed Application.ProductVersion issue; totally refactored.

## History

This game was inspired by a game written by David H. Ahl that was published in a book written circa 1978 called [Basic Computer Games: Microcomputer Edition](http://www.atariarchives.org/basicgames/).  I started with the description of the game (which contained the rules) and wrote Checkers Solitaire from there.

If your interested in finding out more about the game that inspired this one, you can actually read all about it yourself thanks to [AtariArchives.org](http://www.atariarchives.org/).  David's version of the game is called "[One Check](http://www.atariarchives.org/basicgames/showpage.php?page=122)" (following this link will take you to a scanned image of the pages from the book).  

This project was originally made available on [AddressOf.com](http://addressof.com) back in 2005 and then moved to GitHub (here) in 2012 with little to no changes. At the beginning of 2021, due to the release of .NET 5 and initial (official) support for Windows Forms on the new .NET "Core" platform, the project was migrated.

## Notes

Currently, the game is pretty complete.  As with any development, there are still additional ideas... as to whether or not I'll continue development, time will only tell.  Some of this will probably depend on the interest and feedback.  It think it's a pretty cool game considering the time I have invested in putting it together.  Lemme know what you think. Also, this version has had limiting testing, so if you do find a problem, be sure to let me know.

## Discord

Please reach out to me on Discord:

- [Discord Invite](https://discord.gg/Y8EH5fF6WG)

## Special Thanks

Thanks to [Jason Bock](https://github.com/JasonBock) for testing and providing feedback (all those years ago).
