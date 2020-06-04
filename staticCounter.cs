namespace GraSzachy
{
    class staticCounter
    {
        private static int Id = 1;

        public static int Next()
        {
            return Id++;
        }
        public static void Reset()
        {
            Id = 1;
        }
    }
}
