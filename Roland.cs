using System.Collections.Generic;

namespace AphoNonUniqueKeyPages
{
    //Orlando
    public class PassiveAbility_AphoNonUniqueKeyPages_Orlando : PassiveAbilityBase
    {
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            LorId id = curCard.card.GetID();
            if (!this._usedCount.Contains(id) && id != new LorId(AphoNonUniqueKeyPages.PackageId, 702010) && !curCard.card.XmlData.IsEgo() && !curCard.card.XmlData.IsFloorEgo())
            {
                this._usedCount.Add(id);
            }
        }
        public override void OnWaveStart()
        {
            this.owner.personalEgoDetail.AddCard(new LorId(AphoNonUniqueKeyPages.PackageId, 702010));
        }
        public override void OnRoundStart()
        {
            foreach (BattleDiceCardModel battleDiceCardModel in this.owner.allyCardDetail.GetAllDeck())
            {
                battleDiceCardModel.RemoveBuf<PassiveAbility_10012.BattleDiceCardBuf_blackSilenceEgoCount>();
            }
            int count = this._usedCount.Count;
            foreach (BattleDiceCardModel battleDiceCardModel2 in this.owner.allyCardDetail.GetAllDeck())
            {
                LorId id = battleDiceCardModel2.GetID();
                int id2 = id.id;
                if (!this._usedCount.Contains(id) && id != new LorId(AphoNonUniqueKeyPages.PackageId, 702010) && !battleDiceCardModel2.XmlData.IsEgo() && !battleDiceCardModel2.XmlData.IsFloorEgo())
                {
                    battleDiceCardModel2.AddBuf(new PassiveAbility_10012.BattleDiceCardBuf_blackSilenceEgoCount());
                }
                
            }
            this.owner.bufListDetail.RemoveBufAll(typeof(PassiveAbility_10012.BattleUnitBuf_blackSilenceSpecialCount));
            this.owner.bufListDetail.AddBuf(new PassiveAbility_10012.BattleUnitBuf_blackSilenceSpecialCount
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
    }
    //Furioso
    public class DiceCardSelfAbility_AphoNonUniqueKeyPages_Furioso : DiceCardSelfAbilityBase
    {
        public static string Desc = "This page can be used after using 9 unique Combat Pages (Excluding E.G.O Pages)\nOn hit, inflict 5 Bleed, 3 Bind, and 3 Fragile next scene.";
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                "Bleeding_Keyword",
                "Vulnerable_Keyword",
                "Binding_Keyword"
                };
            }
        }
        public override bool OnChooseCard(BattleUnitModel owner)
        {
            PassiveAbility_AphoNonUniqueKeyPages_Orlando passiveAbility_ = owner.passiveDetail.PassiveList.Find((PassiveAbilityBase x) => x is PassiveAbility_AphoNonUniqueKeyPages_Orlando) as PassiveAbility_AphoNonUniqueKeyPages_Orlando;
            if (passiveAbility_ != null)
            {
                return passiveAbility_.IsActivatedSpecialCard();
            }
            return false;
        }
        public override void OnUseCard()
        {
            PassiveAbility_AphoNonUniqueKeyPages_Orlando passiveAbility_ = base.owner.passiveDetail.PassiveList.Find((PassiveAbilityBase x) => x is PassiveAbility_AphoNonUniqueKeyPages_Orlando) as PassiveAbility_AphoNonUniqueKeyPages_Orlando;
            if (passiveAbility_ != null)
            {
                passiveAbility_.ResetUsedCount();
            }
        }
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            if (this.card != null && this.card.target != null)
            {
                this.card.target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Bleeding, 5, base.owner);
                this.card.target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Binding, 3, base.owner);
                this.card.target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Vulnerable, 3, base.owner);
            }
        }
    }
}
