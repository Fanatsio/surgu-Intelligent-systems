namespace HorseStep
{
    public partial class Form1 : Form
    {
        private const int CellSize = 50;

        public Form1()
        {
            InitializeComponent();
        }

        private void DrawChessBoard(int width, int height, List<Point> path)
        {
            panel1.Controls.Clear();
            panel1.Size = new Size(width * CellSize + CellSize, height * CellSize + CellSize);

            for (int col = 0; col < width; col++)
            {
                var colLabel = new Label
                {
                    Size = new Size(CellSize, CellSize),
                    Location = new Point(CellSize + col * CellSize, 0),
                    Text = (col + 1).ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 12),
                    BackColor = Color.LightGray
                };
                panel1.Controls.Add(colLabel);
            }

            for (int row = 0; row < height; row++)
            {
                var rowLabel = new Label
                {
                    Size = new Size(CellSize, CellSize),
                    Location = new Point(0, CellSize + row * CellSize),
                    Text = (row + 1).ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 12),
                    BackColor = Color.LightGray
                };
                panel1.Controls.Add(rowLabel);
            }

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    var cell = new Panel
                    {
                        Size = new Size(CellSize, CellSize),
                        Location = new Point(CellSize + col * CellSize, CellSize + row * CellSize),
                        BackColor = (row + col) % 2 == 0 ? Color.White : Color.Black
                    };
                    panel1.Controls.Add(cell);

                    var point = new Point(col, row);
                    int stepNumber = path.IndexOf(point) + 1;
                    if (stepNumber > 0)
                    {
                        var numberLabel = new Label
                        {
                            Size = new Size(CellSize, CellSize),
                            Location = new Point(0, 0),
                            Text = stepNumber.ToString(),
                            ForeColor = Color.Red,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = new Font("Arial", 12, FontStyle.Bold),
                            BackColor = Color.Transparent
                        };
                        cell.Controls.Add(numberLabel);
                    }
                }
            }
        }

        private static List<Point> FindKnightTour(int boardWidth, int boardHeight, Point start)
        {
            var moves = new (int dx, int dy)[]
            {
                (2, 1), (1, 2), (-1, 2), (-2, 1),
                (-2, -1), (-1, -2), (1, -2), (2, -1)
            };

            bool IsValid(int x, int y, bool[,] visited) =>
                x >= 0 && x < boardWidth && y >= 0 && y < boardHeight && !visited[x, y];

            int GetDegree(int x, int y, bool[,] visited)
            {
                int degree = 0;
                foreach (var move in moves)
                {
                    int nextX = x + move.dx;
                    int nextY = y + move.dy;
                    if (IsValid(nextX, nextY, visited))
                        degree++;
                }
                return degree;
            }

            var path = new List<Point> { start };
            var visitedCells = new bool[boardWidth, boardHeight];
            visitedCells[start.X, start.Y] = true;

            int currentX = start.X;
            int currentY = start.Y;

            for (int step = 1; step < boardWidth * boardHeight; step++)
            {
                var possibleMoves = new List<(int x, int y)>();

                foreach (var move in moves)
                {
                    int nextX = currentX + move.dx;
                    int nextY = currentY + move.dy;
                    if (IsValid(nextX, nextY, visitedCells))
                    {
                        possibleMoves.Add((nextX, nextY));
                    }
                }

                if (possibleMoves.Count == 0)
                {
                    return new List<Point>();
                }

                var nextMove = possibleMoves
                    .Select(m => new
                    {
                        Move = m,
                        Degree = GetDegree(m.x, m.y, visitedCells)
                    })
                    .OrderBy(m => m.Degree)
                    .First();

                currentX = nextMove.Move.x;
                currentY = nextMove.Move.y;
                path.Add(new Point(currentX, currentY));
                visitedCells[currentX, currentY] = true;
            }
            return path;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int width) || width <= 0 ||
                !int.TryParse(textBox2.Text, out int height) || height <= 0 ||
                !int.TryParse(textBox3.Text, out int startX) || startX < 1 || startX > width ||
                !int.TryParse(textBox4.Text, out int startY) || startY < 1 || startY > height)
            {
                MessageBox.Show("Пожалуйста, введите корректные значения.");
                return;
            }

            Point start = new Point(startX - 1, startY - 1);

            var path = FindKnightTour(width, height, start);
            if (path.Count > 0)
            {
                DrawChessBoard(width, height, path);
                MessageBox.Show("Решение найдено!");
            }
            else
            {
                MessageBox.Show("Решение не найдено.");
            }
        }
    }
}
