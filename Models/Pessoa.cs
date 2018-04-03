using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace ExemploValidacao.Models
{
    public class Pessoa
    {
        [Required(ErrorMessage="Nome deve ser preenchido!")]
        public string Nome { get; set; }

        [StringLength(50, MinimumLength=5, ErrorMessage="A observação deve ter entre 5 a 50 caracteres")]
        public string Observacao { get; set; }
        
        [Range(18,50,ErrorMessage="A idade deve ter entre 18 e 50 anos")]
        public int? Idade { get; set; }

        [RegularExpression("^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*(.){1}[a-zA-Z]{2,4})+$", ErrorMessage="E-mail inválido!")]
        [Required(ErrorMessage="Campo e-mail é obrigatório!")]
        public string Email { get; set; }

        [RegularExpression(@"[a-zA-Z]{5,15}", ErrorMessage="Login deve ter somente letras e de 5 a 15 caracteres.")]
        [Required(ErrorMessage="O login deve ser preenchido!")]
        [Remote("LoginUnico", "Pessoa", ErrorMessage="Este nome de login já existe!" )]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha deve ser informada!")]
        public string Senha { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Senha", ErrorMessage = "As senhas não conferem!")]
        public string ConfirmarSenha { get; set; }
    }
}