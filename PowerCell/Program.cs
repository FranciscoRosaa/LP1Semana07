using System;
using System.Globalization;

namespace PowerCell
{
    public class Program
    {
        // Argumentos:
        // args[0]: Nome da célula
        // args[1]: Número de consumos
        // args[2]: Quantidade de energia a consumir por operação
        private static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            string name = args[0];
            int n = int.Parse(args[1]);
            float amount = float.Parse(args[2]);

            // Cria uma Nova Célula com o Nome Fornecido
            Cell c = new Cell(name);

            // Mostra o Estado Inicial da Célula
            Console.WriteLine(c);

            // Consome a Célula n Vezes
            for (int i = 0; i < n; i++) c.Consume(amount);

            // Mostra o Estado Após os Consumos
            Console.WriteLine(c);

            // Restaura a Célula e Mostra o Estado Final
            c.Restore();
            Console.WriteLine(c);

            // Este programa mostra o seguinte no ecrã (exemplo: Apollo 3 60):
            //
            // [Apollo] Level 6: 200/200
            // [Apollo] Level 1: 20/200
            // [Apollo] Level 6: 200/200
        }
    }

    public class Cell
    {
        private float charge;

        public string Name { get; }

        public float Charge
        {
            get
            {
                return charge;
            }

            set
            {
                if (value < 0)
                {
                    charge = 0;
                }
                else if (value > 200)
                {
                    charge = 200;
                }
                else
                {
                    charge = value;
                }
            }
        }

        public int Level
        {
            get
            {
                return 1 + (int)Charge / 40;
            }
        }

        public void Consume(float amount)
        {
            Charge -= amount;
        }

        public void Restore()
        {
            Charge = 200;
        }

        public Cell(string name)
        {
            Name = name;
            Charge = 200;
        }

        public override string ToString()
        {
            return $"[{Name}] Level {Level}: {Charge:F0}/200";
        }

    }
}