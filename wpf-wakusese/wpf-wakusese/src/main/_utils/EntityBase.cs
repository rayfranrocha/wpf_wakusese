using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;
using System.Runtime.Serialization;

namespace wpf_wakusese.src.main._utils
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class EntityBase
    {
        public EntityBase() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public int id { get; set; }

        #region Atributos/Métodos úteis para Controle dos objetos
        [NotMapped]
        public bool isSelecionado { get; set; }
        [NotMapped]
        public bool isAlterado { get; set; }
        [NotMapped]

        public SolidColorBrush Background
        {
            get { 
                Color cor = Colors.White;
                
                if (isAlterado) { cor = Colors.Cyan; }

                return new SolidColorBrush(cor);
            }
        }
        #endregion

        #region Padrão de Projetos para Binding WPF

        public override bool Equals(object obj)
        {
            return this.id == ((EntityBase)obj).id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(String propriedadeNome)
        {
            var tmp = PropertyChanged;
            if (tmp != null)
                tmp(this, new PropertyChangedEventArgs(propriedadeNome));
        }

        #endregion

        #region Métodos getNomeConsolidado de 1 a 4
        public virtual String getNomeConsolidado1()
        {
            return this.ToString();
        }

        public virtual String getNomeConsolidado2()
        {
            return this.ToString();
        }

        public virtual String getNomeConsolidado3()
        {
            return this.ToString();
        }

        public virtual String getNomeConsolidado4()
        {
            return this.ToString();
        }
        #endregion

    }
}
