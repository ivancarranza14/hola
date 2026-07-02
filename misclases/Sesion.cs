using System;

namespace claseLogica
{
    // Guarda los datos del usuario que inició sesión, para que
    // cualquier parte de la app sepa "quién está usando el sistema ahora".
    public static class Sesion
    {
        public static string EmailUsuarioActual { get; set; }
    }
}