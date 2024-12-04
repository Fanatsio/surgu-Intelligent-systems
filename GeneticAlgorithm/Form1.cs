namespace GeneticAlgorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < list.Length; i++)
            {
                List_of_things.Rows.Add();
                List_of_things.Rows[i].Cells[0].Value = (i + 1).ToString();
                List_of_things.Rows[i].Cells[1].Value = list[i].ToString();
                min_sum = min_sum_values[i];
                max_sum = max_sum_values[i];
                mas_of_min_sum[i] = min_sum;
                mas_of_max_sum[i] = max_sum;
                mas[i] = random.Next(min_sum, max_sum);
                mas2[i] = random.Next(min_sum, max_sum);
                List_of_things.Rows[i].Cells[2].Value = min_sum.ToString() + "-" + max_sum.ToString();
                mas_of_price[i] = prices[i];
                List_of_things.Rows[i].Cells[4].Value = prices[i].ToString();
                List_of_things.Rows[i].Cells[5].Value = mas[i].ToString();
                min_price += min_sum * prices[i];
                max_price += max_sum * prices[i];
            }
            label1.Text += "Диапозон цен: от " + min_price.ToString() + " до " + max_price.ToString();
        }

        private readonly Random random = new();

        private readonly int min_sum;
        private readonly int max_sum;
        private readonly int min_price;
        private readonly int max_price;
        private readonly int[] mas = new int[50];
        private readonly int[] mas2 = new int[50];
        private readonly int[] mas_of_price = new int[50];
        private readonly int[] mas_of_min_sum = new int[50];
        private readonly int[] mas_of_max_sum = new int[50];

        // Обработчик события завершения редактирования ячейки DataGridView
        private void List_of_things_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Обновление минимальной и максимальной сумм для каждой вещи
            for (int i = 0; i < list.Length; i++)
            {
                string min_and_max_sum = (string)List_of_things.Rows[i].Cells[2].Value;
                string[] tmep = min_and_max_sum.Split('-');
                mas_of_min_sum[i] = Int32.Parse(tmep[0]);
                mas_of_max_sum[i] = Int32.Parse(tmep[1]);
            }
        }

        private readonly string[] list = new string[50] {
            "Кирпич","Бетон","Железобетон","Дерево","Металл","Стекло","Пластик","Камень","Гипс","Строительные блоки","Шифер","Мрамор","Гранит",
            "Керамическая плитка","Асбестоцементные изделия","Пенобетон","Пенопласт","Минеральная вата","Теплоизоляционные плиты","Металлический профиль",
            "Оцинкованный лист","Арматура","Поликарбонат","Алюминиевые профили","Фиброцементные плиты","Полимербетон","Песчано-цементные смеси","Глина",
            "Прессованные древесные плиты","Композитные материалы","Жидкие обои","Паркетная доска","Линолеум","Ковролин","Керамические блоки","Песчаник","Сайдинг",
            "Поликарбонатные листы","Газобетонные блоки","Гипсокартонные плиты","Металлочерепица","Акриловые краски","Стеклопакеты","Полиуретановая пена",
            "Шпаклевка","Штукатурка","Полиэтиленовая пленка","Пластиковые окна","Фанера","Керамзитобетонные блоки"};

        private readonly int[] prices = new int[50] {
            10, 25, 5, 3, 6, 9, 7, 140, 1, 3, 250, 70, 8, 4, 6, 300, 1, 12, 23, 50, 35, 45, 160, 31, 29, 23, 200, 18, 15, 3, 14, 29,  27,  8, 112, 100, 5, 250,  130,
            100, 44, 350, 28, 190, 22, 21, 14, 1, 2, 23 };

        private readonly int[] min_sum_values = new int[50] { 2, 6, 1, 5, 3, 1, 4, 7, 2, 8, 3, 6, 1, 5, 3, 1, 4, 7, 2, 8, 3, 6, 1, 5, 3, 1, 4, 7, 2, 8, 3, 6, 1, 5, 3, 1, 4, 7, 2, 8, 3, 3, 1, 5, 3, 1, 4, 7, 2, 8 };

        private readonly int[] max_sum_values = new int[50] { 5, 9, 3, 8, 6, 15, 7, 10, 5, 12, 6, 9, 3, 8, 6, 10, 7, 10, 5, 12, 6, 9, 3, 8, 6, 10, 7, 10, 5, 8, 6, 9, 3, 8, 6, 5, 7, 10, 5, 8, 6, 9, 3, 8, 6, 8, 7, 10, 5, 12 };

        // Обработчик ввода с клавиатуры в текстовое поле
        private void Sum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

        void Start_Click(object sender, EventArgs e)
        {
            // Проверка наличия бюджета
            if (Convert.ToInt32(Sum.Text) == 0)
            {
                MessageBox.Show(
                "Нет Бюджета",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                Array.Copy(mas2, mas, mas2.Length);
                label4.Text = "";
                _ = new Random();
                int populationSize = 50;
                int generations = Convert.ToInt32(Count_it.Text);
                int mutationRate = 10;

                List<int[]> population = GenerateInitialPopulation(populationSize);

                // Генетический алгоритм
                for (int gen = 0; gen < generations; gen++)
                {
                    List<int> fitnessScores = EvaluateFitness(population);

                    List<int[]> parents = Selection(population, fitnessScores);

                    // Кроссовер и мутация
                    List<int[]> offspring = Crossover(parents);
                    Mutate(offspring, mutationRate);

                    // Замена старой популяции на новую
                    population = offspring;
                }

                // Нахождение наилучшего решения
                int bestFitness = Math.Abs(CalculateFitness(population[0]) - Convert.ToInt32(Sum.Text));
                int[]? bestSolution = null;
                int iterations = 0;
                int maxIterations = Convert.ToInt16(Count_it.Text);
                while (iterations < maxIterations)
                {
                    foreach (int[] individual in population)
                    {
                        int fitness = CalculateFitness(individual);

                        // Обновление лучшего решения и приспособленности
                        if (fitness < bestFitness)
                        {
                            bestFitness = fitness;
                            bestSolution = individual;
                        }
                    }

                    // Проверка условия остановки
                    if (bestFitness == 0)
                    {
                        break;
                    }

                    iterations++;
                }

                // Обновление интерфейса
                for (int i = 0; i < mas!.Length; i++)
                {
                    mas[i] = bestSolution![i];
                    List_of_things.Rows[i].Cells[5].Value = mas[i].ToString();
                }
                int delta = Math.Abs(Convert.ToInt32(Sum.Text) + bestFitness);
                int delta1 = Math.Abs(delta - Convert.ToInt32(Sum.Text));
                label4.Text = "Разница с заданной суммой: " + delta1;
                label4.Refresh();
                label5.Text = "Сумма на данный момент: " + delta;
                label5.Refresh();
            }
        }

        // Вычисление приспособленности индивида
        public int CalculateFitness(int[] individual)
        {
            int fitness = Math.Abs(CalculateOriginalFitness(individual) - Convert.ToInt32(Sum.Text));
            return fitness;
        }

        // Вычисление оригинальной приспособленности индивида
        private int CalculateOriginalFitness(int[] individual)
        {
            int fitness = 0;
            for (int i = 0; i < individual.Length; i++)
            {
                fitness += individual[i] * mas_of_price[i];
            }
            return fitness;
        }

        // Генерация начальной популяции
        List<int[]> GenerateInitialPopulation(int populationSize)
        {
            List<int[]> population = new();
            Random r = new();
            for (int i = 0; i < populationSize; i++)
            {
                int[] individual = new int[mas.Length];
                for (int j = 0; j < individual.Length; j++)
                {
                    individual[j] = r.Next(mas_of_min_sum[j], mas_of_max_sum[j] + 1);
                }
                population.Add(individual);
            }
            return population;
        }

        // Оценка приспособленности популяции
        List<int> EvaluateFitness(List<int[]> population)
        {
            List<int> fitnessScores = new();
            foreach (int[] individual in population)
            {
                int fitness = CalculateFitness(individual);
                fitnessScores.Add(fitness);
            }
            return fitnessScores;
        }

        // Селекция родителей
        static List<int[]> Selection(List<int[]> population, List<int> fitnessScores)
        {
            List<int[]> parents = new();
            for (int i = 0; i < population.Count / 2; i++)
            {
                int index1 = RouletteWheelSelection(fitnessScores);
                int index2 = RouletteWheelSelection(fitnessScores);
                parents.Add(population[index1]);
                parents.Add(population[index2]);
            }
            return parents;
        }

        // Выбор индивида методом
        static int RouletteWheelSelection(List<int> fitnessScores)
        {
            int minFitness = fitnessScores.Min();
            int currentIndex = 0;
            foreach (int fitness in fitnessScores)
            {
                if (fitness == minFitness)
                {
                    return currentIndex;
                }
                currentIndex++;
            }
            return currentIndex - 1;
        }

        // Кроссовер родителей
        static List<int[]> Crossover(List<int[]> parents)
        {
            List<int[]> offspring = new();
            for (int i = 0; i < parents.Count; i += 2)
            {
                int[] parent1 = parents[i];
                int[] parent2 = parents[i + 1];
                int crossoverPoint = new Random().Next(parent1.Length);
                int[] child1 = new int[parent1.Length];
                int[] child2 = new int[parent2.Length];
                Array.Copy(parent1, child1, crossoverPoint);
                Array.Copy(parent2, crossoverPoint, child1, crossoverPoint, parent2.Length - crossoverPoint);
                Array.Copy(parent2, child2, crossoverPoint);
                Array.Copy(parent1, crossoverPoint, child2, crossoverPoint, parent1.Length - crossoverPoint);
                offspring.Add(child1);
                offspring.Add(child2);
            }
            return offspring;
        }

        // Мутация потомков
        void Mutate(List<int[]> offspring, int mutationRate)
        {
            Random r = new();
            foreach (int[] individual in offspring)
            {
                for (int i = 0; i < individual.Length; i++)
                {
                    if (r.Next(100) < mutationRate)
                    {
                        individual[i] = r.Next(mas_of_min_sum[i], mas_of_max_sum[i] + 1);
                    }
                }
            }
        }
    }
}