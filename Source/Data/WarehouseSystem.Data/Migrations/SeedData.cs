using WarehouseSystem.Data.Models;

namespace WarehouseSystem.Data.Migrations
{
    public class SeedData
    {
        public static readonly Organization[] Organizations = new Organization[] { new Organization()
        {
            Name = "Bella Bulgaria",
            MateriallyResponsiblePerson = "Georgi Iliev ",
            Address = "1592 Sofia, 125 Professor Tsvetan Lazarov Str.,",
            Vat = "251644996",
            IsSupplier = true,
            LogoUrl = "http://www.bella.bg/img/logo.png"
        }, new Organization()
        {
            Name = "Dimitar Madjarov",
            MateriallyResponsiblePerson = "I.Tomov",
            Address = "Bulgaria, 4027, Plovdiv, Vasil Aprilov Blvd №180",
            Vat = "131573556",
            IsSupplier = true,
            LogoUrl = "http://www.investbulgaria.com/re_images/1272957681_madjarov.gif"
        }, new Organization()
        {
            Name = "Lacrima",
            MateriallyResponsiblePerson = "Vencislav Donkov",
            Address = "Pazardjik, Carica Joanna street",
            Vat = "131573558",
            IsSupplier = true,
            LogoUrl = "http://www.lacrima.bg/assets/images/logo.png"
        }, new Organization()
        {
            Name = "Bozmov ltd",
            MateriallyResponsiblePerson = "Ivan Petrov",
            Address = "Ruse, ul. Sveti Dimitar Basarbovski ",
            Vat = "131573669",
            IsSupplier = true,
            LogoUrl = "http://food-exhibitions.bg/bg/catalogue/exhibitor-image/563381b4d42fd02b3c83fc5a-256x256-inset.jpg"
        }, new Organization()
        {
            Name = "Nestlé",
            MateriallyResponsiblePerson = "Pesho Petrov",
            Address = "Sofiq bul. Praga ",
            Vat = "131573886",
            IsSupplier = true,
            LogoUrl = "https://www.nestle.bg/skin-engine-shared/NCorp/css/images/corporate-logo.png"
        }, new Organization()
        {
            Name = "FREZCO",
            MateriallyResponsiblePerson = "Stoqn Petrov",
            Address = "Sofia, Sveta Troitsa, bl. 368 ent. Б fl. 2",
            Vat = "131571122",
            IsSupplier = true,
            LogoUrl = "http://frezco-dairy.bg/assets/images/logo.png"
        }, new Organization()
        {
            Name = "Vereq",
            MateriallyResponsiblePerson = "Stoqn Stoqnov",
            Address = "Plovdiv, Dunav, bl.",
            Vat = "131574456",
            IsSupplier = true,
            LogoUrl = "http://akademika.bg/wp-content/uploads/2013/05/vereya-logo-malko.jpg"
        }, new Organization()
        {
            Name = "Kraft Foods Group",
            MateriallyResponsiblePerson = "Nikolay Staikov",
            Address = "Sofia Carigradsko Shose",
            Vat = "131575578",
            IsSupplier = true,
            LogoUrl = "http://logonoid.com/images/kraft-foods-logo.png"
        }, new Organization()
        {
            Name = "Zagorka",
            MateriallyResponsiblePerson = "Misho Staikov",
            Address = "Sofia, Gorublyane, bul. Samokovsko shose 2A",
            Vat = "131588554",
            IsSupplier = true,
            LogoUrl = "http://www.mkt360.eu/img/din_admin/zagorka.jpg"
        }, new Organization()
        {
            Name = "Coca-Cola ",
            MateriallyResponsiblePerson = "Pencho Petrov",
            Address = "Sofia, bul. Samokovsko shose 35",
            Vat = "131588001",
            IsSupplier = true,
            LogoUrl = "http://perucom3.e3.pe/ima/0/0/3/3/9/339644.jpg"
        }, new Organization()
        {
            Name = "Dobrudjanski Hliab JSC",
            MateriallyResponsiblePerson = "Illia Iliev",
            Address = "Dobrich, Bulgaria  23-ti Septemvri Street",
            Vat = "131588005",
            IsSupplier = true,
            LogoUrl = "http://www.vita-bg.eu/images/logo.gif"
        }, new Organization()
        {
            Name = "Konservinvest Ltd.",
            MateriallyResponsiblePerson = "Ivan Petrov",
            Address = "Pravoslaven village Parvomay district",
            Vat = "131588112",
            IsSupplier = true,
            LogoUrl = "http://horceto.com/en/wp-content/uploads/2015/07/WEB-fino-smlqna-liutenica-1.png"
        }, new Organization()
        {
            Name = "RAVIK D",
            MateriallyResponsiblePerson = "Ivan Ivanov",
            Address = "Sofia, Sv.Troica housing estate, bl. 145",
            Vat = "131588222",
            IsSupplier = true,
            LogoUrl = "http://ravik.eu/images/header_en.png"
        }, new Organization()
        {
            Name = "TOP BISKIT Ltd",
            MateriallyResponsiblePerson = "Plamen Ivanov",
            Address = "Pernik 91 Stara Planina Str",
            Vat = "131588456",
            IsSupplier = true,
            LogoUrl = "http://topbiskit.com/img/logo_en.png"
        }, new Organization()
        {
            Name = "AVENDI",
            MateriallyResponsiblePerson = "Boby Ivanov",
            Address = "Sofia, Iskarsko shose Blvd 7",
            Vat = "131588411",
            IsSupplier = true,
            LogoUrl = "http://www.jobs.bg/assets/logo/2012-06-22/b_c1c04a19969e3c69ea23fe6c8b56e326.png"
        }, new Organization()
        {
            Name = "Kamenitza",
            MateriallyResponsiblePerson = "Kaloyn Ivanov",
            Address = "Sofia, Tintyava 13Б, bl.  fl. 5",
            Vat = "131588555",
            IsSupplier = true,
            LogoUrl = "http://www.kamenitza.bg/images/site/kamenitza_logo.png"
        }, new Organization()
        {
            Name = "MY DAY",
            MateriallyResponsiblePerson = "Nasko Ivanov",
            Address = "Sofia, Iliyantsi Blvd 12-14",
            Vat = "131588455",
            IsSupplier = true,
            LogoUrl = "http://www.myday.bg/img/mydaylogo.gif"
        }, new Organization()
        {
            Name = "DEVIN LTD",
            MateriallyResponsiblePerson = "Nasko Ivanov",
            Address = "grad Sofia 1113, ul. Tintiava 13 B, entr. A, floor 5",
            Vat = "131588885",
            IsSupplier = true,
            LogoUrl = "http://www.products-bulgarian.com/media/k2/items/cache/bb13a4bf06b08e5df65a1720db211eb1_XL.jpg"
        }, new Organization()
        {
            Name = "Bulgartabac",
            MateriallyResponsiblePerson = "Ana Ivanova",
            Address = " Sofia Graf Ignatiev Str",
            Vat = "131566666",
            IsSupplier = true,
            LogoUrl = "http://www.bulgartabac.bg/static/images/bulgartabac_logo.png"
        }, new Organization()
        {
            Name = "Denito",
            MateriallyResponsiblePerson = "Spaska Ivanova",
            Address = " Burgas Bul. “Prof. Yakimov”",
            Vat = "131566634",
            IsSupplier = true,
            LogoUrl = "http://www.denito.bg/i/logo.png"
        }, new Organization()
        {
            Name = "Maggi® Bulgaria",
            MateriallyResponsiblePerson = "Dora Ivanova",
            Address = " Sofia Bul. “Prof. Yakimov”",
            Vat = "131566678",
            IsSupplier = true,
            LogoUrl = "http://blog.wyo.in/wp-content/uploads/2015/06/Maggi-Open-Letter.jpg"
        }};
    }
}
