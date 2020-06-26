using System;

namespace BusinessObjects
{

    /// <summary>
    /// Enumerador que descreve a condiçao do paciente
    /// </summary>
    public enum Condicao
    {
        URGENTE = 0,
        CRITICO = 1,         // MUDAR ESTES NOMES PARA ALGO MAIS PROFISSIONAL 
        ESTAVEL = 2,
            NULL= 3
    }


    /// <summary>
    /// Descreve paciente do hospital
    /// </summary>
    [Serializable]
    public class Paciente: Pessoa, IComparable<Paciente>
    {
        #region Atributos
        Condicao condicao;
        //Medico medico; // Atribuir um medico a um/ grupo de pacientes (Nao sei se é assim)
        DateTime dataEntrada;
        DateTime dataSaida;
        float peso;
        float altura;
        #endregion


        #region Construtores

        /// <summary>
        /// Cria objeto pessoa com valores predefinidos
        /// </summary>
        public Paciente()
        {
            condicao = Condicao.ESTAVEL;
            dataEntrada = DateTime.Now;
            dataSaida = DateTime.Now;
            
        }

        /// <summary>
        /// Cria objeto paciente com valores do exterior
        /// </summary>
        /// <param name="c"></param>
        public Paciente(string n, int i, Sexo s, int ni, float pes, float alt, Condicao c, DateTime dataEnt) : base(n, i, s, ni)
        {
            condicao = c;
            peso = pes;
            altura = alt;
            dataEntrada = dataEnt; 
        }


        #endregion

        #region Propriedades

        /// <summary>
        /// Manipula a condição do paciente
        /// </summary>
        public Condicao Condicao
        {
            get { return condicao; }
            set { condicao = value; }
        }

        /// <summary>
        /// Manipula a data de entrada do paciente
        /// </summary>
        public DateTime DataEntrada
        {
            get { return dataEntrada; }
            set
            {
                DateTime aux;
                if (DateTime.TryParse(value.ToString(), out aux) == true)
                {
                    dataEntrada = value;
                }
            }
        }

        /// <summary>
        /// Manipula a data de saida do paciente
        /// </summary>
        public DateTime DataSaida
        {
            get { return dataSaida; }
            set
            {
                DateTime aux;
                if (DateTime.TryParse(value.ToString(), out aux) == true)
                {
                    dataSaida = value;
                }
            }
        }



        //public Medico Medico
        //{
        //    get { return medico; }
        //    set { medico = value; }
        //}

        #endregion

        /// <summary>
        /// Compara condiçao de um paciente com outro
        /// </summary>
        /// <param name="outro"></param>
        /// <returns></returns>
        public int CompareTo(Paciente outro)
        {
            if (this.Condicao > outro.Condicao)
            {
                return 1;
            }
            else if (this.Condicao < outro.Condicao)
            {
                return -1;
            }
            else return 0;

        }



        #region Overrides
        /// <summary>
        /// Converte dados para forma de string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "\nNome: " + base.Nome + "\nIdade: " + base.Idade + "\nAltura em metros: " + altura + "\nPeso em Kg: " + peso + "\nSexo: " + base.Sexo + "\nCondição: " + condicao + "\nData de Entrada: " + dataEntrada + "\nData de Saida: " +dataSaida;
        }
        #endregion

    }
}
