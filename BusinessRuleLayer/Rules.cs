/// <summary>
/// 
/// Business Rule Layer: Esta camada liga a camada main e a camada de dados usando os metodos da mesma para utilizar no main
/// 
/// </summary>

using BusinessObjects;
using DataLayer;



namespace BusinessRuleLayer
{
    public class Rules
    {
        
        /// <summary>
        /// Insere Medico na lista
        /// </summary>
        /// <param name="medico"></param>
        /// <returns></returns>
        public static bool InsereMedico(Medico medico)
        {
            if (Medicos.ExisteMedico(medico.Nome)) return false;
            return Medicos.AddMedico(medico);
        }

        /// <summary>
        /// Insere Paciente na lista principal e nas outras listas dependendo da condiçao
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns></returns>
        public static bool InserePaciente(Paciente paciente)
        {
            if (Pacientes.ExistePaciente(paciente.Nome)) return false;
            return Pacientes.AddPaciente(paciente);
        }

        /// <summary>
        /// Remove medico da lista
        /// </summary>
        /// <param name="nomeMedico"></param>
        /// <returns></returns>
        public static bool RemoveMedico(string nomeMedico)
        {
            return Medicos.RemoveMedico(nomeMedico);
        }

        /// <summary>
        /// Remove paciente da lista principal e nas outras listas dependendo da condiçao
        /// </summary>
        /// <param name="nomePaciente"></param>
        /// <returns></returns>
        public static bool RemovePaciente(string nomePaciente)
        {
            return Pacientes.RemovePaciente(nomePaciente);
        }

        /// <summary>
        /// Lista todos os pacientes
        /// </summary>
        /// <returns></returns>
        public static bool ListarPacientes()
        {
            return Pacientes.ListarTodosPacientes();
        }

        /// <summary>
        /// Lista pacientes urgentes
        /// </summary>
        /// <returns></returns>
        public static bool ListarPacientesUrgentes()
        {
            return Pacientes.ListarPacientesUrgentes();
        }

        /// <summary>
        /// Lista pacientes criticos
        /// </summary>
        /// <returns></returns>
        public static bool ListarPacientesCriticos()
        {
            return Pacientes.ListarPacientesCriticos();
        }

        /// <summary>
        /// Lista pacientes estaveis
        /// </summary>
        /// <returns></returns>
        public static bool ListarPacientesEstaveis()
        {
            return Pacientes.ListarPacientesEstaveis();
        }

        /// <summary>
        /// Listar todos medicos
        /// </summary>
        /// <returns></returns>
        public static bool ListarMedicos()
        {
            return Medicos.ListarTodosMedicos();
        }

        /// <summary>
        /// Guarda dados de pacientes no ficheiro "PacienteFile.txt"
        /// </summary>
        /// <returns></returns>
        public static bool GuardarPacientes()
        {
            return Pacientes.SavePacientes();
        }

        /// <summary>
        /// Carrega dados de pacientes (Melhorar)
        /// </summary>
        public static void CarregarPacientes()
        {
            Pacientes.LoadPacientes();
        }

        /// <summary>
        /// Guarda dados de medicos no ficheiro "MedicoFile.txt"
        /// </summary>
        /// <returns></returns>
        public static bool GuardarMedicos()
        {
            return Medicos.SaveMedicos();
        }

        /// <summary>
        /// Carrega dados de medicos guardados no ficheiro todos_medicos.dat
        /// </summary>
        /// <returns></returns>
        public static bool CarregarMedicos()
        {
            return Medicos.LoadMedicos();
        }

        /// <summary>
        /// Atribui um paciente a um medico
        /// </summary>
        /// <param name="nomeMedico"></param>
        /// <param name="nomePaciente"></param>
        /// <returns></returns>
        public static bool AtribuiPaciente(string nomeMedico, string nomePaciente)
        {
            return Medicos.AtribuirPacientes(nomeMedico, nomePaciente);
        }
    }
}
