using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevConnectTorloni.Models;

public partial class Publicacao
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string Descricao { get; set; } = null!;

    [StringLength(255)]
    public string? ImagemUrl { get; set; }

    public DateOnly DataPublicacao { get; set; }

    public int? IdUsuario { get; set; }

    [InverseProperty("IdPublicacaoNavigation")]
    public virtual ICollection<Comentario> Comentario { get; set; } = new List<Comentario>();

    [InverseProperty("IdPublicacaoNavigation")]
    public virtual ICollection<Curtida> Curtida { get; set; } = new List<Curtida>();

    [ForeignKey("IdUsuario")]
    [InverseProperty("Publicacao")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
