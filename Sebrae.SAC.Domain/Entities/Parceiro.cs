//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sebrae.SAC.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Parceiro
    {
        public int CodParceiro { get; set; }
        public string TipoParceiro { get; set; }
        public string NomeRazaoSocial { get; set; }
        public string NomeAbrevFantasia { get; set; }
        public Nullable<decimal> CgcCpf { get; set; }
        public string IndAtu { get; set; }
        public System.DateTime DataInc { get; set; }
        public System.DateTime DataAtu { get; set; }
        public Nullable<int> CodUnidOperInc { get; set; }
        public Nullable<int> CodUnidOperAtu { get; set; }
        public Nullable<short> ControleRede { get; set; }
        public Nullable<int> Tipo { get; set; }
        public Nullable<short> IndAtualizacao { get; set; }
        public int CodSebrae { get; set; }
        public Nullable<int> CodResponsavel { get; set; }
        public string ReceberInfoSEBRAE { get; set; }
        public System.Guid rowguid { get; set; }
        public int Situacao { get; set; }
        public Nullable<System.Guid> CodCRM { get; set; }
    }
}