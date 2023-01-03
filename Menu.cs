namespace Shoho.ConsoleMenu {
    public class Menu {
        private string[] elements = { };
        private string title = "";
        private ConsoleColor foreground;
        private ConsoleColor background;
        private ConsoleColor highlightFg;
        private ConsoleColor highlightBg;
        private int longestElementSize = 0;
        private int cursorX;
        private int cursorY;


        public string Title {
            set {
                this.title = value;
            }
        }

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

            this.cursorX = (Console.WindowWidth / 2) - ((this.longestElementSize / 2) + 5);
            this.cursorY = (Console.WindowHeight / 2) - (this.elements.Length / 2);
        }

        public int Show() {
            ConsoleColor prevBg = Console.BackgroundColor;
            ConsoleColor prevFg = Console.ForegroundColor;

            int currentPosition = 0;

            if(this.title != "") {
                this.cursorY -= 1;
                if(this.title.Length > this.longestElementSize) {
                    this.longestElementSize = this.title.Length;
                }
            }

            this.longestElementSize += 2;

            Console.SetCursorPosition(this.cursorX, this.cursorY);

            if(this.title != "") {
                string s = this.title;
                int paddingLeft = (this.longestElementSize - s.Length) / 2;
                int paddingRight = this.longestElementSize - s.Length - paddingLeft;
                

                s = s.PadLeft(paddingLeft + s.Length).PadRight(this.longestElementSize);

                Console.Write(s);
                this.cursorY += 1;
            }

            while(true) {
                for(int i = 0; i < this.elements.Length; i++) {
                    Console.SetCursorPosition(this.cursorX, this.cursorY + i);
                    if(i == currentPosition) {
                        Console.BackgroundColor = this.highlightBg;
                        Console.ForegroundColor = this.highlightFg;
                    } else {
                        Console.BackgroundColor = this.background;
                        Console.ForegroundColor = this.foreground;
                    }

                    string s = this.elements[i];
                    int paddingLeft = (this.longestElementSize - s.Length) / 2;
                    int paddingRight = this.longestElementSize - s.Length - paddingLeft;


                    s = s.PadLeft(paddingLeft + s.Length).PadRight(this.longestElementSize);

                    Console.Write(s);
                }

                Console.SetCursorPosition(0, 0);

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