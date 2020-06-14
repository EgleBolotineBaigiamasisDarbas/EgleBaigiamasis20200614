using NUnit.Framework;

namespace BaigiamasisDarbas.Tests
{
    public class DomopliusTests : TestBase
    {
        [Order(1)]
        [Test]
        public static void NeteisingoPrisijungimoTestas()
        {
            _neteisingasPrisijungimas
                .OpenPrisijungimasPage()
                .AddCookieConsent()
                .EnterCredentials("egle.bolotine@yahoo.com", "neteisingas")
                .IsimintiManeTick()
                .ClickPrisijungtiButton()
                .PatikrintiArPavykoPrisijungti("Neteisingas prisijungimo vardas/slaptažodis arba vartotojas yra neregistruotas.");
        }

        [Order(2)]
        [Test]
        public static void TeisingoPrisijungimoTestas()
        {
            _teisingasPrisijungimas
                .ClickPrisijungtiTab()
                .EnterCredentials("egle.bolotine@yahoo.com", "automatizavimas")
                .IsimintiManeTick()
                .ClickPrisijungtiButton()
                .PatikrintiArSikartPavykoPrisijungti("Atsijungti")
                .ClickDomopliusLogo();
        }

        [Order(3)]
        [Test]
        public static void BustoPieskaNeringoje()
        {
            _paieska
                .EnterMiestas("neringa")
                .ClickPaieskosButton()
                .PatikrintiRezultatus("Parduodami butai, neringa");
        }

        [Order(4)]
        [Test]
        public static void KonkretizuotaBustoPaieska()
        {
            _konkertizuotaPaieska
                .EnterMetaiNuo(2000)
                .TickSuNuotrauka()
                .ClickIeskotiButton()
                .PatikrintiRezultatuKieki(1)
                .ClickRasykiteCia();
        }

        [Order(5)]
        [Test]
        public static void NesekmingasAtsiliepimoSiuntimas()
        {
            _atsiliepimas
                .PasirinktiStatusa("Lankytojas")
                .EnterEmail("xxxxxxxxxx")
                .EnterMessage("Labai keistas puslapis..")
                .ClickIvertintiZvaigzdutemis()
                .ClickSiustiButton()
                .PatikrintiArPavykoIssiusti("Neteisingas el. pašto adresas");
        }
    }
}
