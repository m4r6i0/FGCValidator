
using System;
using System.IO;
using Newtonsoft.Json.Linq;
using ValidadorFGC.Validators;

namespace ValidadorFGC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o caminho do arquivo JSON:");
            string filePath = Console.ReadLine();
            
            if (File.Exists(filePath))
            {
                try
                {
                    string fileContent = File.ReadAllText(filePath);
                    JObject jsonContent = JObject.Parse(fileContent);

                    // Detectar o tipo de arquivo baseado no layout e validar
                    var codigoLeiaute = jsonContent["data"]?["codigoLeiaute"]?.ToString();

                    switch (codigoLeiaute)
                    {
                        case "FGC300":
                            FGC300Validator.Validate(jsonContent);
                            break;
                        case "FGC301":
                            FGC301Validator.Validate(jsonContent);
                            break;
                        default:
                            Console.WriteLine("Erro: Leiaute desconhecido ou não suportado.");
                            break;
                    }

                    Console.WriteLine("Validação concluída.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao processar o arquivo: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado.");
            }
        }
    }
}
