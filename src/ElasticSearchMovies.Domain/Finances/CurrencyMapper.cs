﻿using System.Collections.Generic;

namespace ElasticSearchMovies.Domain.Finances
{
    public static class CurrencyMapper
    {
        private static readonly Dictionary<string, Currency> CurrenciesDictionary = new Dictionary<string, Currency>()
        {
            { "$", Currency.USD },
            { "ROL", Currency.ROL },
            { "SEK", Currency.SEK },
            { "ITL", Currency.ITL },
            { "FRF", Currency.FRF },
            { "NOK", Currency.NOK },
            { "EUR", Currency.EUR },
            { "GBP", Currency.GBP },
            { "DEM", Currency.DEM },
            { "PTE", Currency.PTE },
            { "FIM", Currency.FIM },
            { "CAD", Currency.CAD },
            { "INR", Currency.INR },
            { "CHF", Currency.CHF },
            { "ESP", Currency.ESP },
            { "JPY", Currency.JPY },
            { "DKK", Currency.DKK },
            { "NLG", Currency.NLG },
            { "PLN", Currency.PLN },
            { "RUR", Currency.RUR },
            { "AUD", Currency.AUD },
            { "KRW", Currency.KRW },
            { "BEF", Currency.BEF },
            { "XAU", Currency.XAU },
            { "HKD", Currency.HKD },
            { "NZD", Currency.NZD },
            { "CNY", Currency.CNY },
            { "PYG", Currency.PYG },
            { "ISK", Currency.ISK },
            { "IEP", Currency.IEP },
            { "TRL", Currency.TRL },
            { "HRK", Currency.HRK },
            { "SIT", Currency.SIT },
            { "PHP", Currency.PHP },
            { "HUF", Currency.HUF },
            { "DOP", Currency.DOP },
            { "JMD", Currency.JMD },
            { "CZK", Currency.CZK },
            { "SGD", Currency.SGD },
            { "BRL", Currency.BRL },
            { "BDT", Currency.BDT },
            { "ATS", Currency.ATS },
            { "BND", Currency.BND },
            { "EGP", Currency.EGP },
            { "THB", Currency.THB },
            { "GRD", Currency.GRD },
            { "ZAR", Currency.ZAR },
            { "NPR", Currency.NPR },
            { "IDR", Currency.IDR },
            { "PKR", Currency.PKR },
            { "MXN", Currency.MXN },
            { "BGL", Currency.BGL },
            { "EEK", Currency.EEK },
            { "YUM", Currency.YUM },
            { "MYR", Currency.MYR },
            { "IRR", Currency.IRR },
            { "CLP", Currency.CLP },
            { "SKK", Currency.SKK },
            { "LTL", Currency.LTL },
            { "TWD", Currency.TWD },
            { "MTL", Currency.MTL },
            { "LVL", Currency.LVL },
            { "COP", Currency.COP },
            { "ARS", Currency.ARS },
            { "UAH", Currency.UAH },
            { "RON", Currency.RON },
            { "ALL", Currency.ALL },
            { "NGN", Currency.NGN },
            { "ILS", Currency.ILS },
            { "VEB", Currency.VEB },
            { "VND", Currency.VND },
            { "TTD", Currency.TTD },
            { "JOD", Currency.JOD },
            { "LKR", Currency.LKR },
            { "GEL", Currency.GEL },
            { "MNT", Currency.MNT },
            { "AZM", Currency.AZM },
            { "AMD", Currency.AMD },
            { "AED", Currency.AED },
            { "USD", Currency.USD }
        };

        public static Currency Map(string input)
        {
            return CurrenciesDictionary[input];
        }
    }
}
