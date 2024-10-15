
using System;
using Newtonsoft.Json.Linq;

namespace ValidadorFGC.Validators
{
    public class FGC301Validator
    {
        public static void Validate(JObject json)
        {
            Console.WriteLine("Validando FGC301...");

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

            if (data["codigoLeiaute"] == null || (string)data["codigoLeiaute"] != "FGC301")
            {
                Console.WriteLine("Erro: 'codigoLeiaute' é obrigatório e deve ser 'FGC301'.");
            }

            if (data["cnpj"] == null)
            {
                Console.WriteLine("Erro: 'cnpj' é obrigatório.");
            }

            if (data["tiposGarantia"] == null || data["tiposGarantia"].Type != JTokenType.Array)
            {
                Console.WriteLine("Erro: 'tiposGarantia' é obrigatório e deve ser uma lista.");
            }
            else
            {
                foreach (var garantia in data["tiposGarantia"])
                {
                    ValidateGarantia(garantia);
                }
            }
        }

        private static void ValidateGarantia(JToken garantia)
        {
            if (garantia["idTipoGarantia"] == null)
            {
                Console.WriteLine("Erro: 'idTipoGarantia' é obrigatório.");
            }

            if (garantia["tiposTitularidade"] == null || garantia["tiposTitularidade"].Type != JTokenType.Array)
            {
                Console.WriteLine("Erro: 'tiposTitularidade' é obrigatório e deve ser uma lista.");
            }
            else
            {
                foreach (var titularidade in garantia["tiposTitularidade"])
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
