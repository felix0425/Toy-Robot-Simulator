using System;

namespace Toy
{
    public enum Direction { NORTH, EAST, SOUTH, WEST };
    public class Robot
    {
        private int pos_x;
        private int pos_y;
        private Direction dir;
        private int min_x;
        private int min_y;
        private int max_x;
        private int max_y;

        public Robot()
        {
            this.pos_x = -1;
            this.pos_y = -1;
            this.dir = Direction.NORTH;
            this.min_x = -1;
            this.min_y = -1;
            this.max_x = -1;
            this.max_y = -1;
        }

        public void setBoard(int x1, int y1, int x2, int y2)
        {
            this.min_x = x1;
            this.min_y = y1;
            this.max_x = x2;
            this.max_y = y2;
        }

        public void getBoard(ref int x1, ref int y1, ref int x2, ref int y2)
        {
            x1 = this.min_x;
            y1 = this.max_y;
            x2 = this.min_x;
            y2 = this.max_y;
        }

        public bool onTable()
        {
            return (pos_x >= min_x && pos_x <= max_x && pos_y >= min_y && pos_y <= max_y);
        }

        public void setPos_x(int x)
        {
            this.pos_x = x;
        }

        public int getPos_x()
        {
            return this.pos_x;
        }

        public void setPos_y(int y)
        {
            this.pos_y = y;
        }

        public int getPos_y()
        {
            return this.pos_y;
        }

        public void setDir(Direction d)
        {
            this.dir = d;
        }

        public Direction getDir()
        {
            return this.dir;
        }

    }

    public class Program
    {
        public void Place(ref Robot r, int x, int y, Direction f)
        {
            r.setPos_x(x);
            r.setPos_y(y);
            r.setDir(f);
        }

        public void Move(ref Robot r)
        {
            int minX = -1, minY = -1, maxX = -1, maxY = -1;
            r.getBoard(ref minX, ref minY, ref maxX, ref maxY);
            if (r.getDir() == Direction.NORTH && r.getPos_y() < maxY)
                r.setPos_y(r.getPos_y() + 1);
            else if (r.getDir() == Direction.SOUTH && r.getPos_y() > minY)
                r.setPos_y(r.getPos_y() - 1);
            else if (r.getDir() == Direction.EAST && r.getPos_x() < maxX)
                r.setPos_x(r.getPos_x() + 1);
            else if (r.getDir() == Direction.WEST && r.getPos_x() > minX)
                r.setPos_x(r.getPos_x() - 1);
        }

        public void Left(ref Robot r)
        {
            if ((int)r.getDir() == 0)
                r.setDir((Direction) 3);
            else
                r.setDir((Direction) ((int)r.getDir()- 1));
        }

        public void Right(ref Robot r)
        {
            if ((int)r.getDir() == 3)
                r.setDir((Direction) 0);
            else
                r.setDir((Direction)((int)r.getDir() + 1));
        }

        public void Report(ref Robot r)
        {
            Console.WriteLine(r.getPos_x() + "," + r.getPos_y() + "," + r.getDir());
        }

        public void Add(String comm, ref Robot r)
        {
            Program p = new Program();
            StringComparison comparison = StringComparison.InvariantCulture;
            if (comm.StartsWith("PLACE", comparison))
            {
                string[] temps = comm.Split(' ');
                if (temps.Length == 2)
                {
                    string[] paras = temps[1].Split(',');
                    if (paras.Length == 3)
                    {
                        int x, y;
                        Direction f;
                        if (int.TryParse(paras[0], out x) && int.TryParse(paras[1], out y) && Enum.TryParse(paras[2], false, out f))
                            p.Place(ref r, x, y, f);
                    }
                }
            }
            else if (r.onTable())
            {
                if (comm.StartsWith("MOVE", comparison))
                    p.Move(ref r);
                else if (comm.StartsWith("LEFT", comparison))
                    p.Left(ref r);
                else if (comm.StartsWith("RIGHT", comparison))
                    p.Right(ref r);
                else if (comm.StartsWith("REPORT", comparison))
                    p.Report(ref r);
            }
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            Robot myRobot = new Robot();
            myRobot.setBoard(0, 0, 4, 4);
            string line;
            while ((line = Console.ReadLine()) != null)
                p.Add(line, ref myRobot);
        }
    }
}
