using BigDLL4221.Enum;
using BigDLL4221.Models;
using BigDLL4221.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace AphoNonUniqueKeyPages
{
    public class AphoNonUniqueKeyPages
    {
        public static string PackageId = "AphoNonUniqueKeyPages";
        public static string Path;
        public static string CategoryName = "Non-fixed Decks";
    }
    public class AphoNonUniqueKeyPagesInit : ModInitializer
    {
        public override void OnInitializeMod()
        {
            OnInitParameters();
            ArtUtil.GetArtWorks(new DirectoryInfo(AphoNonUniqueKeyPages.Path + "/ArtWork"));
            ArtUtil.GetCardArtWorks(new DirectoryInfo(AphoNonUniqueKeyPages.Path + "/CardArtWork"));
            ArtUtil.PreLoadBufIcons();
            CardUtil.ChangeCardItem(ItemXmlDataList.instance, AphoNonUniqueKeyPages.PackageId);
            KeypageUtil.ChangeKeypageItem(BookXmlList.Instance, AphoNonUniqueKeyPages.PackageId);
            PassiveUtil.ChangePassiveItem(AphoNonUniqueKeyPages.PackageId);
            LocalizeUtil.AddGlobalLocalize(AphoNonUniqueKeyPages.PackageId);
            LocalizeUtil.RemoveError();
            CardUtil.InitKeywordsList(new List<Assembly> { Assembly.GetExecutingAssembly() });
            ArtUtil.InitCustomEffects(new List<Assembly> { Assembly.GetExecutingAssembly() });
        }
        private static void OnInitParameters()
        {
            ModParameters.PackageIds.Add(AphoNonUniqueKeyPages.PackageId);
            AphoNonUniqueKeyPages.Path = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
            ModParameters.Path.Add(AphoNonUniqueKeyPages.PackageId, AphoNonUniqueKeyPages.Path);
            OnInitRewards();
            OnInitCategories();
            OnInitSprites();
            OnInitKeypages();
            OnInitPassives();
            OnInitCards();
        }
        private static void OnInitRewards()
        {
            ModParameters.StartUpRewardOptions.Add(new RewardOptions(keypages: new List<LorId>
            {
                    new LorId(AphoNonUniqueKeyPages.PackageId, 1),
                    new LorId(AphoNonUniqueKeyPages.PackageId, 10),
                    new LorId(AphoNonUniqueKeyPages.PackageId, 20),
                    new LorId(AphoNonUniqueKeyPages.PackageId, 21),
            }));
            ModParameters.StartUpRewardOptions.Add(new RewardOptions(cards: new Dictionary<LorId, int>
            {
                //BS
                { new LorId(AphoNonUniqueKeyPages.PackageId, 702001), 99 },
                { new LorId(AphoNonUniqueKeyPages.PackageId, 702002), 99 },
                { new LorId(AphoNonUniqueKeyPages.PackageId, 702003), 99 },
                { new LorId(AphoNonUniqueKeyPages.PackageId, 702004), 99 },
                { new LorId(AphoNonUniqueKeyPages.PackageId, 702005), 99 },
                { new LorId(AphoNonUniqueKeyPages.PackageId, 702006), 99 },
                { new LorId(AphoNonUniqueKeyPages.PackageId, 702007), 99 },
                { new LorId(AphoNonUniqueKeyPages.PackageId, 702008), 99 },
                { new LorId(AphoNonUniqueKeyPages.PackageId, 702009), 99 },
                //BinahDegraded
                { new LorId(AphoNonUniqueKeyPages.PackageId, 607201), 99 },
                { new LorId(AphoNonUniqueKeyPages.PackageId, 607202), 99 },
                { new LorId(AphoNonUniqueKeyPages.PackageId, 607203), 99 },
                { new LorId(AphoNonUniqueKeyPages.PackageId, 607204), 99 },
                { new LorId(AphoNonUniqueKeyPages.PackageId, 607205), 99 },
                //Binah
                { new LorId(AphoNonUniqueKeyPages.PackageId, 706201), 99 },
                { new LorId(AphoNonUniqueKeyPages.PackageId, 706202), 99 },
                { new LorId(AphoNonUniqueKeyPages.PackageId, 706203), 99 },
                { new LorId(AphoNonUniqueKeyPages.PackageId, 706204), 99 },
                { new LorId(AphoNonUniqueKeyPages.PackageId, 706205), 99 },
            }));
        }
        private static void OnInitCategories()
        {
            ModParameters.CategoryOptions.Add(AphoNonUniqueKeyPages.PackageId, new List<CategoryOptions>
            {
                new CategoryOptions(AphoNonUniqueKeyPages.PackageId, additionalValue: "_1", categoryBooksId:new List<int>{1, 10, 20, 21}, categoryName: AphoNonUniqueKeyPages.CategoryName,customIconSpriteId:AphoNonUniqueKeyPages.PackageId, bookDataColor: new CategoryColorOptions(new Color(0.624f, 0.169f, 0.408f), new Color(0.898f, 0.169f, 0.314f)), credenzaType: CredenzaEnum.NoCredenza, chapter: 7),
            });
        }
        private static void OnInitSprites()
        {
            ModParameters.SpriteOptions.Add(AphoNonUniqueKeyPages.PackageId, new List<SpriteOptions>
            {
               new SpriteOptions(SpriteEnum.Custom, 1, "Apho_NonUniqueKeyPages_Angela"),
               new SpriteOptions(SpriteEnum.Custom, 10, "Apho_NonUniqueKeyPages_Roland"),
               new SpriteOptions(SpriteEnum.Custom, 20, "Apho_NonUniqueKeyPages_BinahSprite"),
               new SpriteOptions(SpriteEnum.Custom, 21, "Apho_NonUniqueKeyPages_BinahSprite"),
            });
        }
        private static void OnInitKeypages()
        {
            Color pale = new Color(0, 0.502f, 0.502f), black = new Color(0.25f, 0.25f, 0.25f), binahcolor = new Color(0.58f, 0.459f, 0.094f);
            ModParameters.KeypageOptions.Add(AphoNonUniqueKeyPages.PackageId, new List<KeypageOptions>
            {
                new KeypageOptions(1, everyoneCanEquip: true, keypageColorOptions: new KeypageColorOptions(pale, pale)), //angela
                new KeypageOptions(10, everyoneCanEquip: true, keypageColorOptions: new KeypageColorOptions(black, Color.white)), //roland
                new KeypageOptions(20, everyoneCanEquip: true, keypageColorOptions: new KeypageColorOptions(binahcolor,binahcolor)), //binahdegraded
                new KeypageOptions(21, everyoneCanEquip: true, keypageColorOptions: new KeypageColorOptions(binahcolor,binahcolor)), //binah
            });
        }
        private static void OnInitPassives()
        {
            Color pale = new Color(0, 0.502f, 0.502f), black = new Color(0.25f, 0.25f, 0.25f), binahcolor = new Color(0.58f, 0.459f, 0.094f);
            ModParameters.PassiveOptions.Add(AphoNonUniqueKeyPages.PackageId, new List<PassiveOptions>
            {
                new PassiveOptions(1005015, transferable: true, bannedEgoFloorCards: true, passiveColorOptions: new PassiveColorOptions(pale, pale)), //??? (Angela's Passive)
                new PassiveOptions(10012, transferable: true, passiveColorOptions: new PassiveColorOptions(Color.white, black)), //Orlando
                new PassiveOptions(10013, transferable: true, passiveColorOptions: new PassiveColorOptions(Color.white, black)), //BS
                new PassiveOptions(10011, transferable: true, passiveColorOptions: new PassiveColorOptions(binahcolor, binahcolor)), //Incomplete Arbiter
                new PassiveOptions(180005, transferable: true, passiveColorOptions: new PassiveColorOptions(binahcolor, binahcolor)), //An Arbiter
            });
        }
        private static void OnInitCards()
        {
            Color black = new Color(0.25f, 0.25f, 0.25f), binahcolor = new Color(0.259f, 0.157f, 0.063f);
            //binahcolor = new Color(0.58f, 0.459f, 0.094f);
            ModParameters.CardOptions.Add(AphoNonUniqueKeyPages.PackageId, new List<CardOptions>
            {
                //BS
                new CardOptions(702001, cardColorOptions: new CardColorOptions(black, rightFrame: "Apho_NonUnique_BS_RightPage", useHSVFilter: false)), 
                new CardOptions(702002, cardColorOptions: new CardColorOptions(black, rightFrame: "Apho_NonUnique_BS_RightPage", useHSVFilter: false)),
                new CardOptions(702003, cardColorOptions: new CardColorOptions(black, rightFrame: "Apho_NonUnique_BS_RightPage", useHSVFilter: false)),
                new CardOptions(702004, cardColorOptions: new CardColorOptions(black, rightFrame: "Apho_NonUnique_BS_RightPage", useHSVFilter: false)),
                new CardOptions(702005, cardColorOptions: new CardColorOptions(black, rightFrame: "Apho_NonUnique_BS_RightPage", useHSVFilter: false)),
                new CardOptions(702006, cardColorOptions: new CardColorOptions(black, rightFrame: "Apho_NonUnique_BS_RightPage", useHSVFilter: false)),
                new CardOptions(702007, cardColorOptions: new CardColorOptions(black, rightFrame: "Apho_NonUnique_BS_RightPage", useHSVFilter: false)),
                new CardOptions(702008, cardColorOptions: new CardColorOptions(black, rightFrame: "Apho_NonUnique_BS_RightPage", useHSVFilter: false)),
                new CardOptions(702009, cardColorOptions: new CardColorOptions(black, rightFrame: "Apho_NonUnique_BS_RightPage", useHSVFilter: false)),
                new CardOptions(702010, cardColorOptions: new CardColorOptions(black, rightFrame: "Apho_NonUnique_Furioso_RightPage", useHSVFilter: false)), //Furioso
                //BinahDegraded
                new CardOptions(607201, cardColorOptions: new CardColorOptions(binahcolor, rightFrame: "Apho_NonUnique_Binah_RightPage", useHSVFilter: false)),
                new CardOptions(607202, cardColorOptions: new CardColorOptions(binahcolor, rightFrame: "Apho_NonUnique_Binah_RightPage", useHSVFilter: false)),
                new CardOptions(607203, cardColorOptions: new CardColorOptions(binahcolor, rightFrame: "Apho_NonUnique_Binah_RightPage", useHSVFilter: false)),
                new CardOptions(607204, cardColorOptions: new CardColorOptions(binahcolor, rightFrame: "Apho_NonUnique_Binah_RightPage", useHSVFilter: false)),
                new CardOptions(607205, cardColorOptions: new CardColorOptions(binahcolor, rightFrame: "Apho_NonUnique_Binah_RightPage", useHSVFilter: false)),
                //Binah
                new CardOptions(706201, cardColorOptions: new CardColorOptions(binahcolor, rightFrame: "Apho_NonUnique_Binah_RightPage", useHSVFilter: false)),
                new CardOptions(706202, cardColorOptions: new CardColorOptions(binahcolor, rightFrame: "Apho_NonUnique_Binah_RightPage", useHSVFilter: false)),
                new CardOptions(706203, cardColorOptions: new CardColorOptions(binahcolor, rightFrame: "Apho_NonUnique_Binah_RightPage", useHSVFilter: false)),
                new CardOptions(706204, cardColorOptions: new CardColorOptions(binahcolor, rightFrame: "Apho_NonUnique_Binah_RightPage", useHSVFilter: false)),
                new CardOptions(706205, cardColorOptions: new CardColorOptions(binahcolor, rightFrame: "Apho_NonUnique_Binah_RightPage", useHSVFilter: false)),
            });
        }
    }

}
