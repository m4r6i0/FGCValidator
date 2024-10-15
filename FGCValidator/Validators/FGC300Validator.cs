
using System;
using Newtonsoft.Json.Linq;

namespace ValidadorFGC.Validators
{
    public class FGC300Validator
    {
        public static void Validate(JObject json)
        {
            Console.WriteLine("Validando FGC300...");

            if (json["codigoTransacao"] == null)
            {
                Console.WriteLine("Erro: 'codigoTransacao' é obrigatório.");
            }

            var data = json["data"];
            if (data == null)
            {
                Console.WriteLine("Erro: 'data' é obrigatório.");
                return;
            }

            if (data["codigoLeiaute"] == null || (string)data["codigoLeiaute"] != "FGC300")
            {
                Console.WriteLine("Erro: 'codigoLeiaute' é obrigatório e deve ser 'FGC300'.");
            }

            if (data["cnpj"] == null)
            {
                Console.WriteLine("Erro: 'cnpj' é obrigatório.");
            }

            if (data["produtos"] == null || data["produtos"].Type != JTokenType.Array)
            {
                Console.WriteLine("Erro: 'produtos' é obrigatório e deve ser uma lista.");
            }
            else
            {
                foreach (var produto in data["produtos"])
                {
                    ValidateProduto(produto);
                }
            }
        }

        private static void ValidateProduto(JToken produto)
        {
            if (produto["idProduto"] == null)
            {
                Console.WriteLine("Erro: 'idProduto' é obrigatório.");
            }

            if (produto["tiposTitularidades"] == null || produto["tiposTitularidades"].Type != JTokenType.Array)
            {
                Console.WriteLine("Erro: 'tiposTitularidades' é obrigatório e deve ser uma lista.");
            }
            else
            {
                foreach (var titularidade in produto["tiposTitularidades"])
                {
                    ValidateTitularidade(titularidade);
                }
            }
        }

        private static void ValidateTitularidade(JToken titularidade)
        {
            if (titularidade["idTipoTitularidade"] == null)
            {
                Console.WriteLine("Erro: 'idTipoTitularidade' é obrigatório.");
            }

            if (titularidade["faixas"] == null || titularidade["faixas"].Type != JTokenType.Array)
            {
                Console.WriteLine("Erro: 'faixas' é obrigatório e deve ser uma lista.");
            }
            else
            {
                foreach (var faixa in titularidade["faixas"])
                {
                    ValidateFaixa(faixa);
                }
            }
        }

        private static void ValidateFaixa(JToken faixa)
        {
            if (faixa["idFaixa"] == null)
            {
                Console.WriteLine("Erro: 'idFaixa' é obrigatório.");
            }

            if (faixa["quantidadeClientes"] == null)
            {
                Console.WriteLine("Erro: 'quantidadeClientes' é obrigatório.");
            }

            if (faixa["valor"] == null)
            {
                Console.WriteLine("Erro: 'valor' é obrigatório.");
            }
        }
    }
}
