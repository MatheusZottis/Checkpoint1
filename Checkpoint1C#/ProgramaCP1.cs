using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CheckPoint1;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== CHECKPOINT 1 - FUNDAMENTOS C# - Turma  3ESPY ===\n");

        // ENTREGA ATÉ DIA 08/09 AS 23:59
        // Você deve criar um repositório público ou branch no github e me enviar o link pelo
        // teams antes do fim do prazo.
        // IMPORTANTE:
        // - Não haverá reposição do checkpoint.
        // - Fique atento ao prazo, nenhum trabalho será aceito após a data e vou me basear
        // - O link do seu git deve ser enviado no teams. A data e hora do recebimento do git será utilizada para verificar se foi enviado no prazo.
        // 
        
        // TODO: Implemente as chamadas de teste para demonstrar funcionamento
        // NÃO é obrigatório testar todos os caminhos/casos - apenas mostrar que funciona
        // Use valores de teste simples para validar cada implementação

        //  Treinem rodar o debugger.
        //  F9 - Coloca o breakpoint
        //  F10 - Passa sobre o método no passo a passo
        //  F11 - Entra nos métodos no passo a passo
        //  shift  + F11 - Volta do método

        
        
        Console.WriteLine("1. Testando DemonstrarTiposDados...");
        Console.WriteLine(DemonstrarTiposDados());

        Console.WriteLine("\n2. Testando CalculadoraBasica (SWITCH)...");
        Console.WriteLine($"10 + 5 = {CalculadoraBasica(10, 5, '+')}");
        Console.WriteLine($"10 - 5 = {CalculadoraBasica(10, 5, '-')}");
        Console.WriteLine($"10 * 5 = {CalculadoraBasica(10, 5, '*')}");
        Console.WriteLine($"10 / 5 = {CalculadoraBasica(10, 5, '/')}");
        Console.WriteLine($"10 / 0 = {CalculadoraBasica(10, 0, '/')}");
        Console.WriteLine($"10 % 5 = {CalculadoraBasica(10, 5, '%')}");

        Console.WriteLine("\n3. Testando ValidarIdade (IF/ELSE)...");
        Console.WriteLine($"Idade 5: {ValidarIdade(5)}");
        Console.WriteLine($"Idade 15: {ValidarIdade(15)}");
        Console.WriteLine($"Idade 30: {ValidarIdade(30)}");
        Console.WriteLine($"Idade 70: {ValidarIdade(70)}");
        Console.WriteLine($"Idade -5: {ValidarIdade(-5)}");
        Console.WriteLine($"Idade 150: {ValidarIdade(150)}");

        Console.WriteLine("\n4. Testando ConverterString...");
        Console.WriteLine($"Converter '123' para int: {ConverterString("123", "int")}");
        Console.WriteLine($"Converter '3.14' para double: {ConverterString("3.14", "double")}");
        Console.WriteLine($"Converter 'true' para bool: {ConverterString("true", "bool")}");
        Console.WriteLine($"Converter 'abc' para int: {ConverterString("abc", "int")}");

        Console.WriteLine("\n5. Testando ClassificarNota (SWITCH)...");
        Console.WriteLine($"Nota 9.5: {ClassificarNota(9.5)}");
        Console.WriteLine($"Nota 7.8: {ClassificarNota(7.8)}");
        Console.WriteLine($"Nota 5.0: {ClassificarNota(5.0)}");
        Console.WriteLine($"Nota 2.0: {ClassificarNota(2.0)}");
        Console.WriteLine($"Nota 11.0: {ClassificarNota(11.0)}");
        Console.WriteLine($"Nota -1.0: {ClassificarNota(-1.0)}");

        Console.WriteLine("\n6. Testando GerarTabuada (FOR)...");
        Console.WriteLine(GerarTabuada(7));
        Console.WriteLine(GerarTabuada(-2));

        Console.WriteLine("\n7. Testando JogoAdivinhacao (WHILE)...");
        Console.WriteLine(JogoAdivinhacao(50, new int[]{25, 75, 50}));
        Console.WriteLine(JogoAdivinhacao(30, new int[]{10, 20, 40, 50}));

        Console.WriteLine("\n8. Testando ValidarSenha (DO-WHILE)...");
        Console.WriteLine($"Senha 'Abc1!': {ValidarSenha("Abc1!")}");
        Console.WriteLine($"Senha 'SenhaValida123!': {ValidarSenha("SenhaValida123!")}");
        Console.WriteLine($"Senha 'semnumero!': {ValidarSenha("semnumero!")}");
        Console.WriteLine($"Senha 'SEMNUMERO!': {ValidarSenha("SEMNUMERO!")}");
        Console.WriteLine($"Senha 'semmaiuscula1!': {ValidarSenha("semmaiuscula1!")}");
        Console.WriteLine($"Senha 'SemEspecial1': {ValidarSenha("SemEspecial1")}");

        Console.WriteLine("\n9. Testando AnalisarNotas (FOREACH)...");
        Console.WriteLine(AnalisarNotas(new double[]{8.5, 7.0, 9.2, 6.5, 10.0, 4.0, 5.5, 8.9, 9.0, 7.9, 6.0, 3.0}));
        Console.WriteLine(AnalisarNotas(new double[]{}));

        Console.WriteLine("\n10. Testando ProcessarVendas (FOREACH múltiplo)...");
        double[] vendas = { 100.0, 200.0, 150.0, 50.0, 300.0 };
        string[] categorias = { "A", "B", "A", "C", "B" };
        double[] comissoes = { 0.10, 0.07, 0.05 }; // A=10%, B=7%, C=5%
        string[] nomesCategorias = { "A", "B", "C" };
        Console.WriteLine(ProcessarVendas(vendas, categorias, comissoes, nomesCategorias));

        Console.WriteLine("\n=== RESUMO: TODAS AS ESTRUTURAS FORAM TESTADAS ===");
        Console.WriteLine("✅ IF/ELSE: Testado na validação de idade");
        Console.WriteLine("✅ SWITCH: Testado na calculadora e classificação de notas");
        Console.WriteLine("✅ FOR: Testado na tabuada");
        Console.WriteLine("✅ WHILE: Testado no jogo de adivinhação");
        Console.WriteLine("✅ DO-WHILE: Testado na validação de senha");
        Console.WriteLine("✅ FOREACH: Testado na análise de notas e processamento de vendas");

        Console.WriteLine("\nPressione qualquer tecla para sair...");
        Console.ReadKey();
    }

    // =====================================================================
    // QUESTÃO 1 - VARIÁVEIS E TIPOS DE DADOS (10 pontos)
    // =====================================================================

    /// <summary>
    /// TODO: Complete o método para demonstrar diferentes tipos de dados
    /// - Declare uma variável de cada tipo primitivo (int, double, bool, char, string)
    /// - Use inferência de tipos (var) onde apropriado
    /// - Retorne uma string concatenando todos os valores
    /// </summary>
    private static string DemonstrarTiposDados()
    {
        // TODO: Implementar
        // Exemplo de retorno: "Inteiro: 42, Decimal: 3.14, Booleano: True, Caractere: A, Texto: Olá"
        int inteiro = 42;
        double decimalNum = 3.14;
        bool booleano = true;
        char caractere = 'A';
        string texto = "Olá";

        return $"Inteiro: {inteiro}, Decimal: {decimalNum}, Booleano: {booleano}, Caractere: {caractere}, Texto: {texto}";
    }

    // =====================================================================
    // QUESTÃO 2 - OPERADORES ARITMÉTICOS (10 pontos)
    // =====================================================================

    /// <summary>
    /// TODO: Implemente uma calculadora básica usando SWITCH
    /// - Receba dois números e um operador (+, -, *, /)
    /// - Use SWITCH para selecionar a operação
    /// - Trate divisão por zero retornando 0
    /// - Para operadores inválidos, retorne -1
    /// </summary>
    private static double CalculadoraBasica(double num1, double num2, char operador)
    {
        // TODO: Implementar OBRIGATORIAMENTE usando SWITCH
        // Exemplo de estrutura:
        // switch (operador)
        // {
        //     case '+': return num1 + num2;
        //     case '-': return num1 - num2;
        //     // etc...
        // }
        switch (operador)
        {
            case '+': return num1 + num2;
            case '-': return num1 - num2;
            case '*': return num1 * num2;
            case '/':
                if (num2 == 0)
                {
                    return 0;
                }
                return num1 / num2;
            default: return -1;
        }
    }

    // =====================================================================
    // QUESTÃO 3 - OPERADORES RELACIONAIS E LÓGICOS (10 pontos)  
    // =====================================================================

    /// <summary>
    /// TODO: Valide se uma idade é válida para diferentes contextos usando IF/ELSE
    /// - Use IF/ELSE encadeados (não switch)
    /// - Retorna "Criança" se idade < 12
    /// - Retorna "Adolescente" se idade >= 12 e < 18  
    /// - Retorna "Adulto" se idade >= 18 e <= 65
    /// - Retorna "Idoso" se idade > 65
    /// - Retorna "Idade inválida" se idade < 0 ou > 120
    /// Use operadores relacionais e lógicos
    /// </summary>
    private static string ValidarIdade(int idade)
    {
        // TODO: Implementar OBRIGATORIAMENTE usando IF/ELSE (não switch)
        // Exemplo de estrutura:
        // if (idade < 0 || idade > 120)
        //     return "Idade inválida";
        // else if (idade < 12)
        //     return "Criança";
        // Continue com else if...
        if (idade < 0 || idade > 120)
        {
            return "Idade inválida";
        }
        else if (idade < 12)
        {
            return "Criança";
        }
        else if (idade >= 12 && idade < 18)
        {
            return "Adolescente";
        }
        else if (idade >= 18 && idade <= 65)
        {
            return "Adulto";
        }
        else
        {
            return "Idoso";
        }
    }

    // =====================================================================
    // QUESTÃO 4 - CONVERSÃO DE TIPOS (10 pontos)
    // =====================================================================

    /// <summary>
    /// TODO: Converta uma string para diferentes tipos
    /// - Tente converter 'valor' para int, double e bool
    /// - Se a conversão for bem-sucedida, retorne "Tipo: Valor convertido"
    /// - Se falhar, retorne "Conversão impossível para [tipo]"
    /// - Use TryParse para conversões seguras
    /// </summary>
    private static string ConverterString(string valor, string tipoDesejado)
    {
        // TODO: Implementar conversões usando TryParse
        // tipoDesejado pode ser: "int", "double", "bool"
        if (tipoDesejado == "int")
        {
            if (int.TryParse(valor, out int result))
            {
                return $"Int: {result}";
            }
            else
            {
                return "Conversão impossível para int";
            }
        }
        else if (tipoDesejado == "double")
        {
            if (double.TryParse(valor, out double result))
            {
                return $"Double: {result}";
            }
            else
            {
                return "Conversão impossível para double";
            }
        }
        else if (tipoDesejado == "bool")
        {
            if (bool.TryParse(valor, out bool result))
            {
                return $"Bool: {result}";
            }
            else
            {
                return "Conversão impossível para bool";
            }
        }
        else
        {
            return "Tipo desejado inválido";
        }
    }

    // =====================================================================
    // QUESTÃO 5 - ESTRUTURA CONDICIONAL SWITCH (10 pontos)
    // =====================================================================

    /// <summary>
    /// TODO: Classifique uma nota usando switch expression (C# 8+) ou switch tradicional
    /// - 9.0 a 10.0: "Excelente"
    /// - 7.0 a 8.9: "Bom" 
    /// - 5.0 a 6.9: "Regular"
    /// - 0.0 a 4.9: "Insuficiente"
    /// - Fora da faixa: "Nota inválida"
    /// </summary>
    private static string ClassificarNota(double nota)
    {
        // TODO: Implementar usando switch (pode usar switch expression se conhecer)
        return nota switch
        {
            >= 9.0 and <= 10.0 => "Excelente",
            >= 7.0 and <= 8.9 => "Bom",
            >= 5.0 and <= 6.9 => "Regular",
            >= 0.0 and <= 4.9 => "Insuficiente",
            _ => "Nota inválida"
        };
    }

    // =====================================================================
    // QUESTÃO 6 - ESTRUTURA FOR (10 pontos)
    // =====================================================================

    /// <summary>
    /// TODO: OBRIGATÓRIO USAR FOR
    /// Gere a tabuada de um número de 1 a 10
    /// - Use FOR para iterar de 1 a 10
    /// - Retorne string formatada: "2 x 1 = 2\n2 x 2 = 4\n..." 
    /// - Se número for <= 0, retorne "Número inválido"
    /// </summary>
    private static string GerarTabuada(int numero)
    {
        // TODO: Implementar OBRIGATORIAMENTE com FOR
        if (numero <= 0)
        {
            return "Número inválido";
        }

        string resultado = "";
        for (int i = 1; i <= 10; i++)
        {
            resultado += $"{numero} x {i} = {numero * i}\n";
        }
        return resultado.TrimEnd('\n');
    }

    // =====================================================================
    // QUESTÃO 7 - ESTRUTURA WHILE (15 pontos)
    // =====================================================================

    /// <summary>
    /// TODO: OBRIGATÓRIO USAR WHILE
    /// Simule um jogo de adivinhar número com tentativas limitadas
    /// - numeroSecreto: número a ser adivinhado (1-100)
    /// - tentativas: array com os palpites do jogador
    /// - Use WHILE para percorrer as tentativas
    /// - Para cada tentativa: "Tentativa X: muito alto/baixo/correto"
    /// - Pare no acerto ou quando acabar as tentativas
    /// - Retorne string com histórico completo
    /// </summary>
    private static string JogoAdivinhacao(int numeroSecreto, int[] tentativas)
    {
        // TODO: Implementar OBRIGATORIAMENTE com WHILE
        // Exemplo: "Tentativa 1: 50 - muito baixo\nTentativa 2: 75 - muito alto\nTentativa 3: 63 - correto!"
        string historico = "";
        int i = 0;
        while (i < tentativas.Length)
        {
            int palpite = tentativas[i];
            string status;
            if (palpite == numeroSecreto)
            {
                status = "correto!";
                historico += $"Tentativa {i + 1}: {palpite} - {status}";
                break;
            }
            else if (palpite < numeroSecreto)
            {
                status = "muito baixo";
            }
            else
            {
                status = "muito alto";
            }
            historico += $"Tentativa {i + 1}: {palpite} - {status}\n";
            i++;
        }
        return historico.TrimEnd('\n');
    }

    // =====================================================================
    // QUESTÃO 8 - ESTRUTURA DO-WHILE (15 pontos)
    // =====================================================================

    /// <summary>
    /// TODO: OBRIGATÓRIO USAR DO-WHILE
    /// Valide uma senha seguindo critérios de segurança
    /// - A senha deve ter pelo menos 8 caracteres
    /// - Deve ter pelo menos 1 número
    /// - Deve ter pelo menos 1 letra maiúscula  
    /// - Deve ter pelo menos 1 caractere especial (!@#$%&*)
    /// - Use DO-WHILE para verificar cada critério
    /// - Retorne string explicando quais critérios não foram atendidos
    /// - Se senha válida, retorne "Senha válida"
    /// </summary>
    private static string ValidarSenha(string senha)
    {
        // TODO: Implementar OBRIGATORIAMENTE com DO-WHILE
        // Use do-while para verificar cada critério da senha
        string resultado = "";
        bool valida = true;

        do
        {
            if (senha.Length < 8)
            {
                resultado += "- A senha deve ter pelo menos 8 caracteres\n";
                valida = false;
            }

            if (!senha.Any(char.IsDigit))
            {
                resultado += "- Deve ter pelo menos 1 número\n";
                valida = false;
            }

            if (!senha.Any(char.IsUpper))
            {
                resultado += "- Deve ter pelo menos 1 letra maiúscula\n";
                valida = false;
            }

            string specialCharacters = "!@#$%&*";
            if (!senha.Any(c => specialCharacters.Contains(c)))
            {
                resultado += "- Deve ter pelo menos 1 caractere especial (!@#$%&*)\n";
                valida = false;
            }

        } while (false); // Executa apenas uma vez para verificar todos os critérios

        if (valida)
        {
            return "Senha válida";
        }
        else
        {
            return resultado.TrimEnd('\n');
        }
    }

    // =====================================================================
    // QUESTÃO 9 - ESTRUTURA FOREACH (15 pontos)
    // =====================================================================

    /// <summary>
    /// TODO: OBRIGATÓRIO USAR FOREACH
    /// Analise um array de notas de alunos
    /// - Use FOREACH para percorrer todas as notas
    /// - Calcule: média, quantidade de aprovados (>=7), maior nota, menor nota
    /// - Conte quantas notas estão em cada faixa: A(9-10), B(8-8.9), C(7-7.9), D(5-6.9), F(<5)
    /// - Retorne string formatada com todas as estatísticas
    /// - Se array vazio/null: "Nenhuma nota para analisar"
    /// </summary>
    private static string AnalisarNotas(double[] notas)
    {
        // TODO: Implementar OBRIGATORIAMENTE com FOREACH
        // Retorno exemplo: "Média: 7.5\nAprovados: 15\nMaior: 9.8\nMenor: 3.2\nA: 3, B: 4, C: 8, D: 2, F: 1"
        if (notas == null || notas.Length == 0)
        {
            return "Nenhuma nota para analisar";
        }

        double somaNotas = 0;
        int aprovados = 0;
        double maiorNota = double.MinValue;
        double menorNota = double.MaxValue;

        int countA = 0; // 9-10
        int countB = 0; // 8-8.9
        int countC = 0; // 7-7.9
        int countD = 0; // 5-6.9
        int countF = 0; // <5

        foreach (double nota in notas)
        {
            somaNotas += nota;
            if (nota >= 7.0)
            {
                aprovados++;
            }
            if (nota > maiorNota)
            {
                maiorNota = nota;
            }
            if (nota < menorNota)
            {
                menorNota = nota;
            }

            if (nota >= 9.0 && nota <= 10.0)
            {
                countA++;
            }
            else if (nota >= 8.0 && nota < 9.0)
            {
                countB++;
            }
            else if (nota >= 7.0 && nota < 8.0)
            {
                countC++;
            }
            else if (nota >= 5.0 && nota < 7.0)
            {
                countD++;
            }
            else if (nota < 5.0)
            {
                countF++;
            }
        }

        double media = somaNotas / notas.Length;

        return $"Média: {media:F1}\nAprovados: {aprovados}\nMaior: {maiorNota}\nMenor: {menorNota}\nA: {countA}, B: {countB}, C: {countC}, D: {countD}, F: {countF}";
    }

    // =====================================================================
    // QUESTÃO 10 - MULTIPLE FOREACH (DESAFIO) (20 pontos)
    // =====================================================================

    /// <summary>
    /// TODO: OBRIGATÓRIO USAR FOREACH (múltiplos)
    /// Processe vendas por categoria e calcule comissões
    /// - vendas: array com valores de vendas
    /// - categorias: array com categorias correspondentes ("A", "B", "C")
    /// - comissoes: array com percentuais de comissão por categoria (ex: A=10%, B=7%, C=5%)
    /// - Use FOREACH para percorrer vendas e categorias simultaneamente
    /// - Use FOREACH separado para encontrar a comissão da categoria
    /// - Calcule total de vendas e total de comissões por categoria
    /// - Retorne string com relatório detalhado
    /// </summary>
    private static string ProcessarVendas(double[] vendas, string[] categorias, double[] comissoes, string[] nomesCategorias)
    {
        // TODO: Implementar com múltiplos FOREACH
        // Exemplo: "Categoria A: Vendas R$ 1500,00, Comissão R$ 150,00\nCategoria B: Vendas R$ 800,00, Comissão R$ 56,00"
        if (vendas == null || categorias == null || comissoes == null || nomesCategorias == null ||
            vendas.Length == 0 || categorias.Length == 0 || comissoes.Length == 0 || nomesCategorias.Length == 0)
        {
            return "Dados de vendas inválidos.";
        }

        var vendasPorCategoria = new Dictionary<string, double>();
        var comissoesPorCategoria = new Dictionary<string, double>();

        foreach (string nomeCat in nomesCategorias)
        {
            vendasPorCategoria[nomeCat] = 0;
            comissoesPorCategoria[nomeCat] = 0;
        }

        for (int i = 0; i < vendas.Length; i++)
        {
            string categoria = categorias[i];
            double valorVenda = vendas[i];

            vendasPorCategoria[categoria] += valorVenda;

            double percentualComissao = 0;
            // Encontrar o percentual de comissão para a categoria
            // Assumindo que a ordem em comissoes e nomesCategorias é a mesma
            for (int j = 0; j < nomesCategorias.Length; j++)
            {
                if (nomesCategorias[j] == categoria)
                {
                    percentualComissao = comissoes[j];
                    break;
                }
            }
            comissoesPorCategoria[categoria] += valorVenda * percentualComissao;
        }

        string resultado = "";
        foreach (string categoria in nomesCategorias)
        {
            resultado += $"Categoria {categoria}: Vendas R$ {vendasPorCategoria[categoria]:F2}, Comissão R$ {comissoesPorCategoria[categoria]:F2}\n";
        }

        return resultado.TrimEnd('\n');
    }

    // =====================================================================
    // MÉTODOS AUXILIARES (NÃO ALTERAR - APENAS PARA REFERÊNCIA)
    // =====================================================================

    /// <summary>
    /// Método de exemplo demonstrando diferença entre estático e de instância
    /// ESTÁTICO: Pertence à classe, não precisa criar objeto para usar
    /// </summary>
    private static void ExemploMetodoEstatico()
    {
        Console.WriteLine("Sou um método estático - chamado direto da classe");
    }

    /// <summary>
    /// Método de exemplo de instância (comentado pois não pode ser chamado do Main estático)
    /// DE INSTÂNCIA: Pertence ao objeto, precisa criar instância da classe
    /// </summary>
    /*
    void ExemploMetodoInstancia()
    {
        Console.WriteLine("Sou um método de instância - preciso de um objeto para ser chamado");
    }
    */
}


