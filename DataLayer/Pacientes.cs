using BusinessObjects;
using System;
using System.Collections.Generic;
using System.IO;


namespace DataLayer
{
    [Serializable]
    public class Pacientes
    {
        
        private static List<Paciente> todosPacientes;
        private static List<Paciente> pacientesUrgentes;           // Lista de pacientes urgentes (fazer mais listas para outros pacientes?/ Fazer classe especifica para isto?)
        private static List<Paciente> pacientesCriticos;
        private static List<Paciente> pacientesEstaveis;

        /// <summary>
        /// Inicializa todas as listas a ser usadas
        /// </summary>
        static Pacientes()
        {
            todosPacientes = new List<Paciente>();
            pacientesUrgentes = new List<Paciente>();
            pacientesCriticos = new List<Paciente>();
            pacientesEstaveis = new List<Paciente>();
        }



        //Codigo redundante
        /// <summary>
        /// Adiciona um paciente
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns></returns>
        //public static bool AddPaciente(Paciente paciente)
        //{


        //    pacientes.Add(paciente);
        //    if (paciente.Condicao == Condicao.URGENTE)
        //    {
        //        pacientesUrgentes.Add(paciente);
        //    }
        //    else if (paciente.Condicao == Condicao.CRITICO)
        //    {
        //        pacientesMaus.Add(paciente);
        //    }
        //    else if (paciente.Condicao == Condicao.ESTAVEL)
        //    {
        //        pacientesNormais.Add(paciente);
        //    }
        //    return true;


        //}

        /// <summary>
        /// Adiciona um paciente
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns></returns>
        public static bool AddPaciente(Paciente paciente) // Works
        {
            if (ExistePaciente(paciente.Nome) == false)
            {
                todosPacientes.Add(paciente);
                if (paciente.Condicao == Condicao.URGENTE)
                {
                    pacientesUrgentes.Add(paciente);
                }
                else if (paciente.Condicao == Condicao.CRITICO)
                {
                    pacientesCriticos.Add(paciente);
                }
                else if (paciente.Condicao == Condicao.ESTAVEL)
                {
                    pacientesEstaveis.Add(paciente);
                }
                return true;
            }
            return false;
        }



        /// <summary>
        /// Lista todos os Pacientes presentes
        /// </summary>
        /// <returns></returns>
        public static bool ListarTodosPacientes()
        {
            foreach (Paciente paciente in todosPacientes)
            {
                Console.WriteLine(paciente.ToString());
            }   
            return true;
        }

        /// <summary>
        /// Lista pacientes urgentes
        /// </summary>
        /// <returns></returns>
        public static bool ListarPacientesUrgentes()
        {
            foreach (Paciente paciente in pacientesUrgentes)
            {
                Console.WriteLine(paciente.ToString());
            }
            return true;
        }

        /// <summary>
        /// Lista pacientes criticos
        /// </summary>
        /// <returns></returns>
        public static bool ListarPacientesCriticos()
        {
            foreach (Paciente paciente in pacientesCriticos)
            {
                Console.WriteLine(paciente.ToString());
            }
            return true;
        }

        /// <summary>
        /// Lista pacientes estaveis
        /// </summary>
        /// <returns></returns>
        public static bool ListarPacientesEstaveis()
        {
            foreach (Paciente paciente in pacientesEstaveis)
            {
                Console.WriteLine(paciente.ToString());
            }
            return true;
        }


        //Codigo redundante...
        ///// <summary>
        ///// Lista todos os Pacientes com condiçao urgente
        ///// </summary>
        ///// <returns></returns>
        //public static bool ListarPacientesUrgentes()
        //{

        //    foreach (Paciente paciente in pacientesUrgentes)
        //    {
        //        Console.WriteLine(paciente.ToString());
        //    }

        //    return true;
        //}

        ///// <summary>
        ///// Lista todos os Pacientes com condiçao má
        ///// </summary>
        ///// <returns></returns>
        //public static bool ListarPacientesMaus()
        //{

        //    foreach (Paciente paciente in pacientesMaus)
        //    {
        //        Console.WriteLine(paciente.ToString());
        //    }

        //    return true;
        //}

        ///// <summary>
        ///// Lista todos os Pacientes com condiçao normal
        ///// </summary>
        ///// <returns></returns>
        //public static bool ListarPacientesNormais()
        //{

        //    foreach (Paciente paciente in pacientesNormais)
        //    {
        //        Console.WriteLine(paciente.ToString());
        //    }

        //    return true;
        //} Codigo redundante  // Codigo redundante

        #region METODOS OBTER POSIÇÃO

        /// <summary>
        /// Obtem a posição de um paciente na lista
        /// </summary>
        /// <param name="nomPaciente"></param>
        /// <returns></returns>
        public static int ObterPosPaciente(string nomPaciente) // Works
        {
            for (int i = 0; i < todosPacientes.Count; i++)
            {
                if (todosPacientes[i].Nome == nomPaciente)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Obtem a posiçao de um paciente na lista de pacientes urgentes
        /// </summary>
        /// <param name="nomPaciente"></param>
        /// <returns></returns>
        public static int ObterPosPacienteUrgente(string nomPaciente) // Works
        {
            for (int i = 0; i < pacientesUrgentes.Count; i++)
            {
                if (pacientesUrgentes[i].Nome == nomPaciente)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Obtem a posiçao de um paciente na lista de pacientes Criticos
        /// </summary>
        /// <param name="nomPaciente"></param>
        /// <returns></returns>
        public static int ObterPosPacienteCritico(string nomPaciente) // Works
        {
            for (int i = 0; i < pacientesCriticos.Count; i++)
            {
                if (pacientesCriticos[i].Nome == nomPaciente)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Obtem a posiçao de um paciente na lista de pacientes Estaveis
        /// </summary>
        /// <param name="nomPaciente"></param>
        /// <returns></returns>
        public static int ObterPosPacienteEstavel(string nomPaciente) // Works
        {
            for (int i = 0; i < pacientesEstaveis.Count; i++)
            {
                if (pacientesEstaveis[i].Nome == nomPaciente)
                    return i;
            }
            return -1;
        }
        #endregion

        /// <summary>
        /// Remove um paciente da lista principal
        /// </summary>
        /// <param name="nomePaciente"></param>
        /// <returns></returns>
        public static bool RemovePaciente(string nomePaciente)  // Works
        {
            int pos = ObterPosPaciente(nomePaciente);
            if (pos != -1)
            {
                if (todosPacientes[pos].Nome == nomePaciente)
                {

                    todosPacientes[pos].DataSaida = DateTime.Now;                    
                    if(todosPacientes[pos].Condicao == Condicao.CRITICO)
                    {
                        pos = ObterPosPacienteCritico(nomePaciente);
                        pacientesCriticos.RemoveAt(pos);
                    }
                    else if (todosPacientes[pos].Condicao == Condicao.URGENTE)
                    {
                        pos = ObterPosPacienteUrgente(nomePaciente);
                        pacientesUrgentes.RemoveAt(pos);
                    }
                    else if (todosPacientes[pos].Condicao == Condicao.ESTAVEL)
                    {
                        pos = ObterPosPacienteEstavel(nomePaciente);
                        pacientesEstaveis.RemoveAt(pos);
                    }                    
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Verifica se existe um paciente na lista principal
        /// </summary>
        /// <param name="nomePaciente"></param>
        /// <returns></returns>
        public static bool ExistePaciente(string nomePaciente)
        {
            int pos = ObterPosPaciente(nomePaciente);
            if (pos != -1)
            {
                if (todosPacientes[pos].Nome == nomePaciente) { return true; }
            }
            return false;
        }

        /// <summary>
        /// Verifica se existe um paciente na lista de pacientes urgentes
        /// </summary>
        /// <param name="nomePaciente"></param>
        /// <returns></returns>
        public static bool ExistePacienteUrgente(string nomePaciente)
        {
            int pos = ObterPosPacienteUrgente(nomePaciente);
            if (pos != -1)
            {
                if (pacientesUrgentes[pos].Nome == nomePaciente) { return true; }
            }
            return false;
        }

        /// <summary>
        /// Verifica se existe um paciente na lista de pacientes criticos
        /// </summary>
        /// <param name="nomePaciente"></param>
        /// <returns></returns>
        public static bool ExistePacienteCritico(string nomePaciente)
        {
            int pos = ObterPosPacienteCritico(nomePaciente);
            if (pos != -1)
            {
                if (pacientesCriticos[pos].Nome == nomePaciente) { return true; }
            }
            return false;
        }

        /// <summary>
        /// Verifica se existe um paciente na lista de pacientes estaveis
        /// </summary>
        /// <param name="nomePaciente"></param>
        /// <returns></returns>
        public static bool ExistePacienteEstavel(string nomePaciente)
        {
            int pos = ObterPosPacienteEstavel(nomePaciente);
            if (pos != -1)
            {
                if (pacientesEstaveis[pos].Nome == nomePaciente) { return true; }
            }
            return false;
        }

        /// <summary>
        /// Guarda informaçoes de pacientes num ficheiro txt
        /// </summary>
        /// <returns></returns>
        public static bool SavePacientes(bool append = false)
        {
            try
            {
                using(Stream stream = File.Open("C:/Users/Luís Martins/Documents/GitHub/16980-17015-LP2/DataLayer/todos_pacientes.dat", append ? FileMode.Append : FileMode.Create))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    binaryFormatter.Serialize(stream, todosPacientes);
                }
                return true;
            }
            catch(Exception ex)
            {
                
                return false;
            }


        }


        public static void LoadPacientes() //Doesn't work
        {

            string nomeFicheiro = "todos_pacientes.dat";
            Stream stream = null;

            if (File.Exists("C:/Users/Luís Martins/Documents/GitHub/16980-17015-LP2/DataLayer/todos_pacientes.dat"))
            {

                try
                {
                    stream = File.Open("C:/Users/Luís Martins/Documents/GitHub/16980-17015-LP2/DataLayer/todos_pacientes.dat", FileMode.Open);


                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    todosPacientes = (List<Paciente>)binaryFormatter.Deserialize(stream);

                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                }


            }
            else
            {
                Console.WriteLine("Não foi carregado");
                return;
            }


        }
    }
}
