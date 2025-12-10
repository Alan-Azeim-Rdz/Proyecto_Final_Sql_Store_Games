using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final_Sql_Store_Games.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido paterno es obligatorio.")]
        public string ApellidoP { get; set; }

        [Required(ErrorMessage = "El apellido materno es obligatorio.")]
        public string ApellidoM { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

        [DataType(DataType.Password)]
        [Compare("Contraseña", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmarContraseña { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        public string Telefono { get; set; }

        // Dirección
        [Required(ErrorMessage = "La calle es obligatoria.")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "La colonia es obligatoria.")]
        public string Colonia { get; set; }

        [Required(ErrorMessage = "La ciudad es obligatoria.")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "El código postal es obligatorio.")]
        public string CodigoPostal { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "El país es obligatorio.")]
        public string Pais { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }
    }
}
