 class Point
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Point(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public override bool Equals(object obj)
        {
            var otherPoint = obj as Point;

            if(otherPoint != null)
            {
                return otherPoint.Row == Row && otherPoint.Col == Col;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Row.GetHashCode() ^ Col.GetHashCode();
        }
    }