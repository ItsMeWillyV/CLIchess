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
                    
                    // Check for invalid selectedPieces
                    else if (selectedPiece.Length != 2 || !int.TryParse(selectedPiece.Substring(1,1), out int pieceRow)) Console.WriteLine("Invalid input - expected a postion. Example: b2");
                    else {
                        // Get cloumn number
                        int pieceColumn = (int)selectedPiece.ToUpper()[0] - 64;

                        // Check if the position is outside the bounds of the board
                        if (pieceRow < 1 || pieceRow > 8 || pieceColumn < 1 || pieceColumn > 8) Console.WriteLine("Invalid input - out of bounds.");
                        else {
                            if (pieces[(pieceRow - 1) * 8 + (pieceColumn - 1)] == ' ') Console.WriteLine("Invalid input - no piece at this position.");


                            // Next turn
                            //Console.Clear();
                            //turn++;
                            //break;
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
