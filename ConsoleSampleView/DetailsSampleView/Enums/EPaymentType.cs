﻿namespace DetailsSampleView.Enums
{
    // Deixar aqui para converter enum. De inteiro para string e string para inteiro
    // a única forma de pagamento que não estou usando no momento é DebitoParaClienteCreditoParaVendedor
    public enum EPaymentType
    {
        Boleto = 0,
        Debito = 1,
        DebitoParaClienteCreditoParaVendedor = 2, 
        DebitoDescontoAutomaticoPorPeriodo = 3,
        Credito = 4,
        Pix = 5,
    }
}
