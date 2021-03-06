﻿using System;
using System.ComponentModel.DataAnnotations;

public class Movie
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Portada")]
    public string ImageUrl { get; set; }

    [Required]
    public string Título { get; set; }

    [Required]
    [Display(Name = "Título Original")]    
    public string TítuloOriginal { get; set; }

    [Required]
    [Display(Name = "Video")]
    public string VideoUrl { get; set; }

    [Required]
    public string Año { get; set; }

    [Required]
    public string Reparto { get; set; }

    [Required]
    public string Géneros { get; set; }

    [Required]
    public string Idioma { get; set; }

    [Required]
    public string Calidad { get; set; }

    [Required]
    public string Sinópsis { get; set; }

    [Required]
    [Display(Name = "Trailer")]
    public string TrailerUrl { get; set; }

    [Display(Name = "Última Venta")]
    public DateTime? LastSale { get; set; }

    [Display(Name = "Disponible?")]
    public bool IsAvailabe { get; set; }

    [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
    public decimal Precio { get; set; }
   
}

