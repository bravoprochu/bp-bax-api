using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bax.api.maszynyNowe.Interfaces
{
    public class MaszynyNoweList
    {
        public string id { get; set; }
        public string rodzajUrzadzenia { get; set; }
        public double? markaId { get; set; }
        public string marka { get; set; }
        public string seria { get; set; }
        public string nazwaModelu { get; set; }
        public double? dlugosc_mm { get; set; }
        public double? szerokosc_mm { get; set; }
        public double? szerokoscMin_mm { get; set; }
        public double? wysokosc_mm { get; set; }
        public double? szerokoscGasienic_mm { get; set; }
        public string szerokoscPrzyOgumieniu_mm { get; set; }
        public double? rozstawGasienic_mm { get; set; }
        public double? rozstawGasienicMin_mm { get; set; }
        public double? waga_kg { get; set; }
        public string rodzajRamienia { get; set; }
        public string rodzajOgumienia { get; set; }
        public double? glebokoscKopania_mm { get; set; }
        public double? zasiegKopania_mm { get; set; }
        public double? wysokoscWysypu_mm { get; set; }
        public string udzwigNaLyzce_kN { get; set; }
        public double? udzwigNaWidlachDoPalet { get; set; }
        public string silnikTyp { get; set; }
        public double? silnikMoc_KW { get; set; }
        public double? silnikPojemnosc_cm3 { get; set; }
        public double? cisnieniePomp_bar { get; set; }
        public double? iloscPompZebatych { get; set; }
        public double? wydajnoscPompZebatych_lmin { get; set; }
        public double? iloscPompWielotloczkowych { get; set; }
        public double? wydajnoscPompWielotloczkowych_lmin { get; set; }
        public double? predkoscJazdy_kmh { get; set; }
        public double? predkoscObrotu_rpm { get; set; }
        public double? mocKopaniaRamie_KN { get; set; }
        public double? mocKopaniaLyzka_KN { get; set; }
        public double? liczbaRolek { get; set; }
        public double? liczbaRolekDol { get; set; }
        public string systemNaciaganiaGasienic { get; set; }
        public double? przeswit_mm { get; set; }
        public double? zbiornikPaliwa_l { get; set; }
        public double? plynChlodzacy_l { get; set; }
        public double? olejSilnikowy_l { get; set; }
        public double? plynUkladHydrauliczny_l { get; set; }
        public double? okresGwarancji_msc { get; set; }
        public double? okresGwarancji_mtg { get; set; }
        public bool? czyKlimatyzacja { get; set; }
        public double? czestotliwoscSerwisu_mtg { get; set; }
        public string dokumentacja { get; set; }
        public string czyFinansowanieFabryczne0Procent { get; set; }
        public string czyOdbiorWlasny { get; set; }
        public string rodzajeLyzek { get; set; }
        public string inneOsprzety { get; set; }
        public string mediaCardImg { get; set; }
        public double? zasięg_roboczy_m { get; set; }
        public double? udzwig_na_max_zasięgu_kg { get; set; }
        public string podwozie { get; set; }
        public string rodzaj_osprzetu_roboczego { get; set; }
        public double? pojemność_chwytaka_5_palczastego_gestość_2t_m3_l { get; set; }
        public double? pojemność_chwytaka_lupinowego_gestość_2t_m3_l { get; set; }
        public double? pojemność_chwytaka_szczekowego_drewno_dl_2m_m3 { get; set; }
        public string zasilanie { get; set; }
        public string branza { get; set; }
    }
}
