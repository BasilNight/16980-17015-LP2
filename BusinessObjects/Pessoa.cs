using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjects
{
    public enum Sexo
    {
        MACHO = 1,
        FEMEA = 2,
        NULL
    }

    /// <summary>
    /// Descreve uma pessoa básica
    /// </summary>
    public class Pessoa
    {
        #region Atributos

        string nome;
        int idade;
        Sexo sexo;
        int nif;
        #endregion

        #region Construtores      

        /// <summary>
        /// Cria objeto pessoa com valores predefinidos
        /// </summary>
        public Pessoa()
        {
            nome = "";
            idade = 0;
            
        }
        /// <summary>
        /// Cria objeto pessoa com valores do exterior
        /// </summary>
        /// <param name="n"></param>
        /// <param name="i"></param>
        public Pessoa(string n, int i, Sexo s, int ni)
        {
            this.nome = n;
            this.idade = i;
            this.sexo = s;
            this.nif = ni;
        }

        

        #endregion

        #region Propriedades

        /// <summary>
        /// Manipula o parametro de idade
        /// </summary>
        public int Idade
        {
            get { return idade; }
            set { idade = value; }
        }

        /// <summary>
        /// Manipula o parametro do nome
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /// <summary>
        /// Manipula o parametro do nome
        /// </summary>
        public Sexo Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        /// <summary>
        /// manipula o numero nif;
        /// </summary>
        public int Nif
        {
            get { return nif; }
            set { nif = value; }
        }
        #endregion
    }


}

