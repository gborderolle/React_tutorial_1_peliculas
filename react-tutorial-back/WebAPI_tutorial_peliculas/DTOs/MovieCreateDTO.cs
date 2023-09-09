﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebAPI_tutorial_peliculas.Utilities;
using WebAPI_tutorial_peliculas.Validations;

namespace WebAPI_tutorial_peliculas.DTOs
{
    /// <summary>
    /// Los CreateDTO no llevan ID ni Datetimes de crear o modificar
    /// </summary>
    public class MovieCreateDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [FirstCharCapitalValidation]
        public string Title { get; set; }

        public string Trailer { get; set; }

        public string Description { get; set; }

        public bool OnCinema { get; set; }

        public DateTime Premiere { get; set; }

        [FileSizeValidation(maxSizeMB: 4)]
        [FileTypeValidation(fileTypeGroup: FileTypeGroup.Image)]
        public IFormFile Poster { get; set; } // Clase: https://www.udemy.com/course/construyendo-web-apis-restful-con-aspnet-core/learn/lecture/19983788#notes

        /// <summary>
        /// Usamos un ModelBinder custom orque cuando es [FromForm] el ModelBinder no funciona bien con listados
        /// </summary>
        //[ModelBinder(BinderType = typeof(TypeBinder<List<MovieGenreCreateDTO>>))]
        //public List<MovieGenreCreateDTO> Genres { get; set; } // relación n..n

        //[ModelBinder(BinderType = typeof(TypeBinder<List<MovieCinemaCreateDTO>>))]
        //public List<MovieCinemaCreateDTO> Cinemas { get; set; } // relación n..n

        //[ModelBinder(BinderType = typeof(TypeBinder<List<ActorMovieCreateDTO>>))]
        //public List<ActorMovieCreateDTO> Actors { get; set; } // relación n..n


        // Arreglado para el Front
        // Clase 135: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/26047194#notes
        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> GenreIds { get; set; } // relación n..n

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> CinemaIds { get; set; } // relación n..n

        [ModelBinder(BinderType = typeof(TypeBinder<List<ActorMovieCreateDTO>>))] // Check data de actors en Front
        public List<ActorMovieCreateDTO> Actors { get; set; } // relación n..n

    }
}