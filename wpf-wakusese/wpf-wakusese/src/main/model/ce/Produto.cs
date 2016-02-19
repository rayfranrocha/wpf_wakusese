using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using wpf_wakusese.src.main._utils;

namespace wpf_wakusese.src.main.model.ce
{
    public class Produto : EntityBase
    {
        
        private Categoria _categoria;
        private String _nome;
        private String _descricao;
        private Decimal? _preco;
        private byte[] _img1;
        private Decimal _avaliacaoMedia;

        [Display(Name = "Categoria")]
        public Categoria categoria
        {
            get { return _categoria; }
            set { _categoria = value; RaisePropertyChanged("categoria"); }
        }

        [Display(Name = "Nome")]
        public String nome
        {
            get { return _nome; }
            set { _nome = value; RaisePropertyChanged("nome"); }
        }

        [Display(Name = "Descrição")]
        public String descricao
        {
            get { return _descricao; }
            set { _descricao = value; RaisePropertyChanged("descricao"); }
        }

        [Display(Name = "Preço")]
        [DisplayFormat(DataFormatString = "{0:n2}", NullDisplayText = "Sem valor.", ApplyFormatInEditMode = false)]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Preço deve ser maior que zero. Verifique!")]
        public Decimal? preco
        {
            get { return _preco; }
            set { _preco = value; RaisePropertyChanged("preco"); }
        }

        [Display(Name = "Avaliação")]
        [Range(1, 5, ErrorMessage = "A avaliação dever está entre 1 e 5. Verifique!")]
        public Decimal avaliacaoMedia
        {
            get { return _avaliacaoMedia; }
            set { _avaliacaoMedia = value; RaisePropertyChanged("avaliacaoMedia"); }
        }

        [Display(Name = "Imagem")]
        public byte[] img1 
        {
            get { return _img1; }
            set { _img1 = value; RaisePropertyChanged("img1"); }
        }

    }
}
