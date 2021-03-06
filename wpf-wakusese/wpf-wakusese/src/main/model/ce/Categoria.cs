﻿using System;
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
    public class Categoria : EntityBase
    {
        private Empresa _empresa;
        private Categoria _categoriaPai;
        private String _nome;

        [Required(ErrorMessage = "O campo Empresa é obrigatório.")]
        [Display(Name = "Empresa")]
        public Empresa empresa
        {
            get { return _empresa; }
            set { _empresa = value; RaisePropertyChanged("empresa"); }

        }

        [Display(Name = "Categoria Pai")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public Categoria categoriaPai
        {
            get { return _categoriaPai; }
            set { _categoriaPai = value; RaisePropertyChanged("categoriaPai"); }
        }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [Display(Name = "Nome")]
        [DisplayFormat(ApplyFormatInEditMode = true, NullDisplayText = "Digite o nome.")]
        public String nome
        {
            get { return _nome; }
            set { _nome = value; RaisePropertyChanged("nome"); }
        }
    }
}
