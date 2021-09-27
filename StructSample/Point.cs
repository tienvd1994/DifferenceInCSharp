namespace StructSample
{
    struct Point
    {
        // Không thể khởi tạo giá trị một instance field hoặc property khi khai báo nó.
        int x;
        int y;

        public int Age { get; set; }

        /// <summary>
        /// Khi định nghĩa struct constructor thì phải gán giá trị cho tất cả instance fields và properties.
        /// </summary>
        public Point(int x, int y, int age)
        {
            this.x = x;
            this.y = y; 
            Age = age;
        }
    }
}
