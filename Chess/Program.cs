namespace Chess {
    internal class Program {
        static void Main() {
            // Initialize variables
            string pieces = "rnbqkbnrpppppppp                                PPPPPPPPRNBQKBNR";
            int turn = 1;

            while (true) {

                // Draw board
                DrawBoard(pieces);

                // Prompt
                Console.WriteLine($"\nTurn {turn}\nIt is " + (turn % 2 == 1 ? "UPPERCASE" : "lowercase") + "'s turn.\nChoose a piece or type \"%q\" to quit.");

                // Pick piece
                while (true) {
                    string selectedPiece = Console.ReadLine();

                    // Check if the user wants to quit playing this epic game :(
                    if (selectedPiece == "%q") {
                        Console.Clear();
                        Console.WriteLine("Thanks for playing!");
                        return;
                    }
                    
                    // Check for invalid input
                    else if (selectedPiece.Length != 2 || !int.TryParse(selectedPiece.Substring(1,1), out int pieceRow)) Console.WriteLine("Invalid input - Expected a position. Example: b2");
                    else {
                        // Get column number
                        int pieceColumn = (int)selectedPiece.ToUpper()[0] - 64;

                        // Check if the position is outside the bounds of the board
                        if (pieceRow < 1 || pieceRow > 8 || pieceColumn < 1 || pieceColumn > 8) Console.WriteLine("Invalid input - Out of bounds.");
                        else {
                            // Get piece as a character
                            char piece = pieces[(pieceRow - 1) * 8 + (pieceColumn - 1)];

                            // Check if piece does not exist
                            if (pieces[(pieceRow - 1) * 8 + (pieceColumn - 1)] == ' ') Console.WriteLine("Invalid input - no piece at this position.");

                            // Check if the other player owns the piece
                            else if (turn % 2 == 1 && !char.IsUpper(piece) || turn % 2 == 0 && char.IsUpper(piece)) Console.WriteLine("Invalid input - This piece does not belong to you!");

                            else {

                                // Prompt
                                Console.WriteLine($"Selected ${selectedPiece.ToLower()} ({piece})\nChoose a sqaure to move to or type \"%c\" to cancel.");

                                // Pick square
                                while (true) {
                                    string selectedSquare = Console.ReadLine();

                                    // Check if the user wants to cancel
                                    if (selectedSquare == "%c") {
                                        Console.Clear();
                                        DrawBoard(pieces);
                                        Console.WriteLine($"\nTurn {turn}\nIt is " + (turn % 2 == 1 ? "UPPERCASE" : "lowercase") + "'s turn.\nChoose a piece or type \"%q\" to quit.");
                                        break;
                                    }
                                    // Check for invalid input
                                    else if (selectedSquare.Length != 2 || !int.TryParse(selectedSquare.Substring(1, 1), out int squareRow)) Console.WriteLine("Invalid input - Expected a position. Example: b2");
                                    else {
                                        // Get column number
                                        int squareColumn = (int)selectedSquare.ToUpper()[0] - 64;

                                        // Check if the position is outside the bounds of the board
                                        if (squareRow < 1 || squareRow > 8 || squareColumn < 1 || squareColumn > 8) Console.WriteLine("Invalid input - Out of bounds.");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        static void DrawBoard(string pieces) {

            // Divider line
            string div = "   +---+---+---+---+---+---+---+---+";

            // Write out the column names
            Console.WriteLine("     a   b   c   d   e   f   g   h  ");

            // Iterate through the board
            for (int i = 0; i < 9; i++) {

                // Draw divider
                Console.WriteLine(div);

                if (i == 8) break;
                string row = "|";

                // Iterate through the row and add it to the row string 
                for (int j = 0; j < 8; j++) row += $" {pieces[i * 8 + j]} |";
                
                // Draw row
                Console.WriteLine($" {i + 1} {row}");
            }
        }
    }
}
