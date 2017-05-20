namespace Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Data.ShopContext";
        }

        protected override void Seed(ShopContext context)
        {
            if (!context.Categories.Any())
            {
                SeedCategories(context);
            }

            if (!context.Cities.Any())
            {
                SeedCities(context);
            }

            if (!context.Users.Any())
            {
                SeedUsers(context);
            }
        }

        private void SeedCategories(ShopContext context)
        {
            string[][] categories = new string[][]
            {
                new string[] {"Laptops", "Picture 1"},
                new string[] {"Computers", "Picture 2"},
                new string[] {"Tablets", "Picture 3"},
                new string[] {"Smartphones", "Picture 4"},
                new string[] {"TVs", "Picture 5"},
                new string[] {"Audio", "Picture 6"},
                new string[] {"Navigations", "Picture 7"},
                new string[] {"Accessories", "Picture 8"},
                new string[] {"Other", "Picture 9"},
            };

            foreach (string[] category in categories)
            {
                context.Categories.Add(new Category { Name = category[0], Image = category[1] });
            }

            context.SaveChanges();
        }

        private void SeedCities(ShopContext context)
        {
            string[] cities =
            {
                "����� (Aytos)",
                "�������� (Aksakovo)",
                "������� (Alfatar)",
                "�������� (Antonovo)",
                "������� (Apriltsi)",
                "������ (Ardino)",
                "���������� (Asenovgrad)",
                "������ (Aheloy)",
                "������� (Ahtopol)",
                "������ (Balchik)",
                "����� (Bankya)",
                "������ (Bansko)",
                "���� (Banya)",
                "����� (Batak)",
                "��������� (Batanovtsi)",
                "������ (Belene)",
                "������ (Belitsa)",
                "������ (Belovo)",
                "����������� (Belogradchik)",
                "�������� (Beloslav)",
                "��������� (Berkovitsa)",
                "����������� (Blagoevgrad)",
                "����� ��� (Bobov dol)",
                "�������� (Boboshevo)",
                "�������� (Bozhurishte)",
                "���������� (Boychinovtsi)",
                "�������� (Bolyarovo)",
                "������ (Borovo)",
                "��������� (Botevgrad)",
                "��������� (Bratsigovo)",
                "������� (Bregovo)",
                "������� (Breznik)",
                "������� (Brezovo)",
                "�������� (Brusartsi)",
                "������ (Burgas)",
                "������ (Buhovo)",
                "��������� (Balgarovo)",
                "2���� (2Byala)",
                "���� ������� (Byala Slatina)",
                "���� ������ (Byala Cherkva)",
                "����� (Varna)",
                "������ ������� (Veliki Preslav)",
                "������ ������� (Veliko Tarnovo)",
                "��������� (Velingrad)",
                "������ (Vetovo)",
                "������ (Vetren)",
                "����� (Vidin)",
                "����� (Vratsa)",
                "��������� (Valchedram)",
                "����� ��� (Valchi dol)",
                "������� (Varbitsa)",
                "������ (Varshets)",
                "������� (Gabrovo)",
                "������� ������ (General Toshevo)",
                "��������� (Glavinitsa)",
                "�������� (Glodzhevo)",
                "����� (Godech)",
                "����� ��������� (Gorna Oryahovitsa)",
                "���� ������ (Gotse Delchev)",
                "������� (Gramada)",
                "������� (Gulyantsi)",
                "������� (Gurkovo)",
                "�������� (Galabovo)",
                "��� ������ (Dve mogili)",
                "������� (Debelets)",
                "����� (Devin)",
                "����� (Devnya)",
                "������ (Dzhebel)",
                "������������ (Dimitrovgrad)",
                "������ (Dimovo)",
                "��������� (Dobrinishte)",
                "������ (Dobrich)",
                "����� ���� (Dolna banya)",
                "����� ���������� (Dolna Mitropoliya)",
                "����� ��������� (Dolna Oryahovitsa)",
                "����� ������ (Dolni Dabnik)",
                "����� ������ (Dolni chiflik)",
                "������ (Dospat)",
                "�������� (Dragoman)",
                "������� (Dryanovo)",
                "������ (Dulovo)",
                "������� (Dunavtsi)",
                "������� (Dupnitsa)",
                "�������� (Dalgopol)",
                "����� (Elena)",
                "���� ����� (Elin Pelin)",
                "������ (Elhovo)",
                "�������� (Etropole)",
                "����� (Zavet)",
                "����� (Zemen)",
                "��������� (Zlataritsa)",
                "������� (Zlatitsa)",
                "��������� (Zlatograd)",
                "����������� (Ivaylovgrad)",
                "��������� (Ignatievo)",
                "����� (Iskar)",
                "������� (Isperih)",
                "������� (Ihtiman)",
                "���������� (Kableshkovo)",
                "������� (Kavarna)",
                "�������� (Kazanlak)",
                "������� (Kalofer)",
                "������ (Kameno)",
                "��������� (Kaolinovo)",
                "������� (Karlovo)",
                "�������� (Karnobat)",
                "�������� (Kaspichan)",
                "������ (Kermen)",
                "���������� (Kilifarevo)",
                "����� (Kiten)",
                "������� (Klisura)",
                "����� (Knezha)",
                "�������� (Kozloduy)",
                "������� (Koynare)",
                "���������� (Koprivshtitsa)",
                "���������� (Kostandovo)",
                "�������� (Kostenets)",
                "���������� (Kostinbrod)",
                "����� (Kotel)",
                "���������� (Kocherinovo)",
                "������ (Kresna)",
                "�������� (Krivodol)",
                "������ (Krichim)",
                "���������� (Krumovgrad)",
                "���� (Kran)",
                "������ (Kubrat)",
                "������ (Kuklen)",
                "���� (Kula)",
                "�������� (Kardzhali)",
                "��������� (Kyustendil)",
                "������ (Levski)",
                "������� (Letnitsa)",
                "����� (Lovech)",
                "������� (Loznitsa)",
                "��� (Lom)",
                "������� (Lukovit)",
                "���� (Laki)",
                "������� (Lyubimets)",
                "�������� (Lyaskovets)",
                "����� (Madan)",
                "��������� (Madzharovo)",
                "����� ������� (Malko Tarnovo)",
                "������ (Marten)",
                "������ (Mezdra)",
                "������ (Melnik)",
                "��������� (Merichleri)",
                "����� (Miziya)",
                "����� ������ (Momin prohod)",
                "���������� (Momchilgrad)",
                "������� (Montana)",
                "������ (Maglizh)",
                "�������� (Nedelino)",
                "������� (Nesebar)",
                "��������� (Nikolaevo)",
                "������� (Nikopol)",
                "���� ������ (Nova Zagora)",
                "���� ����� (Novi Iskar)",
                "���� ����� (Novi pazar)",
                "����� (Obzor)",
                "������� (Omurtag)",
                "����� (Opaka)",
                "������� (Oryahovo)",
                "����� ���� (Pavel banya)",
                "��������� (Pavlikeni)",
                "��������� (Pazardzhik)",
                "���������� (Panagyurishte)",
                "������ (Pernik)",
                "�������� (Perushtitsa)",
                "������ (Petrich)",
                "������ (Peshtera)",
                "������ (Pirdop)",
                "��������� (Plachkovtsi)",
                "������ (Pleven)",
                "������ (Pliska)",
                "������� (Plovdiv)",
                "������ ������� (Polski Trambesh)",
                "������� (Pomorie)",
                "������ (Popovo)",
                "������ (Pordim)",
                "������ (Pravets)",
                "��������� (Primorsko)",
                "�������� (Provadiya)",
                "�������� (Parvomay)",
                "������� (Radnevo)",
                "������� (Radomir)",
                "������� (Razgrad)",
                "������ (Razlog)",
                "�������� (Rakitovo)",
                "�������� (Rakovski)",
                "���� (Rila)",
                "����� (Roman)",
                "������� (Rudozem)",
                "���� (Ruse)",
                "������ (Sadovo)",
                "������� (Samokov)",
                "��������� (Sandanski)",
                "�������� ���� (Sapareva banya)",
                "����� ���� (Sveti Vlas)",
                "���������� (Svilengrad)",
                "������ (Svishtov)",
                "����� (Svoge)",
                "�������� (Sevlievo)",
                "������ (Senovo)",
                "��������� (Septemvri)",
                "�������� (Silistra)",
                "������������ (Simeonovgrad)",
                "������� (Simitli)",
                "��������� (Slavyanovo)",
                "������ (Sliven)",
                "�������� (Slivnitsa)",
                "����� ���� (Slivo pole)",
                "������ (Smolyan)",
                "������� (Smyadovo)",
                "������� (Sozopol)",
                "����� (Sopot)",
                "����� (Sofiya)",
                "������ (Sredets)",
                "������������ (Stamboliyski)",
                "����� ������ (Stara Zagora)",
                "�������� (Strazhitsa)",
                "�������� (Straldzha)",
                "������� (Strelcha)",
                "�������� (Suvorovo)",
                "���������� (Sungurlare)",
                "�������� (Suhindol)",
                "���������� (Saedinenie)",
                "������� (Sarnitsa)",
                "�������� (Tvarditsa)",
                "������ (Tervel)",
                "������� (Teteven)",
                "����������� (Topolovgrad)",
                "����� (Troyan)",
                "���� (Tran)",
                "��������� (Trastenik)",
                "������ (Tryavna)",
                "�������� (Tutrakan)",
                "��������� (Targovishte)",
                "������� (Ugarchin)",
                "����������� (Hadzhidimovo)",
                "�������� (Harmanli)",
                "������� (Haskovo)",
                "������ (Hisarya)",
                "��� ������ (Tsar Kaloyan)",
                "������ (Tsarevo)",
                "�������� (Chepelare)",
                "������ ���� (Cherven bryag)",
                "���������� (Chernomorets)",
                "�������� (Chiprovtsi)",
                "������ (Chirpan)",
                "����� (Shabla)"
            };

            foreach (string city in cities)
            {
                context.Cities.Add(new City { Name = city });
            }

            context.SaveChanges();
        }

        private void SeedUsers(ShopContext context)
        {
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);
            string password = "Test123";

            string[] names =
            {
                "BobbyT",
                "PeterT",
                "MarioT",
                "DannyT"
            };

            foreach (string name in names)
            {
                userManager.Create(context.Users.Add(new User { UserName = name, CityId = 1, RegisterDate = DateTime.Now, Email = name + "@test.com", Skype = name }), password);
            }

            context.SaveChanges();
        }
    }
}
