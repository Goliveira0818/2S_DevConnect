using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevConnectTorloni.Models;

public partial class Comentario
{
    [Key]
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public int IdPublicacao { get; set; }

    [StringLength(1000)]
    public string Texto { get; set; } = null!;

    public DateOnly DataComentario { get; set; }

    [ForeignKey("IdPublicacao")]
    [InverseProperty("Comentario")]
    public virtual Publicacao IdPublicacaoNavigation { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("Comentario")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
