/// <summary>
/// Trabalho Pratico Lp2
/// 
/// Autor: Luís Martins nº 16980, Daniel Maltez nº 17015
/// 
/// Descrição: Neste trabalho visamos desenvolver uma aplicação que consiga gerir a secção das urgências de um hospital 
/// detetando os níveis de urgência na condição de um paciente e atribuindo certos casos a certos médicos. (...)
/// (Trabalho ainda sujeito a alterações dependendo do conteudo dado durante as proximas aulas)
/// 
/// </summary>

using BusinessObjects;
using BusinessRuleLayer;
using System;




namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testes de funções basicas...
            
            #region VARIAVEIS USADAS
            // Variaveisa a ser usadas no programa
            string nomePaciente, nomeMedico, especialidade;
            float peso, altura;
            int idade, nif;
            char sexo, condicao;
            
            Condicao cond = Condicao.NULL;
            Sexo sex = Sexo.NULL;
            bool exit = true;
            
            #endregion


            #region MENU
            while (exit != false)
            {
                Console.Clear();
                Console.WriteLine("--------- [MENU PRINCIPAL] ---------");
                Console.WriteLine("1) Gerir Pacientes");
                Console.WriteLine("2) Gerir Medicos");
                Console.WriteLine("0) Sair");
                var option = Console.ReadKey();
                
                switch (option.Key)
                {
                    #region MENU GERIR PACIENTES
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        Console.WriteLine("--------- [GERIR PACIENTES] ---------");
                        Console.WriteLine("1) Adicionar Paciente");
                        Console.WriteLine("2) Remover Paciente");
                        Console.WriteLine("3) Listar Pacientes");
                        Console.WriteLine("4) Guardar");
                        Console.WriteLine("5) Carregar Progresso");

                        Console.WriteLine("0) Voltar");
                        option = Console.ReadKey();
                        switch (option.Key)
                        {
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                Console.WriteLine("--------- [ADICIONAR PACIENTE] ---------");
                                Console.WriteLine("Insire o nome: ");
                                nomePaciente = Console.ReadLine();

                                Console.WriteLine("Insire a idade: ");
                                idade = int.Parse(Console.ReadLine());
                                Console.WriteLine("Insire a altura: ");
                                altura = int.Parse(Console.ReadLine());

                                Console.WriteLine("Insire o peso: ");
                                peso = float.Parse(Console.ReadLine());

                                while (sex == Sexo.NULL)
                                {
                                    Console.WriteLine("Qual é o sexo?");
                                    Console.WriteLine("[1] Macho");
                                    Console.WriteLine("[2] Femea");
                                    sexo = char.Parse(Console.ReadLine());
                                    if (sexo == '1')
                                    {
                                        sex = Sexo.MACHO;
                                    }
                                    else if (sexo == '2')
                                    {
                                        sex = Sexo.FEMEA;
                                    }
                                    else { Console.WriteLine("Sexo inserido é invalido"); }
                                }
                                Console.WriteLine("Insire o NIF: ");
                                nif = int.Parse(Console.ReadLine());  //Colocar exceção

                                while(cond == Condicao.NULL)
                                {
                                    Console.WriteLine("Qual é a Condição do Paciente?");
                                    Console.WriteLine("[1] Estavel");
                                    Console.WriteLine("[2] Critico");
                                    Console.WriteLine("[3] Urgente");
                                    condicao = char.Parse(Console.ReadLine());
                                    if (condicao == '1')
                                    {
                                        cond = Condicao.ESTAVEL;
                                    }
                                    else if (condicao == '2')
                                    {
                                        cond = Condicao.CRITICO;
                                    }
                                    else if (condicao == '3')
                                    {
                                        cond = Condicao.URGENTE;
                                    }
                                    else { Console.WriteLine("Condição inserida é invalido"); Console.ReadKey(); }
                                }

                                Console.Clear();

                                Paciente paciente = new Paciente(nomePaciente, idade, sex, nif, peso, altura, cond, DateTime.Now);

                                Rules.InserePaciente(paciente);
                                Rules.InserePaciente(paciente);

                                break;

                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                Console.WriteLine("--------- [REMOVER PACIENTE] ---------");
                                Console.WriteLine("Insira o nome do paciente que deseja remover: ");
                                nomePaciente = Console.ReadLine();

                                if (Rules.RemovePaciente(nomePaciente) == true)
                                {
                                    Console.Clear();

                                    Console.WriteLine("Paciente removido com sucesso");
                                    Console.ReadKey();
                                }
                                else Console.WriteLine("O paciente não foi removido"); Console.ReadKey();

                                break;
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:

                                Console.WriteLine("--------- [LISTAR PACIENTES] ---------");
                                
                                Rules.ListarPacientes();
                                Console.ReadKey();

                                break;
                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                Console.WriteLine("--------- [GUARDAR] ---------");
                                if (Rules.GuardarPacientes() == true)
                                {
                                    Console.WriteLine("Ficheiro Guardado com sucesso!");
                                    Console.ReadKey();
                                }else { Console.WriteLine("Ficheiro não foi Guardado..."); Console.ReadKey(); }
                                break;

                            case ConsoleKey.D5:
                            case ConsoleKey.NumPad5:
                                //Rules.LoadAll();
                                break;

                            case ConsoleKey.D0:
                            case ConsoleKey.NumPad0:
                                break;

                        }

                        break;
                    #endregion

                    #region MENU GERIR MEDICOS
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:

                        Console.WriteLine("--------- [GERIR MEDICOS] ---------");
                        Console.WriteLine("1) Adicionar Medico");
                        Console.WriteLine("2) Remover Medico");
                        Console.WriteLine("3) Listar Medicos");
                        Console.WriteLine("4) Atribuir Paciente a Medico");
                        Console.WriteLine("5) Guardar");
                        Console.WriteLine("6) Carregar Progresso");
                        Console.WriteLine("0) Voltar");
                        option = Console.ReadKey();

                        switch (option.Key)
                        {
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:

                                Console.WriteLine("--------- [ADICIONAR MEDICOS] ---------");
                                Console.WriteLine("Insire o nome: ");
                                nomeMedico = Console.ReadLine();

                                Console.WriteLine("Insire a idade: ");
                                idade = int.Parse(Console.ReadLine());

                                while (sex == Sexo.NULL)
                                {
                                    Console.WriteLine("Qual é o sexo?");
                                    Console.WriteLine("[1] Macho");
                                    Console.WriteLine("[2] Femea");
                                    sexo = char.Parse(Console.ReadLine());
                                    if (sexo == '1')
                                    {
                                        sex = Sexo.MACHO;
                                    }
                                    else if (sexo == '2')
                                    {
                                        sex = Sexo.FEMEA;
                                    }
                                    else { Console.WriteLine("Sexo inserido é invalido"); }
                                }

                                Console.WriteLine("Insire o NIF: ");
                                nif = int.Parse(Console.ReadLine());

                                Console.WriteLine("Qual é a especialidade: ");
                                especialidade = Console.ReadLine();

                                Console.Clear();

                                Medico medico = new Medico(nomeMedico, idade, sex, nif, especialidade);

                                Rules.InsereMedico(medico);

                                break;

                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:

                                Console.WriteLine("--------- [REMOVER MEDICO] ---------");
                                Console.WriteLine("Insira o nome do medico que deseja remover: ");
                                nomeMedico = Console.ReadLine();

                                if (Rules.RemoveMedico(nomeMedico) == true)
                                {
                                    Console.Clear();

                                    Console.WriteLine("Medico removido com sucesso");
                                    Console.ReadKey();
                                }
                                else Console.WriteLine("O medico não foi removido"); Console.ReadKey();

                                break;

                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:

                                Console.WriteLine("--------- [LISTAR MEDICOS] ---------");
                                Rules.ListarMedicos();
                                Console.ReadKey();
                                break;
                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                Console.WriteLine("--------- [ATRIBUIR PACIENTE A MEDICO] ---------");
                                Console.WriteLine("Insire o nome do Medico: ");
                                nomeMedico = Console.ReadLine();
                                Console.WriteLine("Insire o nome do Paciente que pretende atribuir: ");
                                nomePaciente = Console.ReadLine();
                                if (Rules.AtribuiPaciente(nomeMedico, nomePaciente) == true)
                                {
                                    Console.Clear();
                                    Console.WriteLine("O paciente {0} foi atribuido ao medico {1}", nomePaciente, nomeMedico);
                                    Console.ReadKey();
                                }else Console.WriteLine("O paciente {0} não foi atribuido ao medico {1}", nomePaciente, nomeMedico); Console.ReadKey();

                                break;

                            case ConsoleKey.D5:
                            case ConsoleKey.NumPad5:
                                Console.WriteLine("--------- [GUARDAR] ---------");
                                if (Rules.GuardarMedicos() == true)
                                {
                                    Console.WriteLine("Ficheiro Guardado com sucesso!");
                                    Console.ReadKey();
                                }
                                else { Console.WriteLine("Ficheiro não foi Guardado..."); Console.ReadKey(); }
                                break;

                            case ConsoleKey.D0:
                            case ConsoleKey.NumPad0:
                                
                                break;
                        }

                        break;
                    #endregion

                    #region MENU SAIR
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        Environment.Exit(0);
                        exit = false;
                        break;
                    #endregion
                }
            }
            #endregion
            
           
            

        }
    }
}
