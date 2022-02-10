using System;
using System.IO;

// TODO: Ordem das operações usando regex
// TODO MAYBE: Executar shellscript com o csharp
namespace Calculadora {
    static class Program {
        static void Main(string[] args) {

            string[] expressao = new string[0];
            double resultado = 0;
            string input = "";

            if (args.IsNullOrEmpty()) {
                input = Console.ReadLine();
                expressao = input.Split(' ');
                resultado = Calcular(expressao);
                Console.WriteLine(input + " = " + resultado);
            } else if (File.Exists(args[0])) {

                string[] linhas = File.ReadAllLines(args[0]);

                foreach (string l in linhas)
                {
                    string[] conta = l.Split(' ');
                    resultado = Calcular(conta);
                    Console.WriteLine(l + " = " + resultado);
                }
            } else {
                resultado = Calcular(args);
                Console.WriteLine(String.Join(' ', args) + " = " + resultado);
            }
        }

        static double Calcular(string[] args)
        {

            string operador = "";
            double resultado = 0.0;

            if (args.Length % 2 == 0) {
                Console.WriteLine("Expressão invalida.");
                Environment.Exit(1);
            }

            for (int i = 0; i < args.Length; i++) {
                if (i % 2 != 0 && !Double.TryParse(args[i], out _)) {
                    if (args[i] == "+") {
                        operador = "+";
                    } else if (args[i] == "-") {
                            operador = "-";
                    } else if (args[i] == "*") {
                        operador = "*";
                    } else if (args[i] == "/") {
                        operador = "/";
                    } else if (args[i] == "%") {
                        operador = "%";
                    } else {
                        Console.WriteLine("Operador invalido.");
                        Environment.Exit(1);
                    }
                } else if (i % 2 == 0 && Double.TryParse(args[i], out _)) {
                    if (i == 0) {
                        resultado = Double.Parse(args[0]);
                    } else if (operador == "+") {
                        resultado += Double.Parse(args[i]);
                    } else if (operador == "-") {
                        resultado -= Double.Parse(args[i]);
                    } else if (operador == "*") {
                        resultado *= Double.Parse(args[i]);
                    } else if (operador == "/") {
                        resultado /= Double.Parse(args[i]);
                    } else if (operador == "%") {
                        resultado %= Double.Parse(args[i]);
                    }
                } else {
                    Console.WriteLine("Operando invalido.");
                    Environment.Exit(1);
                }
            }
            return resultado;
        }

        public static bool IsNullOrEmpty<T>(this T[] array)
        {
            return array == null || array.Length == 0;
        }
    }
}
