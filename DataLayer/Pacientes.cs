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
        private static List<Paciente> pacientesUrgentes;           
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

        /// <summary>
        /// Adiciona um paciente
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns></returns>
        public static bool AddPaciente(Paciente paciente) 
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
            if (todosPacientes.Count != 0)
            {
                foreach (Paciente paciente in todosPacientes)
                {
                    Console.WriteLine(paciente.ToString());
                }
                return true;
            }
            else return false;
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

        #region METODOS OBTER POSIÇÃO

        /// <summary>
        /// Obtem a posição de um paciente na lista
        /// </summary>
        /// <param name="nomPaciente"></param>
        /// <returns></returns>
        public static int ObterPosPaciente(string nomPaciente) 
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
        public static int ObterPosPacienteUrgente(string nomPaciente) 
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
        public static int ObterPosPacienteCritico(string nomPaciente) 
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
        public static int ObterPosPacienteEstavel(string nomPaciente) 
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
        public static bool RemovePaciente(string nomePaciente) 
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
        /// Lista Pacientes em ordem da Condição (Urgente) 
        /// </summary>
        /// <returns></returns>
        public static bool ListPacientesPorCondicao()
        {

            todosPacientes.Sort();
            return ListarTodosPacientes();
        }

        /// <summary>
        /// Guarda dados de pacientes no ficheiro "todos_pacientes.dat"
        /// </summary>
        /// <returns></returns>
        public static bool SavePacientes(bool append = false)
        {
            try
            {

                Stream stream = File.Open("C:/Users/Luís Martins/Documents/GitHub/16980-17015-LP2/DataLayer/todos_pacientes.dat", FileMode.Create, FileAccess.ReadWrite);
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, todosPacientes);

                return true;
            }
            catch (IOException e)
            {
                throw new IOException(e.Message);
            }
        }

        /// <summary>
        /// Carrega dados de pacientes do ficheiro "todos_pacientes.dat"
        /// </summary>
        /// <returns></returns>
        public static bool LoadPacientes() 
        {

            
            Stream stream = null;

            if (File.Exists("C:/Users/Luís Martins/Documents/GitHub/16980-17015-LP2/DataLayer/todos_pacientes.dat"))
            {

                try
                {
                    stream = File.Open("C:/Users/Luís Martins/Documents/GitHub/16980-17015-LP2/DataLayer/todos_pacientes.dat", FileMode.Open);
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    todosPacientes = (List<Paciente>)binaryFormatter.Deserialize(stream);

                }
                catch(IOException ex)
                {
                    throw new IOException(ex.Message);  
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();         
                    }
                }
                return true;
            }
            else
            {     
                return false;
            }
        }
    }
}
