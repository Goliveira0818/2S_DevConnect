using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevConnectTorloni.Models;

[Index("IdUsuario", "IdPublicacao", Name = "UQ__Curtida__FB2281E200BA1019", IsUnique = true)]
public partial class Curtida
{
    [Key]
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public int IdPublicacao { get; set; }

    [ForeignKey("IdPublicacao")]
    [InverseProperty("Curtida")]
    public virtual Publicacao IdPublicacaoNavigation { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("Curtida")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
