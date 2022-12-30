namespace Shoho.ConsoleMenu {
    public class Menu {
        private List<String> elements = new List<String> {};
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

        public Menu(List<String> elements) {
            foreach(var element in elements) {
                if(this.longestElementSize < element.Length)
                    this.longestElementSize = element.Length;

                this.elements.Add(element);
            }

            this.foreground = ConsoleColor.White;
            this.background = ConsoleColor.Blue;
            this.highlightFg = ConsoleColor.Blue;
            this.highlightBg = ConsoleColor.White;
        }

        public int Show() {
            ConsoleColor prevBg = Console.BackgroundColor;
            ConsoleColor prevFg = Console.ForegroundColor;
            Console.BackgroundColor = this.background;
            Console.ForegroundColor = this.foreground;

            int currentPosition = 0;

            Console.Clear();

            // TODO: Showing and keypressing mechanic

            Console.ForegroundColor = prevFg;
            Console.BackgroundColor = prevBg;

            return -1;
        }
    }
}