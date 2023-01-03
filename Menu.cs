namespace Shoho.ConsoleMenu {
    public class Menu {
        private string[] elements = { };
        private ConsoleColor foreground;
        private ConsoleColor background;
        private ConsoleColor highlightFg;
        private ConsoleColor highlightBg;
        private int longestElementSize = 0;


        public ConsoleColor Foreground {
            set {
                this.foreground = value;
            }
        }

        public ConsoleColor Background {
            set {
                this.background = value;
            }
        }

        public ConsoleColor HighlightBg {
            set {
                this.highlightBg = value;
            }
        }

        public ConsoleColor HighlightFg {
            set {
                this.highlightFg = value;
            }
        }

        public Menu(string[] elements) {
            this.elements = elements;

            for(int i = 0; i < this.elements.Length; i++) {
                if(this.longestElementSize < this.elements[i].Length) {
                    this.longestElementSize = this.elements[i].Length;
                }
            }

            this.foreground = ConsoleColor.White;
            this.background = ConsoleColor.Blue;
            this.highlightFg = ConsoleColor.Blue;
            this.highlightBg = ConsoleColor.White;
        }

        public int Show() {
            ConsoleColor prevBg = Console.BackgroundColor;
            ConsoleColor prevFg = Console.ForegroundColor;

            int currentPosition = 0;

            while(true) {
                Console.SetCursorPosition(0, 0);
                for(int i = 0; i < this.elements.Length; i++) {
                    if(i == currentPosition) {
                        Console.BackgroundColor = this.highlightBg;
                        Console.ForegroundColor = this.highlightFg;
                    } else {
                        Console.BackgroundColor = this.background;
                        Console.ForegroundColor = this.foreground;
                    }

                    string s = this.elements[i];

                    Console.WriteLine(s.PadLeft(5).PadRight(s.Length + 5 + this.longestElementSize + 3));
                }

                ConsoleKey pressed = Console.ReadKey().Key;

                if(pressed == ConsoleKey.UpArrow) {
                    if(currentPosition > 0) {
                        currentPosition--;
                    }
                }

                if(pressed == ConsoleKey.DownArrow) {
                    if(currentPosition < this.elements.Length - 1) {
                        currentPosition++;
                    }
                }

                if(pressed == ConsoleKey.Enter) {
                    Console.ForegroundColor = prevFg;
                    Console.BackgroundColor = prevBg;
                    Console.Clear();
                    return currentPosition;
                }

                if(pressed == ConsoleKey.Escape) {
                    Console.ForegroundColor = prevFg;
                    Console.BackgroundColor = prevBg;
                    Console.Clear();
                    return -1;
                }
            }
        }
    }
}