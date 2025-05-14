using System; 
using System.Windows.Forms; // для работы с Windows Forms

namespace MatrixApp 
{
    static class Program // вход в приложение
    {
        //[STAThread]
        static void Main() // Главная точка входа в приложение
        {
            
            Application.EnableVisualStyles();// визуальные стили элементов Windows Forms (современно)
            Application.SetCompatibleTextRenderingDefault(false); // false для использования GDI+ вместо GDI)

            Application.Run(new Form1()); // запуск основного цикла приложения с созданием экземпляра формы Form1
        }
    }
}





