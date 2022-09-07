namespace Domain.Enums
{
    // Deixar aqui para converter enum. De inteiro para string e string para inteiro
    public enum EPaymentType
    {
        Boleto = 0,
        Debito = 1,
        DebitoParaClienteCreditoParaVendedor = 2, 
        DebitoDescontoAutomaticoPorPeriodo = 3,
        Credito = 4,
    }
}
