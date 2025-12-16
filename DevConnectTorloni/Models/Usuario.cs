using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevConnectTorloni.Models;

[Index("NomeUsuario", Name = "UQ__Usuario__06940B9AFA100BCB", IsUnique = true)]
[Index("Email", Name = "UQ__Usuario__A9D105342B6D5EA5", IsUnique = true)]
public partial class Usuario
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string NomeUsuario { get; set; } = null!;

    [StringLength(30)]
    public string NomeCompleto { get; set; } = null!;

    [StringLength(255)]
    public string Email { get; set; } = null!;

    [StringLength(30)]
    public string Senha { get; set; } = null!;

    [StringLength(255)]
    public string? FotoPerfilUrl { get; set; }

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Comentario> Comentario { get; set; } = new List<Comentario>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Curtida> Curtida { get; set; } = new List<Curtida>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Publicacao> Publicacao { get; set; } = new List<Publicacao>();

    [ForeignKey("IdUsuarioSeguidor")]
    [InverseProperty("IdUsuarioSeguidor")]
    public virtual ICollection<Usuario> IdUsuarioSeguido { get; set; } = new List<Usuario>();

    [ForeignKey("IdUsuarioSeguido")]
    [InverseProperty("IdUsuarioSeguido")]
    public virtual ICollection<Usuario> IdUsuarioSeguidor { get; set; } = new List<Usuario>();
}
