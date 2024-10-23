namespace Chess {
    internal class Program {
        static void Main() {
            // Initialize variables
            string pieces = "pppppppprnbqkbnr                                PPPPPPPPRNBQKBNR";
            int turn = 1;

            while (true) {

                // Draw board
                DrawBoard(pieces);

                // Prompt
                Console.WriteLine("\nIt is " + (turn % 2 == 1 ? "UPPERCASE" : "lowercase") + "'s turn.\nChoose a piece or type \"%q\" to quit.");

                // Input loop
                while (true) {
                    string input = Console.ReadLine();

                    // Check if the user wants to quit playing this epic game :(
                    if (input == "%q") {
                        Console.Clear();
                        Console.WriteLine("Thanks for playing!");
                        return;
                    }

                    // Next turn
                    Console.Clear();
                    turn++;
                    break;
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
