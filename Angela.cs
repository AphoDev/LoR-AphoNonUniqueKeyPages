using System.Collections.Generic;

namespace AphoNonUniqueKeyPages
{
    public class PassiveAbility_AphoNonUniqueKeyPages_Angela : PassiveAbilityBase
    {
        public override void OnWaveStart()
        {
            BattleUnitEmotionDetail emotionDetail = owner.emotionDetail;
            switch (emotionDetail.EmotionLevel)
            {
                //level 1 - Malk/yesod
                case 1:
                    this.owner.personalEgoDetail.AddCard(9910011);
                    this.owner.personalEgoDetail.AddCard(9910012);
                    break;
                //level 2 - hod/netzach
                case 2:
                    this.owner.personalEgoDetail.AddCard(9910013);
                    this.owner.personalEgoDetail.AddCard(9910014);
                    goto case 1;
                //level 3 - tiph/geb/chesed
                case 3:
                    this.owner.personalEgoDetail.AddCard(9910015);
                    this.owner.personalEgoDetail.AddCard(9910016);
                    this.owner.personalEgoDetail.AddCard(9910017);
                    goto case 2;
                //level 4 - binah/hokma
                case 4:
                    this.owner.personalEgoDetail.AddCard(9910018);
                    this.owner.personalEgoDetail.AddCard(9910019);
                    goto case 3;
                //level 5 - knowing I, if all cards have been used
                case 5:
                    if (this._usedCount.Count >= 9)
                    {
                        this.owner.personalEgoDetail.AddCard(new LorId(AphoNonUniqueKeyPages.PackageId, 9910021));
                    }
                    goto case 4;
                default:
                    break;
            }

        }
        public override void OnLevelUpEmotion()
        {
            BattleUnitEmotionDetail emotionDetail = owner.emotionDetail;
            switch (emotionDetail.EmotionLevel)
            {
                //level 1 - Malk/yesod
                case 1:
                    this.owner.personalEgoDetail.AddCard(9910011);
                    this.owner.personalEgoDetail.AddCard(9910012);
                    break;
                //level 2 - hod/netzach
                case 2:
                    this.owner.personalEgoDetail.AddCard(9910013);
                    this.owner.personalEgoDetail.AddCard(9910014);
                    break;
                //level 3 - tiph/geb/chesed
                case 3:
                    this.owner.personalEgoDetail.AddCard(9910015);
                    this.owner.personalEgoDetail.AddCard(9910016);
                    this.owner.personalEgoDetail.AddCard(9910017);
                    break;
                //level 4 - binah/hokma
                case 4:
                    this.owner.personalEgoDetail.AddCard(9910018);
                    this.owner.personalEgoDetail.AddCard(9910019);
                    break;
                //level 5 - knowing I, if all cards have been used
                case 5:
                    if (this._usedCount.Count >= 9)
                    {
                        this.owner.personalEgoDetail.AddCard(new LorId (AphoNonUniqueKeyPages.PackageId, 9910021));
                    }
                    break;
                default:
                    break;

            }
        }
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            LorId id = curCard.card.GetID();
            if (id.IsWorkshop())
            {
                return;
            }
            int id2 = id.id;
            if (!this._usedCount.Contains(id) && ((id2 >= 9910011 && id2 <= 9910019)))
            {
                this._usedCount.Add(id);
            }
        }

        public override void OnRoundStart()
        {
            BattleUnitEmotionDetail emotionDetail = owner.emotionDetail;
            if (this._usedCount.Count >= 9 && emotionDetail.EmotionLevel >= 5)
            {
                this.owner.personalEgoDetail.AddCard(new LorId(AphoNonUniqueKeyPages.PackageId, 9910021));
            }
            foreach (BattleDiceCardModel battleDiceCardModel in this.owner.personalEgoDetail.GetCardAll())
            {
                battleDiceCardModel.RemoveBuf<BattleDiceCardBuf_AphoNonUniqueKeyPages_AngelaCount>();
            }
            int count = this._usedCount.Count;
            foreach (BattleDiceCardModel battleDiceCardModel2 in this.owner.personalEgoDetail.GetCardAll())
            {
                LorId id = battleDiceCardModel2.GetID();
                if (!id.IsWorkshop())
                {
                    int id2 = id.id;
                    if (!this._usedCount.Contains(id) && ((id2 >= 9910011 && id2 <= 9910019)))
                    {
                        battleDiceCardModel2.AddBuf(new BattleDiceCardBuf_AphoNonUniqueKeyPages_AngelaCount());
                    }
                }
            }
            this.owner.bufListDetail.RemoveBufAll(typeof(BattleUnitBuf_AphoNonUniqueKeyPages_AngelaCount));
            this.owner.bufListDetail.AddBuf(new BattleUnitBuf_AphoNonUniqueKeyPages_AngelaCount
            {
                stack = this._usedCount.Count
            });
        }
        public bool IsActivatedSpecialCard()
        {
            return this._usedCount.Count >= 9;
        }
        public void ResetUsedCount()
        {
            this._usedCount.Clear();
        }
        private List<LorId> _usedCount = new List<LorId>();
        public class BattleDiceCardBuf_AphoNonUniqueKeyPages_AngelaCount : BattleDiceCardBuf
        {
            protected override string keywordIconId
            {
                get
                {
                    return "KeterFinal_Angela_Ego";
                }
            }
        }
        public class BattleUnitBuf_AphoNonUniqueKeyPages_AngelaCount : BattleUnitBuf
        {
            protected override string keywordId
            {
                get
                {
                    return "KeterFinal_Angela_Ego";
                }
            }
            protected override string keywordIconId
            {
                get
                {
                    return "KeterFinal_Angela_Ego";
                }
            }
        }
    }

    public class DiceCardSelfAbility_AphoNonUniqueKeyPages_KnowingI : DiceCardSelfAbilityBase
    {
        public static string Desc = "This page can be used after using 9 unique E.G.O pages.\n[On Use] Sacrifice all of user's HP";
        public override bool OnChooseCard(BattleUnitModel owner)
        {
            PassiveAbility_AphoNonUniqueKeyPages_Angela passiveAbility_ = owner.passiveDetail.PassiveList.Find((PassiveAbilityBase x) => x is PassiveAbility_AphoNonUniqueKeyPages_Angela) as PassiveAbility_AphoNonUniqueKeyPages_Angela;
            if (passiveAbility_ != null)
            {
                return passiveAbility_.IsActivatedSpecialCard();
            }
            return false;
        }
        public override void OnUseCard()
        {
            PassiveAbility_AphoNonUniqueKeyPages_Angela passiveAbility_ = base.owner.passiveDetail.PassiveList.Find((PassiveAbilityBase x) => x is PassiveAbility_AphoNonUniqueKeyPages_Angela) as PassiveAbility_AphoNonUniqueKeyPages_Angela;
            if (passiveAbility_ != null)
            {
                passiveAbility_.ResetUsedCount();
            }
            base.owner.LoseHp(base.owner.MaxHp);
        }
    }
    public class DiceCardAbility_AphoNonUniqueKeyPages_KnowingI_Dice : DiceCardAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                "AreaCard_Keyword",
                };
            }
        }
    }
}
