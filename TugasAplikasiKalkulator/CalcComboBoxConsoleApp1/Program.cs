using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcComboBoxConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inputkan nilai a = ");
            int a = int.Parse(Console.ReadLine()); // proses casting

            Console.Write("Inputkan nilai b = ");
            var b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(); // tambahkan baris kosong

            Console.Title = "Aplikasi Calculator Versi Console";
            Console.WriteLine("Hasil Penambahan " + a + " + " + b + " = " + Penambahan(a, b));
            Console.WriteLine("Hasil Pengurangan {0} - {1} = {2}", a, b, Pengurangan(a, b));
            Console.WriteLine("Hasil Perkalian {0} * {1} = {2}", a, b, Perkalian(a, b));
            Console.WriteLine("Hasil Pembagian {0} / {1} = {2}", a, b, Pembagian(a, b));

            Console.WriteLine("Tekan sembarang tombol untuk keluar");
            Console.ReadKey();
        }

        static int Penambahan(int a, int b)
        {
            return a + b;
        }

        static int Pengurangan(int a, int b)
        {
            return a - b;
        }

        static int Perkalian(int a, int b)
        {
            return a * b;
        }

        static int Pembagian(int a, int b)
        {
            return a / b;
        }
    }
}
