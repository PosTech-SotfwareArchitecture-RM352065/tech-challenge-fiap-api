using System;
using System.Collections.Generic;
using RestauranteSanduba.Core.Domain.Common.Exceptions;
using RestauranteSanduba.Core.Domain.Common.Types;

namespace RestauranteSanduba.Core.Domain.Clientes
{
    public sealed class CPF : ValueObject
    {
        private const int TamanhoPadrao = 11;

        private string _numeroDocumento { get; init; }

        public CPF(string numeroDocumeto)
        {
            if (ValidaCPF(numeroDocumeto))
                _numeroDocumento = RemoveFormatacao(numeroDocumeto);
            else throw new DomainException("CPF inválido!");
        }

        public override string ToString()
        {
            return _numeroDocumento;
        }

        private static string RemoveFormatacao(string documento)
        {
            return documento.Trim().Replace(".", "").Replace("-", "");
        }

        public static bool ValidaCPF(string documento)
        {
            if (string.IsNullOrEmpty(documento)) return false;

            documento = RemoveFormatacao(documento);

            if (documento.Length != TamanhoPadrao) return false;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            tempCpf = documento.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();

            return documento.EndsWith(digito);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _numeroDocumento;
        }
    }
}