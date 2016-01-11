using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wpf_wakusese.src.main._utils
{
    [Serializable]
    public class EntityBase
    {
        public EntityBase() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public override bool Equals(object obj)
        {
            return this.id == ((EntityBase)obj).id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

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

    }
}
