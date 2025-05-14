using System; 
using System.Windows.Forms; 

namespace MatrixApp 
{
    // главное окно приложения
    public partial class Form1 : Form
    {
        // объявление приватных полей для элементов управления формы
        private DataGridView dataGridView; // таблица для ввода элементов матрицы
        private Button btnCalculate; // кнопка для запуска вычислений
        private Button btnCreateMatrix; // кнопка для создания матрицы
        private TextBox txtRows; // поле ввода количества строк
        private TextBox txtCols; // поле ввода количества столбцов
        private Label lblResult; // метка для отображения результата
        private Label lblRows; // метка для поля ввода строк
        private Label lblCols; // метка для поля ввода столбцов

        // конструктор формы
        public Form1()
        {
            // Вызов метода инициализации элементов управления
            InitializeComponents();
        }

        // Метод для инициализации всех элементов управления формы
        private void InitializeComponents()
        {
            // Настройка свойств формы
            this.Text = "Калькулятор матрицыыы"; // Заголовок окна
            this.Size = new System.Drawing.Size(600, 400); // окно 600x400 пикселей
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // нельзя растягивать
            this.MaximizeBox = false; // Отключение кнопки разворачивания окна

            // Создание и настройка метки для поля ввода количества строк
            lblRows = new Label
            {
                Text = "Строки:", // Текст метки
                Location = new System.Drawing.Point(20, 20), // Позиция (x=20, y=20)
                Size = new System.Drawing.Size(50, 20) // Размер метки
            };

            // Создание и настройка текстового поля для ввода количества строк
            txtRows = new TextBox
            {
                Location = new System.Drawing.Point(70, 20), // Позиция рядом с меткой
                Size = new System.Drawing.Size(50, 20) // Размер поля ввода
            };

            // Создание и настройка метки для поля ввода количества столбцов
            lblCols = new Label
            {
                Text = "Столбцы:", // Текст метки
                Location = new System.Drawing.Point(130, 20), // Позиция
                Size = new System.Drawing.Size(60, 20) // Размер метки
            };

            // Создание и настройка текстового поля для ввода количества столбцов
            txtCols = new TextBox
            {
                Location = new System.Drawing.Point(190, 20), // Позиция рядом с меткой
                Size = new System.Drawing.Size(50, 20) // Размер поля ввода
            };

            // Создание и настройка кнопки для создания матрицы
            btnCreateMatrix = new Button
            {
                Text = "Создать матрицу", // Текст на кнопке
                Location = new System.Drawing.Point(250, 20), // Позиция
                Size = new System.Drawing.Size(100, 25) // Размер кнопки
            };
            // Привязка обработчика события нажатия кнопки
            btnCreateMatrix.Click += BtnCreateMatrix_Click;

            // Создание и настройка таблицы (DataGridView) для ввода элементов матрицы
            dataGridView = new DataGridView
            {
                Location = new System.Drawing.Point(20, 60), // Позиция таблицы
                Size = new System.Drawing.Size(540, 200), // Размер таблицы
                AllowUserToAddRows = false, // Запрет добавления строк пользователем
                AllowUserToDeleteRows = false // Запрет удаления строк пользователем
            };

            // Создание и настройка кнопки для вычисления результата
            btnCalculate = new Button
            {
                Text = "Вычислить", // Текст на кнопке
                Location = new System.Drawing.Point(20, 270), // Позиция
                Size = new System.Drawing.Size(100, 25) // Размер кнопки
            };
            // Привязка обработчика события нажатия кнопки
            btnCalculate.Click += BtnCalculate_Click;

            // Создание и настройка метки для отображения результата
            lblResult = new Label
            {
                Text = "Итог: ", // Начальный текст
                Location = new System.Drawing.Point(20, 300), // Позиция
                Size = new System.Drawing.Size(540, 20) // Размер метки
            };

            // Добавление всех элементов управления на форму
            this.Controls.AddRange(new Control[] { lblRows, txtRows, lblCols, txtCols, btnCreateMatrix, dataGridView, btnCalculate, lblResult });
        }

        // Обработчик события нажатия кнопки "Create Matrix"
        private void BtnCreateMatrix_Click(object sender, EventArgs e)
        {
            try // Обработка возможных ошибок ввода
            {
                // Парсинг введенных значений строк и столбцов
                int rows = int.Parse(txtRows.Text);
                int cols = int.Parse(txtCols.Text);

                // Проверка, что размеры положительные
                if (rows <= 0 || cols <= 0)
                {
                    // Вывод сообщения об ошибке, если размеры некорректны
                    MessageBox.Show("Значения должны быть положительными!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Настройка таблицы DataGridView для заданных размеров
                dataGridView.RowCount = rows; // Установка количества строк
                dataGridView.ColumnCount = cols; // Установка количества столбцов
                dataGridView.Rows.Clear(); // Очистка существующих строк
                dataGridView.Columns.Clear(); // Очистка существующих столбцов

                // Создание столбцов с заголовками
                for (int i = 0; i < cols; i++)
                {
                    // добавление столбца с именем "Col1", "Col2" и т.д.
                    dataGridView.Columns.Add($"Col{i}", $"Col{i + 1}");
                    dataGridView.Columns[i].Width = 80; // Установка ширины столбца
                }

                // СОздание строк с заголовками
                for (int i = 0; i < rows; i++)
                {
                    dataGridView.Rows.Add(); // Добавление новой строки
                    // Установка заголовка строки ("Row1", "Row2" и т.д.)
                    dataGridView.Rows[i].HeaderCell.Value = $"Row{i + 1}";
                }

                // ширина области заголовков строк
                dataGridView.RowHeadersWidth = 80;
            }
            catch (FormatException)
            {
                // Вывод сообщения об ошибке при некорректном формате чисел
                MessageBox.Show("Please enter valid numbers for rows and columns!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обобщённый метод для обработки матрицы (шаблонная функция)
        private T ProcessMatrix<T>(T[,] matrix, Func<T, bool> isPositive, Func<T, T> getAbsolute, Func<T, T, T> add)
        {
            // Получение размеров матрицы
            int rows = matrix.GetLength(0); // Количество строк
            int cols = matrix.GetLength(1); // Количество столбцов

            // Флаг, указывающий, найден ли первый положительный элемент
            bool foundPositive = false;

            // Инициализация переменной для хранения суммы
            T sum = default(T);

            // Цикл по строкам матрицы
            for (int i = 0; i < rows; i++)
            {
                // Цикл по столбцам матрицы
                for (int j = 0; j < cols; j++)
                {
                    if (foundPositive)
                    {
                        // Если положительный элемент уже найден, добавляем модуль текущего элемента к сумме
                        sum = add(sum, getAbsolute(matrix[i, j]));
                    }
                    else if (isPositive(matrix[i, j]))
                    {
                        // Если найден первый положительный элемент, устанавливаем флаг
                        foundPositive = true;
                    }
                }
            }

            //Итоговая сумма
            return sum;
        }

        // кнопка "Calculate"
        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            try 
            {
                // Получение размеров таблицы
                int rows = dataGridView.RowCount; // строк
                int cols = dataGridView.ColumnCount; //    столбцов

                // Создание двумерного массива для хранения матрицы
                double[,] matrix = new double[rows, cols];

                // Заполнение массива данными из DataGridView
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        // Проверка, что ячейка не пуста и содержит корректное число
                        if (dataGridView[j, i].Value == null || !double.TryParse(dataGridView[j, i].Value.ToString(), out matrix[i, j]))
                        {
                            // Вывод сообщения об ошибке
                            MessageBox.Show($"Некорректные значения [{i + 1},{j + 1}]!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                // Вычисление суммы модулей элементов после первого положительного
                double result = ProcessMatrix<double>(
                    matrix, // Передача матрицы
                    x => x > 0, // Делегат для проверки положительности
                    x => Math.Abs(x), // Делегат для получения модуля
                    (x, y) => x + y // Делегат для сложения
                );

                // Отображение результата в метке
                lblResult.Text = $"Итог: Сумма модулей элементов, расположенных после первого положительного элемента = {result:F2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}