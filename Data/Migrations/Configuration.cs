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
                "Айтос (Aytos)",
                "Аксаково (Aksakovo)",
                "Алфатар (Alfatar)",
                "Антоново (Antonovo)",
                "Априлци (Apriltsi)",
                "Ардино (Ardino)",
                "Асеновград (Asenovgrad)",
                "Ахелой (Aheloy)",
                "Ахтопол (Ahtopol)",
                "Балчик (Balchik)",
                "Банкя (Bankya)",
                "Банско (Bansko)",
                "Баня (Banya)",
                "Батак (Batak)",
                "Батановци (Batanovtsi)",
                "Белене (Belene)",
                "Белица (Belitsa)",
                "Белово (Belovo)",
                "Белоградчик (Belogradchik)",
                "Белослав (Beloslav)",
                "Берковица (Berkovitsa)",
                "Благоевград (Blagoevgrad)",
                "Бобов дол (Bobov dol)",
                "Бобошево (Boboshevo)",
                "Божурище (Bozhurishte)",
                "Бойчиновци (Boychinovtsi)",
                "Болярово (Bolyarovo)",
                "Борово (Borovo)",
                "Ботевград (Botevgrad)",
                "Брацигово (Bratsigovo)",
                "Брегово (Bregovo)",
                "Брезник (Breznik)",
                "Брезово (Brezovo)",
                "Брусарци (Brusartsi)",
                "Бургас (Burgas)",
                "Бухово (Buhovo)",
                "Българово (Balgarovo)",
                "2Бяла (2Byala)",
                "Бяла Слатина (Byala Slatina)",
                "Бяла Черква (Byala Cherkva)",
                "Варна (Varna)",
                "Велики Преслав (Veliki Preslav)",
                "Велико Търново (Veliko Tarnovo)",
                "Велинград (Velingrad)",
                "Ветово (Vetovo)",
                "Ветрен (Vetren)",
                "Видин (Vidin)",
                "Враца (Vratsa)",
                "Вълчедръм (Valchedram)",
                "Вълчи дол (Valchi dol)",
                "Върбица (Varbitsa)",
                "Вършец (Varshets)",
                "Габрово (Gabrovo)",
                "Генерал Тошево (General Toshevo)",
                "Главиница (Glavinitsa)",
                "Глоджево (Glodzhevo)",
                "Годеч (Godech)",
                "Горна Оряховица (Gorna Oryahovitsa)",
                "Гоце Делчев (Gotse Delchev)",
                "Грамада (Gramada)",
                "Гулянци (Gulyantsi)",
                "Гурково (Gurkovo)",
                "Гълъбово (Galabovo)",
                "Две могили (Dve mogili)",
                "Дебелец (Debelets)",
                "Девин (Devin)",
                "Девня (Devnya)",
                "Джебел (Dzhebel)",
                "Димитровград (Dimitrovgrad)",
                "Димово (Dimovo)",
                "Добринище (Dobrinishte)",
                "Добрич (Dobrich)",
                "Долна баня (Dolna banya)",
                "Долна Митрополия (Dolna Mitropoliya)",
                "Долна Оряховица (Dolna Oryahovitsa)",
                "Долни Дъбник (Dolni Dabnik)",
                "Долни чифлик (Dolni chiflik)",
                "Доспат (Dospat)",
                "Драгоман (Dragoman)",
                "Дряново (Dryanovo)",
                "Дулово (Dulovo)",
                "Дунавци (Dunavtsi)",
                "Дупница (Dupnitsa)",
                "Дългопол (Dalgopol)",
                "Елена (Elena)",
                "Елин Пелин (Elin Pelin)",
                "Елхово (Elhovo)",
                "Етрополе (Etropole)",
                "Завет (Zavet)",
                "Земен (Zemen)",
                "Златарица (Zlataritsa)",
                "Златица (Zlatitsa)",
                "Златоград (Zlatograd)",
                "Ивайловград (Ivaylovgrad)",
                "Игнатиево (Ignatievo)",
                "Искър (Iskar)",
                "Исперих (Isperih)",
                "Ихтиман (Ihtiman)",
                "Каблешково (Kableshkovo)",
                "Каварна (Kavarna)",
                "Казанлък (Kazanlak)",
                "Калофер (Kalofer)",
                "Камено (Kameno)",
                "Каолиново (Kaolinovo)",
                "Карлово (Karlovo)",
                "Карнобат (Karnobat)",
                "Каспичан (Kaspichan)",
                "Кермен (Kermen)",
                "Килифарево (Kilifarevo)",
                "Китен (Kiten)",
                "Клисура (Klisura)",
                "Кнежа (Knezha)",
                "Козлодуй (Kozloduy)",
                "Койнаре (Koynare)",
                "Копривщица (Koprivshtitsa)",
                "Костандово (Kostandovo)",
                "Костенец (Kostenets)",
                "Костинброд (Kostinbrod)",
                "Котел (Kotel)",
                "Кочериново (Kocherinovo)",
                "Кресна (Kresna)",
                "Криводол (Krivodol)",
                "Кричим (Krichim)",
                "Крумовград (Krumovgrad)",
                "Крън (Kran)",
                "Кубрат (Kubrat)",
                "Куклен (Kuklen)",
                "Кула (Kula)",
                "Кърджали (Kardzhali)",
                "Кюстендил (Kyustendil)",
                "Левски (Levski)",
                "Летница (Letnitsa)",
                "Ловеч (Lovech)",
                "Лозница (Loznitsa)",
                "Лом (Lom)",
                "Луковит (Lukovit)",
                "Лъки (Laki)",
                "Любимец (Lyubimets)",
                "Лясковец (Lyaskovets)",
                "Мадан (Madan)",
                "Маджарово (Madzharovo)",
                "Малко Търново (Malko Tarnovo)",
                "Мартен (Marten)",
                "Мездра (Mezdra)",
                "Мелник (Melnik)",
                "Меричлери (Merichleri)",
                "Мизия (Miziya)",
                "Момин проход (Momin prohod)",
                "Момчилград (Momchilgrad)",
                "Монтана (Montana)",
                "Мъглиж (Maglizh)",
                "Неделино (Nedelino)",
                "Несебър (Nesebar)",
                "Николаево (Nikolaevo)",
                "Никопол (Nikopol)",
                "Нова Загора (Nova Zagora)",
                "Нови Искър (Novi Iskar)",
                "Нови пазар (Novi pazar)",
                "Обзор (Obzor)",
                "Омуртаг (Omurtag)",
                "Опака (Opaka)",
                "Оряхово (Oryahovo)",
                "Павел баня (Pavel banya)",
                "Павликени (Pavlikeni)",
                "Пазарджик (Pazardzhik)",
                "Панагюрище (Panagyurishte)",
                "Перник (Pernik)",
                "Перущица (Perushtitsa)",
                "Петрич (Petrich)",
                "Пещера (Peshtera)",
                "Пирдоп (Pirdop)",
                "Плачковци (Plachkovtsi)",
                "Плевен (Pleven)",
                "Плиска (Pliska)",
                "Пловдив (Plovdiv)",
                "Полски Тръмбеш (Polski Trambesh)",
                "Поморие (Pomorie)",
                "Попово (Popovo)",
                "Пордим (Pordim)",
                "Правец (Pravets)",
                "Приморско (Primorsko)",
                "Провадия (Provadiya)",
                "Първомай (Parvomay)",
                "Раднево (Radnevo)",
                "Радомир (Radomir)",
                "Разград (Razgrad)",
                "Разлог (Razlog)",
                "Ракитово (Rakitovo)",
                "Раковски (Rakovski)",
                "Рила (Rila)",
                "Роман (Roman)",
                "Рудозем (Rudozem)",
                "Русе (Ruse)",
                "Садово (Sadovo)",
                "Самоков (Samokov)",
                "Сандански (Sandanski)",
                "Сапарева баня (Sapareva banya)",
                "Свети Влас (Sveti Vlas)",
                "Свиленград (Svilengrad)",
                "Свищов (Svishtov)",
                "Своге (Svoge)",
                "Севлиево (Sevlievo)",
                "Сеново (Senovo)",
                "Септември (Septemvri)",
                "Силистра (Silistra)",
                "Симеоновград (Simeonovgrad)",
                "Симитли (Simitli)",
                "Славяново (Slavyanovo)",
                "Сливен (Sliven)",
                "Сливница (Slivnitsa)",
                "Сливо поле (Slivo pole)",
                "Смолян (Smolyan)",
                "Смядово (Smyadovo)",
                "Созопол (Sozopol)",
                "Сопот (Sopot)",
                "София (Sofiya)",
                "Средец (Sredets)",
                "Стамболийски (Stamboliyski)",
                "Стара Загора (Stara Zagora)",
                "Стражица (Strazhitsa)",
                "Стралджа (Straldzha)",
                "Стрелча (Strelcha)",
                "Суворово (Suvorovo)",
                "Сунгурларе (Sungurlare)",
                "Сухиндол (Suhindol)",
                "Съединение (Saedinenie)",
                "Сърница (Sarnitsa)",
                "Твърдица (Tvarditsa)",
                "Тервел (Tervel)",
                "Тетевен (Teteven)",
                "Тополовград (Topolovgrad)",
                "Троян (Troyan)",
                "Трън (Tran)",
                "Тръстеник (Trastenik)",
                "Трявна (Tryavna)",
                "Тутракан (Tutrakan)",
                "Търговище (Targovishte)",
                "Угърчин (Ugarchin)",
                "Хаджидимово (Hadzhidimovo)",
                "Харманли (Harmanli)",
                "Хасково (Haskovo)",
                "Хисаря (Hisarya)",
                "Цар Калоян (Tsar Kaloyan)",
                "Царево (Tsarevo)",
                "Чепеларе (Chepelare)",
                "Червен бряг (Cherven bryag)",
                "Черноморец (Chernomorets)",
                "Чипровци (Chiprovtsi)",
                "Чирпан (Chirpan)",
                "Шабла (Shabla)"
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
