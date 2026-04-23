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
}