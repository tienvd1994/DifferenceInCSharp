namespace FieldSample
{
    public class ClassSample
    {
        public int _number1 = 7;
        public int _number2 = 8;
        public static int _number3 = 999;
        public static int _number4 = 888;
        public readonly int _number5 = 555;
        
        static ClassSample()
        {
            _number3 = 100;
            _number4 = 889;
        }

        public ClassSample()
        {
            
        }
        
        public ClassSample(int number1, int number2)
        {
            _number1 = number1;
            _number2 = number2;
            _number3 = 1000;
            _number5 = 000;
        }
    }
}