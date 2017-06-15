using System;
using System.Collections.Generic;

namespace AquarioVirtual.Domain.Model
{
    public class Artigo : ModelBase
    {
        public string Texto { get; set; }
        //public string CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public DateTime DataPublicacao { get; set; }
        public IEnumerable<string> Fotos { get; set; }
        //public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        //public string PeixeId { get; set; }
        public Peixe Peixe { get; set; }
        public StatusArtigo Status { get; set; }

    //    public Artigo New()
    //    {
    //        return new Artigo
    //        {
    //            Texto = "adjiaoshdoiajioda",
    //            Fotos = new List<string>()
    //                {
    //                    "C:/Fotos",
    //                    "D:/Fotos"
    //                },
    //            Categoria = new Categoria
    //            {
    //                Id = "593368292d8dbc2dd0712634",
    //                Descricao = "Plati"
    //            },
    //            DataPublicacao = DateTime.Now,
    //            Usuario = new Usuario
    //            {
    //                Nome = "Leonardo",
    //                Email = "leokyoshida@gmail.com",
    //                Senha = "123",
    //                Foto = @"E:\Fotos",
    //                UltimoNome = "Yoshida"
    //            },
    //            Status = StatusArtigo.Criado,
    //            Peixe = new Peixe
    //            {
    //                PH = 7.5,
    //                Familia = "Platy",
    //                Nome = "Plati Hawai",
    //                Habitat = "Amazonia",
    //                NomeCientifico = "Platy Variatus",
    //                Tamanho = "Pequeno",
    //                TamanhoAquario = "150L",
    //                Temperatura = 27.5
    //            },
    //        };
    //    }
    }

    public enum StatusArtigo : int
    {
        Rascunho = 0,
        Criado = 1,
        PendenteAprovacao = 2,
        Aprovado = 3
    }

}

