/// <summary>
/// 
/// DataLayer: Camada que contem todas as estruturas de dados para manipular os objetos criados na camada BusinessObjects
/// 
/// </summary>
/// 
using System;
using System.Collections.Generic;
using System.IO;
using BusinessObjects;



namespace DataLayer
{
    public class Medicos
    {
        private static List<Medico> medicos;

        /// <summary>
        /// Inicializa a lista a ser usada
        /// </summary>
        static Medicos()
        {
            medicos = new List<Medico>();
        }


        /// <summary>
        /// Adiciona um Medico
        /// </summary>
        /// <param name="medico"></param>
        /// <returns></returns>
        public static bool AddMedico(Medico medico)
        {

            if (!medicos.Contains(medico))
            {
                medicos.Add(medico);
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Obtem a posição de um medico numa lista
        /// </summary>
        /// <param name="nomMedico"></param>
        /// <returns></returns>
        public static int ObterPosMedico(string nomMedico) // Works
        {
            for (int i = 0; i < medicos.Count; i++)
            {
                if (medicos[i].Nome == nomMedico)
                    return i;
            }
            return -1;
        }
        

        /// <summary>
        /// Atribui um Paciente a um Medico
        /// </summary>
        /// <param name="nomeMedico"></param>
        /// <param name="nomePaciente"></param>
        /// <returns></returns>
        public static bool AtribuirPacientes(string nomeMedico, string nomePaciente) // Ver como arranjar
        {
            int posMedico = ObterPosMedico(nomeMedico);
            if (posMedico != -1)
            {
                if (Pacientes.ExistePaciente(nomePaciente) == true)
                {
                    int posPaciente = Pacientes.ObterPosPaciente(nomePaciente);
                    if (posPaciente != -1)
                    {                        
                        medicos[posMedico].Pacientes.Add(nomePaciente);
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Remove um medico de uma lista
        /// </summary>
        /// <param name="nomeMedico"></param>
        /// <returns></returns>
        public static bool RemoveMedico(string nomeMedico)  // Works
        {
            int pos = ObterPosMedico(nomeMedico);
            if (pos != -1)
            {
                if (medicos[pos].Nome == nomeMedico)
                {
                    medicos.RemoveAt(pos);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Lista todos os medicos na lista
        /// </summary>
        /// <returns></returns>
        public static bool ListarTodosMedicos()
        {
            foreach (Medico medico in medicos)
            {
                Console.WriteLine(medico.ToString());
            }
            return true;
        }

        /// <summary>
        /// Verifica se o medico ja existe na lista
        /// </summary>
        /// <param name="nomeMedico"></param>
        /// <returns></returns>
        public static bool ExisteMedico(string nomeMedico)
        {
            int pos = ObterPosMedico(nomeMedico);
            if(pos != -1)
            {
                if(medicos[pos].Nome == nomeMedico) { return true; }
            }
            return false;
        }

        /// <summary>
        /// Guarda informaçoes de medicos num ficheiro txt
        /// </summary>
        /// <returns></returns>
        public static bool SaveMedicos()
        {


            using (TextWriter tw = new StreamWriter("MedicoFile.txt")) //Works
            {
                foreach (Medico m in medicos)
                {
                    tw.WriteLine(m.ToString());
                    return true;
                }
                tw.Close();
            }
            return false;
        }
    }
}
