namespace admob {
    public class AdSize {
        private int width;
        private int height;

        public static readonly AdSize BANNER = new AdSize(320, 50);
        public static readonly AdSize FULL_BANNER = new AdSize(468, 60);
        public static readonly AdSize LARGE_BANNER = new AdSize(320, 100);
        public static readonly AdSize LEADERBOARD = new AdSize(728, 90);
        public static readonly AdSize MEDIUM_RECTANGLE = new AdSize(300, 250);
        public static readonly AdSize WIDE_SKYSCRAPER = new AdSize(160,600);
        public static readonly AdSize SMART_BANNER = new AdSize(-1,-2);//32,50,90

        public AdSize(int width, int height) {
            this.width = width;
            this.height = height;
        }

        public int Width
        {
            get
            {
                return width;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
        }
    }
}
