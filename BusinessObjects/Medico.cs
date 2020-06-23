using System.Collections.Generic;
using System;

namespace BusinessObjects
{

    /// <summary>
    /// Classe Medico - pode ser atribuido a varios pacientes dependendo da condiçao do mesmo (...)
    /// </summary>
    [Serializable]
    public class Medico : Pessoa
    {
        #region Atributos
        string especialidade;
        List<string> pacientes = new List<string>();
        #endregion

        #region Construtores

        /// <summary>
        /// Construtor sem dados
        /// </summary>
        public Medico()
        {
            especialidade = "";
        }

        /// <summary>
        /// Cria objeto enfermeiro com valores do exterior
        /// </summary>
        /// <param name="n"></param>
        /// <param name="i"></param>
        /// <param name="s"></param>
        /// <param name="especial"></param>
        public Medico(string n, int i, Sexo s,int ni, string especial) : base(n, i, s,ni)
        {

            especialidade = especial;
        }
        #endregion

        #region Propriedades
        /// <summary>
        /// Manipula a especialidade do medico
        /// </summary>
        public string Especialidade
        {
            get { return especialidade; }
            set { especialidade = value; }
        }

        /// <summary>
        /// Manipula a lista de pacientes atribuidos ao medico
        /// </summary>
        public List<string> Pacientes
        {
            get { return pacientes; }
            set { pacientes = value; }
        }

        #endregion

        #region Overrides
        /// <summary>
        /// Converte dados para forma de string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "\nNome: " + base.Nome + "\nIdade: " + base.Idade + "\nSexo: " + base.Sexo + "\nEspecialidade: " + especialidade;
        }
        #endregion


    }
}
