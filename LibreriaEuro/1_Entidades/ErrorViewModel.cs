namespace LibreriaEuro.Entidades
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public string? MensajeError { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
