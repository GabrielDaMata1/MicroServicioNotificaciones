using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.Commons
{
    public static class GeneradorContenidoCorreo
    {
        public static ContenidoCorreoDTO ContenidoGanadorSubasta(string nombreProducto, string nombreSubasta, decimal monto)
        {
            var cuerpo = $@"
                 <p>Felicidades, ganaste la subasta <strong>{nombreSubasta}</strong> del producto <strong>{nombreProducto}</strong> con un monto de <strong>${monto:F2}</strong>.</p>
                    <p>A continuación se detallan los pasos que debes seguir para reclamar tu premio:</p>
                    <ol>
                        <li>Accede al módulo de reclamo de premios.</li>
                        <li>Selecciona la subasta en la que has resultado ganador.</li>
                        <li>Confirma los detalles del premio y proporciona la información requerida para su entrega (dirección de envío, método de entrega, etc.).</li>
                        <li>Envía la solicitud de reclamo de premio.</li>
                        <li>Tras recibir el premio, realiza la confirmación de la entrega del mismo.</li>
                        <li>En caso de que ocurra algún percance con el premio o la entrega, accede al módulo de reclamos e indica los acontecimientos.</li>
                    </ol>
                    <p>Gracias por participar. ¡Esperamos que disfrutes tu premio!</p>";

            return new ContenidoCorreoDTO
            {
                Asunto = "¡Felicitaciones, has ganado la subasta!",
                Html = cuerpo

            };
        }

        public static ContenidoCorreoDTO ContenidoSubastadorSubastaFinalizada(string nombreSubasta, string nombreProducto, string correoGanador, decimal monto)
        {
            return new ContenidoCorreoDTO
            {
                Asunto = "¡Tu subasta ha finalizado!",
                Html = $@"
                    <p>La subasta <strong>{nombreSubasta}</strong> ha finalizado exitosamente.</p>
                    <p>El producto subastado fue <strong>{nombreSubasta}</strong>, y el usuario <strong>{correoGanador}</strong> resultó ganador con una puja final de <strong>${monto:F2}</strong>.</p>
                    <p>¡Gracias por utilizar nuestra plataforma!</p>"
            };
        }

        public static ContenidoCorreoDTO ContenidoPujaAutomaticaAcabada(string nombreProducto, string nombreSubasta, decimal montoMaximo)
        {
            var cuerpo = $@"
                         <p>Tu puja automática en la subasta <strong>{nombreSubasta}</strong>, que ofrecía el producto <strong>{nombreProducto}</strong>, ha alcanzado el <strong>monto máximo configurado de ${montoMaximo:F2}</strong>.</p>
                         <p>Esto significa que tu puja ya no podrá intervenir en nuevas rondas dentro de esta subasta.</p>
                         <p>A continuación, te compartimos los pasos para reclamar el premio en caso de haber resultado ganador:</p>
                         <p>¿Qué puedes hacer ahora?</p>
                         <ol>
                            <li>Ingresar a la subasta y revisar el estado actual.</li>
                            <li>Realizar una puja manual si aún deseas competir por el producto.</li>
                        </ol>
                    <p>Gracias por participar. ¡Esperamos que sigas formando parte de nuestras subastas!</p>";

            return new ContenidoCorreoDTO
            {
                Asunto = "Tu puja automática ha alcanzado el monto máximo",
                Html = cuerpo
            };
        }

        public static ContenidoCorreoDTO ContenidoPagoSubasta(string nombreSubasta, decimal monto, string correoUsuario)
        {
            var cuerpo = $@"
                <p>Hola,</p>
                <p>Se le informa que que el pago correspondiente a la subasta <strong>{nombreSubasta}</strong>, ha sido procesado correctamente.</p>
                <p>Detalles del pago:</p>
                <ul>
                    <li>Monto recibido: <strong>${monto:F2}</strong></li>
                    <li>Subasta: <strong>{nombreSubasta}</strong></li>
                    <li>Realizado por: <strong>{correoUsuario}</strong></li>
                </ul>
                <p>¡Gracias por confiar en nuestra plataforma!</p>";

            return new ContenidoCorreoDTO
            {
                Asunto = "Pago recibido con éxito para tu subasta",
                Html = cuerpo
            };
        }


        public static ContenidoCorreoDTO ContenidoPagoFallidoSubasta( string nombreSubasta, decimal monto)
        {
            var cuerpo = $@"
                     <p>Hemos detectado un problema al procesar el pago para la subasta <strong>{nombreSubasta}</strong></p>
                     <p>Detalles del intento:</p>
                     <ul>
                        <li>Monto esperado: <strong>${monto:F2}</strong></li>
                        <li>Subasta: <strong>{nombreSubasta}</strong></li>
                     </ul>
                    <p>Este error puede deberse a inconvenientes con el método de pago.</p>
                    <p>Te recomendamos contactar al banco o revisar el estado de tu cuenta bancaria.</p>
                    <p>Si el problema persiste, por favor contacta a soporte.</p>";


            return new ContenidoCorreoDTO
            {
                Asunto = "Error al procesar el pago de tu subasta",
                Html = cuerpo
            };
        }

        public static ContenidoCorreoDTO ContenidoSubastaCancelada(string nombreProducto, string nombreSubasta)
        {
            var cuerpo = $@"
                <p>Lamentamos informarte que la subasta <strong>{nombreSubasta}</strong>, correspondiente al producto <strong>{nombreProducto}</strong>, ha sido cancelada debido a la <strong>falta de pago por parte del comprador</strong>.</p>
                <p>Detalles relevantes:</p>
                <ul>
                   <li>Producto: <strong>{nombreProducto}</strong></li>
                   <li>Subasta: <strong>{nombreSubasta}</strong></li>
                   <li>Estado: <strong>Cancelada por incumplimiento de pago</strong></li>
                </ul>
                <p>Gracias por utilizar nuestra plataforma. Apreciamos tu participación y seguimos a tu disposición para cualquier consulta.</p>";

            return new ContenidoCorreoDTO
            {
                Asunto = "Subasta cancelada por falta de pago",
                Html = cuerpo
            };
        }

        public static ContenidoCorreoDTO ContenidoResoluciónReclamo(string nombreSubasta, string resolucion)
        {
            var cuerpo = $@"
                         <p>Tu reclamo relacionado con la subasta <strong>{nombreSubasta}</strong> ha sido procesado y ya cuenta con una resolución oficial.</p>
                         <p><strong>Resolución:</strong></p>
                         <blockquote style='background-color:#f9f9f9;padding:10px;border-left:5px solid #ccc;'>
                         {resolucion}
                         </blockquote>
                         <p>Gracias por tu paciencia. Seguimos a tu disposición para garantizar un proceso justo y transparente.</p>";
            ;

            return new ContenidoCorreoDTO
            {
                Asunto = "Resolución de reclamo de la subasta",
                Html = cuerpo
            };
        }

        public static ContenidoCorreoDTO ContenidoReclamoPremioSubasta(string nombreSubasta,string correoUsuario)
        {
            var cuerpo = $@"
                        <p>El usuario <strong>{correoUsuario}</strong> ha iniciado el proceso de reclamo del premio correspondiente a la subasta <strong>{nombreSubasta}</strong>.</p>
                        <p>Gracias por usar nuestra plataforma. ¡Seguimos a tu disposición para cualquier consulta!</p>";

            return new ContenidoCorreoDTO
            {
                Asunto = "Reclamo de premio de subasta ",
                Html = cuerpo
            };
        }

        public static ContenidoCorreoDTO ContenidoConfirmaciónReclamoPremioSubasta( string nombreSubasta, string correoUsuario)
        {
            var cuerpo = $@"
                        <p>Le informamos que el usuario <strong>{correoUsuario}</strong> ha confirmado la recepción del premio correspondiente a la subasta <strong>{nombreSubasta}</strong>.</p>
                        <p>Con esto, el proceso de entrega ha sido finalizado satisfactoriamente.</p>
                        <p>Gracias por tu gestión y por ser parte de nuestra comunidad. ¡Te esperamos en futuras subastas!</p>";

            return new ContenidoCorreoDTO
            {
                Asunto = "Confirmación de reclamo del premio de la subasta",
                Html = cuerpo
            };
        }



    }
}
